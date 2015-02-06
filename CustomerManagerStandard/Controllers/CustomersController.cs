﻿using CustomerManagerStandard.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.OData;

namespace CustomerManagerStandard.Controllers
{
    public class CustomersController : ODataController
    {
        Repository.CustomerManagerContext db = new Repository.CustomerManagerContext();

        [EnableQuery]
        public IQueryable<Customer> Get()
        {
            return db.Customers;
        }
        [EnableQuery]
        public SingleResult<Customer> Get([FromODataUri] int key)
        {
            IQueryable<Customer> result = db.Customers.Where(p => p.ID == key);
            return SingleResult.Create(result);
        }

        public async Task<IHttpActionResult> Post(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.Customers.Add(customer);
            await db.SaveChangesAsync();
            return Created(customer);
        }

        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<Customer> customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var entity = await db.Customers.FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }
            customer.Patch(entity);
            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Updated(entity);
        }
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Customer update)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (key != update.ID)
            {
                return BadRequest();
            }
            db.Entry(update).State = EntityState.Modified;
            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Updated(update);
        }

        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            var entity = await db.Customers.FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }
            db.Customers.Remove(entity);
            await db.SaveChangesAsync();
            return StatusCode(HttpStatusCode.NoContent);
        }


        private bool CustomerExists(int key)
        {
            return db.Customers.Any(p => p.ID == key);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }


    }
}