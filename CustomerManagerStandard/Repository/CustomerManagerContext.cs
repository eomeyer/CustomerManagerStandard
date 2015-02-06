using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CustomerManagerStandard.Repository
{
    public class CustomerManagerContext : DbContext
    {
        public CustomerManagerContext()
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }
        static CustomerManagerContext() 
        { 
        }
        public DbSet<Models.Customer> Customers { get; set; }
        public DbSet<Models.Title> Titles { get; set; }
    }
}