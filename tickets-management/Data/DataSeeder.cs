using Microsoft.AspNetCore.Http.HttpResults;
using tickets_management.Models;

namespace tickets_management.Data
{
    public static class DataSeeder
    {
        
        public static void SeedTickets(ApplicationDBContext context)
        {
            // Vérifie s'il y a des tickets existants pour éviter d'insérer des doublons
            if (!context.Tickets.Any())
            {
                context.Tickets.AddRange(
                    new Ticket {  Description = "Promotion Code Issued" ,Status = "Open", CreateOn = DateOnly.FromDateTime(DateTime.Now)  },
                    new Ticket { Description = "Additionnal User Account", Status = "Open", CreateOn = DateOnly.FromDateTime(DateTime.Now) },
                    new Ticket { Description = "Change Payment Method", Status = "Open", CreateOn = DateOnly.FromDateTime(DateTime.Now) },
                    new Ticket { Description = "Activate Account", Status = "Closed", CreateOn = DateOnly.FromDateTime(DateTime.Now) },
                    new Ticket { Description = "Activate Account", Status = "Closed", CreateOn = DateOnly.FromDateTime(DateTime.Now) },
                    new Ticket { Description = "Great Job", Status = "Closed", CreateOn = DateOnly.FromDateTime(DateTime.Now) },
                    new Ticket { Description = "Another Great Job", Status = "Closed", CreateOn = DateOnly.FromDateTime(DateTime.Now) },
                    new Ticket { Description = "Help With Login", Status = "Closed", CreateOn = DateOnly.FromDateTime(DateTime.Now) },
                    new Ticket { Description = "Happy Customer", Status = "Open", CreateOn = DateOnly.FromDateTime(DateTime.Now) }
                );
                context.SaveChanges();
            }
        }
    }
}
