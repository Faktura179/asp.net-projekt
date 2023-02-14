using Asp.Net_WebApi_projekt.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Asp.Net_WebApi_projekt.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<SwimmingPool> SwimmingPools { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<SwimmingTrack> SwimmingTracks { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
    }
}