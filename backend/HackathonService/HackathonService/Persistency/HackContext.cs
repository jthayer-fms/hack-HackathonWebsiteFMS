using HackathonService.Dtos;
using Microsoft.EntityFrameworkCore;

namespace HackathonService.Persistency
{
    public class HackContext : DbContext
    {
        public HackContext(DbContextOptions<HackContext> options)
            : base(options)
        {
        }

        public DbSet<HackathonEvent> Events { get; set; }

        public DbSet<Pitch> Pitches { get; set; }

        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PitchMember>().HasKey(sc => new { sc.userId, sc.pitchId });
        }

    }

}
