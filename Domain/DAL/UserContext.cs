using Domain.Models;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Domain.DAL
{
    public class UserContext: DbContext, IDbContext
    {
        public UserContext(DbContextOptions<UserContext> options)
       : base(options)
        {
            // Ensure that the database is created
            Database.EnsureCreated();
        }

        public DbSet<UserModel> UserItems { get; set; } = null!;
        public static string _connectionString { get; private set; }
        public static string ConnectionString { get { 
                if(string.IsNullOrWhiteSpace(_connectionString))
                {
                    var config = new ConfigurationBuilder().AddJsonFile(Path.Combine(Environment.CurrentDirectory, "appsettings.json"))
                        .Build();
                    _connectionString = config.GetSection(key: "ConnectionStrings")["UsersDbConection"];
                }
                return _connectionString;
            } }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserModel>()
                .Property(u => u.Gender)
                .IsRequired(false)  
                .HasConversion<int?>();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }

      
    }

    internal interface IDbContext
    {
    }
}
