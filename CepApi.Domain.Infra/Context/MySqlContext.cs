using CepApi.Domain.Entities;
using CepApi.Domain.Shared.Utils;
using Microsoft.EntityFrameworkCore;

namespace CepApi.Domain.Infra.Context
{
    public class MySqlContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public MySqlContext(DbContextOptions<MySqlContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var passwordHash = PasswordHash.Hash("1234");
            modelBuilder.Entity<User>().HasData(new User("Adm", "adm@gmail.com", passwordHash, "Administrator"));
        }
    }
}
