using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OyunArkadasim.Models;

namespace OyunArkadasim.Utility
{
    public class UygulamaDbContext : IdentityDbContext
    {
        public UygulamaDbContext(DbContextOptions<UygulamaDbContext> options) : base(options) { }
       
       

        public DbSet<Oyun> Oyunlar { get; set; }
        public DbSet<OyunTuru> OyunTurleri { get; set; }
        public DbSet<Oyunlarim> Oyunlarim { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }




    }
}
