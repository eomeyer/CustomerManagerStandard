using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using CustomerManagerStandard.Models;
using CustomerManagerStandard.Repository;

namespace CustomerManagerStandard.Controllers
{
    public class TitlesAPIController : ApiController
    {
        private CustomerManagerContext db = new CustomerManagerContext();

        // GET api/TitlesAPI
        public IQueryable<Title> GetTitles()
        {
            return db.Titles;
        }

        // GET api/TitlesAPI/5
        [ResponseType(typeof(Title))]
        public IHttpActionResult GetTitle(int id)
        {
            Title title = db.Titles.Find(id);
            if (title == null)
            {
                return NotFound();
            }

            return Ok(title);
        }

        // PUT api/TitlesAPI/5
        public IHttpActionResult PutTitle(int id, Title title)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != title.ID)
            {
                return BadRequest();
            }

            db.Entry(title).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TitleExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST api/TitlesAPI
        [ResponseType(typeof(Title))]
        public IHttpActionResult PostTitle(Title title)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Titles.Add(title);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = title.ID }, title);
        }

        // DELETE api/TitlesAPI/5
        [ResponseType(typeof(Title))]
        public IHttpActionResult DeleteTitle(int id)
        {
            Title title = db.Titles.Find(id);
            if (title == null)
            {
                return NotFound();
            }

            db.Titles.Remove(title);
            db.SaveChanges();

            return Ok(title);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TitleExists(int id)
        {
            return db.Titles.Count(e => e.ID == id) > 0;
        }
    }
}