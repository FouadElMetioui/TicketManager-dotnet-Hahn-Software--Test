using Microsoft.AspNetCore.Http.HttpResults;
using tickets_management.Dto;
using tickets_management.Models;

namespace tickets_management.Mappers
{
    public static class TicketMappers
    {
        public static Ticket toTicketFromCreateRequestDTO(CreateTicketRequestDto ticketDto)
        {
            return new Ticket
            {
                Status = ticketDto.Status,
                Description = ticketDto.Description,
                CreateOn = ticketDto.CreateOn
            };
        }

        public static Ticket toTicketFromUpdateRequestDTO(UpdateTicketRequestDto ticketDto)
        {
            return new Ticket
            {
                Status = ticketDto.Status,
                Description = ticketDto.Description,
                CreateOn = ticketDto.CreateOn,
            };
        }
    }
}
