using Chorify.EntityFramework.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Chorify.EntityFramework
{
    public class ChorifyDbContext : DbContext
    {
        public DbSet<UserDto> Users { get; set; }
        public DbSet<ChoreDto> Chores { get; set; }

        public ChorifyDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserDto>()
                .HasMany(u => u.Chores)
                .WithOne(c => c.User)
                .IsRequired(false);
        }
    }
}
