using System.Data.Entity;

namespace BreezeExperimenting.Models
{
    public class BreezeContext : DbContext
    {
        public DbSet<Person> People { get; set; }
    }
}