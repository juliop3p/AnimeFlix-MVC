using AnimeFlix.App.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AnimeFlix.App.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public override DbSet<ApplicationUser> Users { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}