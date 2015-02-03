namespace CustomerManagerStandard.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CustomerManagerStandard.Repository.CustomerManagerContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(CustomerManagerStandard.Repository.CustomerManagerContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.Titles.AddOrUpdate(
              p => p.Name,
              new Models.Title { Name = "Mr" },
              new Models.Title { Name = "Mrs" },
              new Models.Title { Name = "Ms" },
              new Models.Title { Name = "Miss"},
              new Models.Title { Name = "Prof"},
              new Models.Title { Name = "Dr"}
            );

            context.Cutomers.AddOrUpdate(
                p => p.ID,
                new Models.Customer { ContactNumber="0824506035", Email="eckard@kaizenit.net", FirstName="Eckard", ID=1, Surname="Meyer", TitleID=1, Gender=Models.Gender.Male }
                );
            
        }
    }
}
