using CepApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CepApi.Domain.Infra.Context
{
    public class MySqlContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public MySqlContext(DbContextOptions<MySqlContext> options) : base(options)
        {
        }
    }
}
