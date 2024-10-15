using System.ComponentModel.DataAnnotations.Schema;
using tickets_management.Enums;
namespace tickets_management.Models
{
    [Table("Tickets")]
    public class Ticket
    {
         
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public DateOnly CreateOn { get; set; } = DateOnly.FromDateTime(DateTime.Now);
    }
}
