using Domain.Models;
using Microsoft.EntityFrameworkCore;


namespace Domain.DAL
{
    public class UserContext : DbContext, IDbContext
    {
        public UserContext(DbContextOptions<UserContext> options)
       : base(options)
        {
            // Ensure that the database is created
           Database.EnsureCreated();
        }

        public DbSet<UserModel> UserItems { get; set; } = null!;
        public static string _connectionString { get; private set; }
        public static string ConnectionString
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_connectionString))
                {
                    var config = new ConfigurationBuilder().AddJsonFile(Path.Combine(Environment.CurrentDirectory, "appsettings.json"))
                        .Build();
                    _connectionString = config.GetSection(key: "ConnectionStrings")["UsersDbConection"];
                }
                return _connectionString;
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserModel>()
                .Property(u => u.Gender)
                .IsRequired(false)
                .HasConversion<int?>();

            //model seed data
            modelBuilder.Entity<UserModel>().HasData(new UserModel
            {
                Id = 1,
                DateOfBirth = new DateTime(),
                FirstName = "Jane",
                IdentityNumber = "12345678",
                Email = "jane@email.com",
                Gender = Gender.Female,
                LastName = "Doe",
                PhoneNumber = "2828282828"
            }, new UserModel
            {
                Id = 2,
                DateOfBirth = new DateTime(),
                FirstName = "John",
                IdentityNumber = "878787878",
                Email = "john@email.com",
                Gender = Gender.Male,
                LastName = "Doe",
                PhoneNumber = "098765432"
            });

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
