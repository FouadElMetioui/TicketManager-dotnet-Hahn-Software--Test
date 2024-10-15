using System.ComponentModel.DataAnnotations;
using tickets_management.Enums;

namespace tickets_management.Dto
{
    public class CreateTicketRequestDto
    {
        [Required]
        public string Description { get; set; } = string.Empty;
        [Required]
        public string Status { get; set; } = string.Empty;
        [Required]
        public DateOnly CreateOn { get; set; } = DateOnly.FromDateTime(DateTime.Now);

    }
}
