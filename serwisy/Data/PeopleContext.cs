using Microsoft.EntityFrameworkCore;
using serwisy.Models;

namespace serwisy.Data
{
    public class PeopleContext : DbContext
    {
        public PeopleContext(DbContextOptions options) : base(options) { }
        public DbSet<People> People { get; set; }
    }
}
