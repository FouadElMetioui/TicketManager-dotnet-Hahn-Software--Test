using Microsoft.AspNetCore.Mvc;
using tickets_management.Data.Repositories;
using tickets_management.Dto;
using tickets_management.Mappers;
using tickets_management.Models;

namespace tickets_management.Controllers

{
    /// <summary>
    /// API Controller for managing tickets.
    /// Provides endpoints for creating, updating, deleting, and retrieving tickets.
    /// </summary>
    [Route("api/v1/tickets")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ITicketRepository _ticketRepository;
        public TicketController(ITicketRepository ticketRepository) {
            _ticketRepository = ticketRepository;
        }

        /// <summary>
        /// Retrieves all tickets from the system.
        /// </summary>
        /// <returns>
        /// A list of all available tickets.
        /// </returns>
        /// <response code="200">Returns the list of tickets.</response>
        [HttpGet]
        public IActionResult GetTickets(int page = 1 , int pageSize = 10)
        {
            return Ok(_ticketRepository.GetAllTickets( page ,  pageSize));
        }

        /// <summary>
        /// Retrieves a specific ticket by its ID.
        /// </summary>
        /// <param name="id">The ID of the ticket to retrieve.</param>
        /// <returns>The ticket with the specified ID.</returns>
        /// <response code="200">If the ticket is found, returns the ticket.</response>
        [HttpGet("{id}")]
        public IActionResult GetTicketById([FromRoute] int id)
        {
            return Ok(_ticketRepository.GetTicket(id));
        }


        /// <summary>
        /// Deletes a specific ticket by its ID.
        /// </summary>
        /// <param name="id">The ID of the ticket to delete.</param>
        /// <response code="204">If the ticket is successfully deleted.</response>
        [HttpDelete("{id}")]
        public void DeleteTicket([FromRoute] int id)
        {
            _ticketRepository.DeleteTicket(id);
        }


        /// <summary>
        /// Updates a specific ticket by its ID.
        /// </summary>
        /// <param name="id">The ID of the ticket to update.</param>
        /// <param name="updateTicket">The updated ticket data.</param>
        /// <returns>The updated ticket.</returns>
        /// <response code="200">Returns the updated ticket.</response>
        [HttpPut("{id}")]
        public IActionResult UpdateTicket([FromRoute] int id ,[FromBody] UpdateTicketRequestDto updateTicket)
        {
            return Ok(_ticketRepository.UpdateTicket(
                id,
                TicketMappers.toTicketFromUpdateRequestDTO(updateTicket)
                ));
        }


        /// <summary>
        /// Creates a new ticket.
        /// </summary>
        /// <param name="ticket">The ticket data to create.</param>
        /// <returns>The newly created ticket.</returns>
        /// <response code="201">Returns the newly created ticket.</response>
        [HttpPost]
        public IActionResult CreateTicket([FromBody] CreateTicketRequestDto ticket)
        {
            return Ok(_ticketRepository.AddTicket(
                                TicketMappers.toTicketFromCreateRequestDTO(ticket)
                ));
        }

    }
}
