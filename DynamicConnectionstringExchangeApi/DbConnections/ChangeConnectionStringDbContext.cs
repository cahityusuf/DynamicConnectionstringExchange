using DynamicConnectionstringExchangeApi.Models;
using DynamicConnectionstringExchangeApi.Services;
using Microsoft.EntityFrameworkCore;

namespace DynamicConnectionstringExchangeApi.DbConnections
{
    public class ChangeConnectionStringDbContext : DbContext
    {
        private readonly IConnectionStringProvider _connectionStringProvider;

        public ChangeConnectionStringDbContext(IConnectionStringProvider connectionStringProvider)
        {
            _connectionStringProvider = connectionStringProvider;
        }
        public DbSet<TestModel> TestModel { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionStringProvider.GetConnectionString());
        }
    }

}
