using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MikayilHavaYollari.Models;

namespace MikayilHavaYollari.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options){}
        public DbSet<About> About { get; set; }
        public DbSet<HomeSlider> HomeSliders { get; set; }
        public DbSet<GetInTouch> GetInTouches { get; set; }
    }
}
