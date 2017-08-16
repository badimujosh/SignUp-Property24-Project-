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
using SignUp.Models;

namespace SignUp.Controllers
{
    public class tbPropertiesController : ApiController
    {
        private prop24Entities db = new prop24Entities();

        // GET: api/tbProperties
        public IQueryable<tbProperty> GettbProperties()
        {
            return db.tbProperties;
        }

        // GET: api/tbProperties/5
        [ResponseType(typeof(tbProperty))]
        public IHttpActionResult GettbProperty(int id)
        {
            tbProperty tbProperty = db.tbProperties.Find(id);
            if (tbProperty == null)
            {
                return NotFound();
            }

            return Ok(tbProperty);
        }

        // PUT: api/tbProperties/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PuttbProperty(int id, tbProperty tbProperty)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tbProperty.Prop_ID)
            {
                return BadRequest();
            }

            db.Entry(tbProperty).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbPropertyExists(id))
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

        // POST: api/tbProperties
        [ResponseType(typeof(tbProperty))]
        public IHttpActionResult PosttbProperty(tbProperty tbProperty)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            tbProperty.Prop_ID = new Random().Next();
            db.tbProperties.Add(tbProperty);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (tbPropertyExists(tbProperty.Prop_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = tbProperty.Prop_ID }, tbProperty);
        }

        // DELETE: api/tbProperties/5
        [ResponseType(typeof(tbProperty))]
        public IHttpActionResult DeletetbProperty(int id)
        {
            tbProperty tbProperty = db.tbProperties.Find(id);
            if (tbProperty == null)
            {
                return NotFound();
            }

            db.tbProperties.Remove(tbProperty);
            db.SaveChanges();

            return Ok(tbProperty);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tbPropertyExists(int id)
        {
            return db.tbProperties.Count(e => e.Prop_ID == id) > 0;
        }
    }
}