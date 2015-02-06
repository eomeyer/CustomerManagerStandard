using CustomerManagerStandard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerManagerStandard.Repository
{
    public class CustomerRepository
    {
        CustomerManagerContext _ctx;
        public CustomerRepository()
        {
            _ctx = new CustomerManagerContext();
        }

        public IQueryable<Customer> GetCustomers() 
        {
            var query = _ctx.Customers.OrderBy(o => o.Surname);
            return query.AsQueryable();
        } 


    }
}