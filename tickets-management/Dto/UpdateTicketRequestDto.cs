namespace tickets_management.Dto
{
    public class UpdateTicketRequestDto
    {
        public string Description { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public DateOnly CreateOn { get; set; } = DateOnly.FromDateTime(DateTime.Now);
    }
}
