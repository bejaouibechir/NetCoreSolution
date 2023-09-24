using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using AspNetCoreIdentityImpl.Models;

namespace AspNetCoreIdentityImpl.Data
{

    public class ApplicationDbContext : IdentityDbContext<IdentityUser, IdentityRole, string>
    {
        public ApplicationDbContext()
        {
            
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : base(options)
        {
        }

        public DbSet<RegisterViewModel> RegisterViewModel { get; set; }

        public DbSet<LoginViewModel> LoginViewModel { get; set; }
    }
}
