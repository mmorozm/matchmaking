using System.Reflection;
using Matchmaking.Migrations.Data;
using Matchmaking.Models.Services.Extensions;
using Matchmaking.Shared.Extensions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<MatchmakingDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"),
        npgsqlOptionsAction: sqlOptions =>
        {
            sqlOptions.MigrationsAssembly("Matchmaking.Migrations.Data"); // Specify the migrations assembly
        }));

builder.Services.AddMappers(Assembly.GetExecutingAssembly());
builder.Services.AddMatchmakingRepositories();
builder.Services.AddHealthChecks();
builder.Services.AddControllers();

// Configure Swagger/OpenAPI
var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Matchmaking API",
        Version = "v1",
        Description = "API for matchmaking services"
    });

    if (File.Exists(xmlPath))
    {
        options.IncludeXmlComments(xmlPath);
    }
});

builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    //replace DataContext with your Db Context name
    var dataContext = scope.ServiceProvider.GetRequiredService<MatchmakingDbContext>();
    dataContext.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMatchmakingHealthChecks();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();