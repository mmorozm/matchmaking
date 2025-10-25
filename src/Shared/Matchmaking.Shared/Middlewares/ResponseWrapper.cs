using System.Net;
using System.Text.Json;
using Matchmaking.Shared.Responses;
using Matchmaking.Shared.Responses.Enums;
using Microsoft.AspNetCore.Http;

namespace Matchmaking.Shared.Middlewares
{
    // Middleware that wraps successful JSON responses into MatchmakingResponse
    public sealed class ResponseWrapper
    {
        private readonly RequestDelegate _next;
        private static readonly JsonSerializerOptions JsonOptions = new(JsonSerializerDefaults.Web)
        {
            WriteIndented = false,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
        };

        public ResponseWrapper(RequestDelegate next)
        {
            _next = next;
        }

        private static bool ShouldSkipWrapping(HttpContext context)
        {
            var path = context.Request.Path.Value?.ToLowerInvariant();
            return path != null && (path.StartsWith("/health") || path.StartsWith("/swagger"));
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (ShouldSkipWrapping(context))
            {
                await _next(context);
                return;
            }

            // Only wrap for JSON-producing endpoints
            // Skip for non-HTTP 200-299 and for already wrapped payloads
            var originalBody = context.Response.Body;
            await using var memStream = new MemoryStream();
            context.Response.Body = memStream;

            try
            {
                await _next(context);

                memStream.Seek(0, SeekOrigin.Begin);
                string? originalPayload = await new StreamReader(memStream).ReadToEndAsync();

                // Restore the original stream for writing final output
                context.Response.Body = originalBody;

                // If no content, still return a wrapped response
                if (string.IsNullOrWhiteSpace(originalPayload))
                {
                    await WriteWrappedAsync(
                        context,
                        new MatchmakingResponse(ResponseCode.Success, "OK", null),
                        context.Response.StatusCode == 0 ? (int)HttpStatusCode.OK : context.Response.StatusCode);
                    return;
                }

                // Try detect if the payload is already a MatchmakingResponse (naive check by presence of "code" and "message" fields)
                if (LooksAlreadyWrapped(originalPayload))
                {
                    await WriteRawAsync(context, originalPayload, context.Response.StatusCode);
                    return;
                }

                // Wrap only for success status codes
                if (context.Response.StatusCode is >= 200 and < 300)
                {
                    object? data;
                    try
                    {
                        data = JsonSerializer.Deserialize<object>(originalPayload, JsonOptions);
                    }
                    catch
                    {
                        // If it's not valid JSON, pass it as string data
                        data = originalPayload;
                    }

                    var wrapped = new MatchmakingResponse(ResponseCode.Success, "OK", data);
                    await WriteWrappedAsync(context, wrapped, context.Response.StatusCode);
                }
                else
                {
                    // For non-success codes, keep original payload
                    await WriteRawAsync(context, originalPayload, context.Response.StatusCode);
                }
            }
            catch (Exception ex)
            {
                // On unhandled exceptions, return standardized error response
                context.Response.Body = originalBody;
                var error = new MatchmakingResponse(ResponseCode.Error, ex.Message, null);
                await WriteWrappedAsync(context, error, (int)HttpStatusCode.InternalServerError);
            }
        }

        private static bool LooksAlreadyWrapped(string json)
        {
            // Cheap check to avoid double-wrapping; robust enough for typical cases
            var span = json.AsSpan().Trim();
            if (span.Length < 2 || span[0] != '{' || span[^1] != '}')
                return false;

            // Avoid full parse cost; quick contains check
            // Note: case-insensitive as JsonSerializerDefaults.Web uses camelCase
            var lower = json.ToLowerInvariant();
            return lower.Contains("\"code\"") && lower.Contains("\"message\"");
        }

        private static async Task WriteWrappedAsync(HttpContext context, MatchmakingResponse response, int statusCode)
        {
            context.Response.ContentType = "application/json; charset=utf-8";
            context.Response.StatusCode = statusCode == 0 ? (int)HttpStatusCode.OK : statusCode;
            var payload = JsonSerializer.Serialize(response, JsonOptions);
            await context.Response.WriteAsync(payload);
        }

        private static async Task WriteRawAsync(HttpContext context, string payload, int statusCode)
        {
            context.Response.ContentType = "application/json; charset=utf-8";
            context.Response.StatusCode = statusCode == 0 ? (int)HttpStatusCode.OK : statusCode;
            await context.Response.WriteAsync(payload);
        }
    }
}