using tickets_management.Helpers;
using tickets_management.Models;

namespace tickets_management.Data.Repositories
{
    public interface ITicketRepository
    {
        public Ticket GetTicket(int ticketId);
        public PaginatedResponse GetAllTickets(int page = 1, int pageSize = 10);
        public Ticket AddTicket(Ticket ticket);
        public Ticket UpdateTicket(int ticketId, Ticket updatedTicket);
        public void DeleteTicket(int ticketId);

    }
}
