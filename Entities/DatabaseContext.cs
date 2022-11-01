
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Entities
{
    public class DatabaseContext : DbContext
    {
        //private readonly IDatabaseRepository _db;

        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<QueryLog> QueryLogs { get; set; }
    }
}
