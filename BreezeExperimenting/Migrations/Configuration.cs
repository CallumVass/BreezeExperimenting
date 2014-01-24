using BreezeExperimenting.Models;
using System.Data.Entity.Migrations;

namespace BreezeExperimenting.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<BreezeContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BreezeContext context)
        {
            context.People.AddOrUpdate(x => x.Id,
                            new Person { Id = 1, FirstName = "John", LastName = "Papa", Age = 25, Location = "Florida" },
                            new Person { Id = 2, FirstName = "Ward", LastName = "Bell", Age = 31, Location = "California" },
                            new Person { Id = 3, FirstName = "Colleen", LastName = "Jones", Age = 21, Location = "New York" },
                            new Person { Id = 4, FirstName = "Madelyn", LastName = "Green", Age = 18, Location = "North Dakota" },
                            new Person { Id = 5, FirstName = "Ella", LastName = "Jobs", Age = 18, Location = "South Dakota" },
                            new Person { Id = 6, FirstName = "Landon", LastName = "Gates", Age = 11, Location = "South Carolina" },
                            new Person { Id = 7, FirstName = "Haley", LastName = "Guthrie", Age = 35, Location = "Wyoming" }
                        );
        }
    }
}
