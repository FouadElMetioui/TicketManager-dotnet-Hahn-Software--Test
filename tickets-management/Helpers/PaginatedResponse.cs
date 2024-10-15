using tickets_management.Models;

namespace tickets_management.Helpers
{
    public class PaginatedResponse
    {
        public List<Ticket> Tickets { get; set; }
        public int TotalItems { get; set; }
        public int TotalPages { get; set; }
    }
}
