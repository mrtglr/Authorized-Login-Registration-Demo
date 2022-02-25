using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace AuthLoginDemo_bnd.Models
{
    public class AuthenticationContext : DbContext
    {
        public AuthenticationContext(DbContextOptions options):base(options) { }
        
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    }
}