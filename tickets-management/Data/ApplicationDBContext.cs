using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using tickets_management.Models;

namespace tickets_management.Data
{
    public class ApplicationDBContext : IdentityDbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
        :base(options){
            
        }

        public DbSet<Ticket> Tickets { get; set; }

    }
}
