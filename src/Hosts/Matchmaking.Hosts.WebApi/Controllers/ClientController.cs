using Matchmaking.Models.Services.Requests;
using Matchmaking.Models.Services.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Matchmaking.Hosts.WebApi.Controllers;

/// <summary>
/// ClientController handles client-specific API requests for matchmaking services.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class ClientController : ControllerBase
{
    public ClientController()
    {
        
    }

    /// <summary>
    /// Handles the registration of a matchmaking ticket for a player or party.
    /// </summary>
    /// <param name="request">
    /// A <see cref="FindMatchRequest"/> object containing details about the player or party,
    /// regions, playlists, and matchmaking preferences such as input device and cross-play settings.
    /// </param>
    /// <returns>
    /// An <see cref="ActionResult{T}"/> where the result is a <see cref="TicketStateResponse"/> enum value
    /// representing the current state of the matchmaking ticket.
    /// </returns>
    [HttpPost("register-ticket")]
    public ActionResult<TicketStateResponse> RegisterTicket(FindMatchRequest request)
    {
        return Ok(new TicketStateResponse());
    }
}