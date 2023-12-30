using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Domain.DAL
{
    public class UserContext: DbContext
    {
        public UserContext(DbContextOptions<UserContext> options)
       : base(options)
        {
        }

        public DbSet<UserModel> UserItems { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserModel>()
                .Property(u => u.Gender)
                .IsRequired(false)  
                .HasConversion<int?>();
        }


    }
}
