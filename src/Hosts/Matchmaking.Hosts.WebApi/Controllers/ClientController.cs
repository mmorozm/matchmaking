using Matchmaking.Models.Services;
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
    private readonly IClientService _clientService;
    
    public ClientController(IClientService clientService)
    {
        _clientService = clientService;
    }

    /// <summary>
    /// Handles the registration of a matchmaking ticket for a player or party.
    /// </summary>
    /// <param name="request">
    /// A <see cref="FindMatchRequest"/> object containing details about the player or party,
    /// regions, playlists, and matchmaking preferences such as input device and cross-play settings.
    /// </param>
    /// <returns>
    /// An <see cref="ActionResult{T}"/> where the result is a <see cref="TicketStatusResponse"/> enum value
    /// representing the current state of the matchmaking ticket.
    /// </returns>
    [HttpPost("register-ticket")]
    public ActionResult<TicketStatusResponse> RegisterTicket(FindMatchRequest request)
    {
        return Ok(new TicketStatusResponse());
    }

    /// <summary>
    /// Retrieves the current status of a matchmaking ticket using its unique identifier.
    /// </summary>
    /// <param name="ticketId">
    ///     A <see cref="Guid"/> representing the unique identifier of the matchmaking ticket.
    /// </param>
    /// <returns>
    /// An <see cref="ActionResult{T}"/> where the result is a <see cref="TicketStatusResponse"/> enum value
    /// indicating the current state of the ticket, such as Searching, MatchReady, or Cancelled.
    /// </returns>
    [HttpGet("ticket-status/{ticketId}")]
    public ActionResult<TicketStatusResponse> GetTicketStatus(Guid ticketId)
    {
        return Ok(new TicketStatusResponse());
    }

    /// <summary>
    /// Retrieves information about an assigned match for a specified matchmaking ticket.
    /// </summary>
    /// <param name="ticketId">
    /// A <see cref="Guid"/> representing the unique identifier of the matchmaking ticket.
    /// </param>
    /// <returns>
    /// An <see cref="ActionResult{T}"/> where the result is an <see cref="AssignedMatchResponse"/>
    /// containing details about the assigned match, such as participating players and match configuration.
    /// </returns>
    [HttpGet("assigned-match/{ticketId}")]
    public ActionResult<AssignedMatchResponse> GetAssignedMatch(Guid ticketId)
    {
        return Ok(new AssignedMatchResponse());
    }
}