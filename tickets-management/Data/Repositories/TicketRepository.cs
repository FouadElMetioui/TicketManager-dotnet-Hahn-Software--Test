using tickets_management.Helpers;
using tickets_management.Models;

namespace tickets_management.Data.Repositories
{
    public class TicketRepository : ITicketRepository
    {
        private readonly ApplicationDBContext _context;
        public TicketRepository(ApplicationDBContext _context) {
            this._context = _context;
        }

        public Ticket GetTicket(int ticketId)
        {
            var ticket = _context.Tickets.Find(ticketId);
            if (ticket == null)
            {
                throw new Exception($"Ticket with id = {ticketId} is not found");
            }
            return ticket;
        }

        public PaginatedResponse GetAllTickets(int page = 1, int pageSize = 10)
        {
            List<Ticket> tickets =  _context.Tickets.ToList();
            var totalTickets = tickets.Count;
            var totalPage = (int)Math.Ceiling((decimal)totalTickets/pageSize);
            var ticketsPerPage = tickets
                .Skip((page-1)*pageSize)
                .Take(pageSize)
                .ToList();

            return new PaginatedResponse
            {
                Tickets = ticketsPerPage,
                TotalItems = totalTickets,
                TotalPages = totalPage,
            };
        }

        public Ticket AddTicket(Ticket ticket)
        {
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine(ticket.CreateOn);
            if (ticket == null)
            {
                throw new ArgumentNullException(nameof(ticket), "Ticket cannot be null");
            }

            _context.Tickets.Add(ticket);
            _context.SaveChanges();
            return ticket;
        }

        public void DeleteTicket(int ticketId)
        {
            var ticket = _context.Tickets.Find(ticketId);

            if (ticket == null)
            {
                throw new Exception($"Ticket with ID {ticketId} not found.");
            }

            _context.Tickets.Remove(ticket);
            _context.SaveChanges();
        } 
   
        public Ticket UpdateTicket(int ticketId, Ticket updatedTicket)
        {
            if (updatedTicket == null)
            {
                throw new ArgumentNullException(nameof(updatedTicket), "Updated ticket cannot be null");
            }

            var existingTicket = _context.Tickets.Find(ticketId);

            if (existingTicket == null)
            {
                throw new Exception($"Ticket with ID {ticketId} not found.");
            }

            existingTicket.Description = updatedTicket.Description;
            existingTicket.CreateOn = updatedTicket.CreateOn;
            existingTicket.Status = updatedTicket.Status;
            updatedTicket.Id = ticketId;

            _context.Tickets.Update(existingTicket);
            _context.SaveChanges();

            return updatedTicket;
        }

       
    }
}
