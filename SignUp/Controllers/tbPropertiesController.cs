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
using System.Web;
using System.IO;

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
        public IHttpActionResult PosttbProperty()
        {
            tbProperty tbProperty= new tbProperty();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            HttpFileCollection files = HttpContext.Current.Request.Files;
           
            string myData = HttpContext.Current.Request.Url.AbsoluteUri;

            for (int i=0; i<files.Count; i++)
            {
                HttpPostedFile file = files[i];

                if (file.ContentLength>0)
                {
                    Byte[] buffer = new Byte[file.ContentLength];
                    file.InputStream.Read(buffer, 0, file.ContentLength);
                    tbProperty.Photo = buffer;



                }
            }



            tbProperty.Prop_ID = new Random().Next();
            tbProperty.Description = myData.Split('?')[1].Split('&')[0].Split('=')[1];
            tbProperty.NumOfBed =Convert.ToDecimal( myData.Split('?')[1].Split('&')[1].Split('=')[1]);
            tbProperty.NumOfBath = Convert.ToInt32(myData.Split('?')[1].Split('&')[2].Split('=')[1]);
            tbProperty.NumOfGarage = Convert.ToInt32(myData.Split('?')[1].Split('&')[3].Split('=')[1]);
            tbProperty.FloorSize = Convert.ToDecimal(myData.Split('?')[1].Split('&')[4].Split('=')[1]);
            tbProperty.Price = Convert.ToDecimal(myData.Split('?')[1].Split('&')[5].Split('=')[1]);
            tbProperty.PropertySize = Convert.ToDecimal(myData.Split('?')[1].Split('&')[6].Split('=')[1]);
            tbProperty.Category = myData.Split('?')[1].Split('&')[7].Split('=')[1];
            tbProperty.Monthly_Levy = Convert.ToDecimal(myData.Split('?')[1].Split('&')[8].Split('=')[1]);
            tbProperty.Monthly_Rate = Convert.ToDecimal(myData.Split('?')[1].Split('&')[9].Split('=')[1]);
            tbProperty.PriceTerm = myData.Split('?')[1].Split('&')[10].Split('=')[1];
            tbProperty.OccupationDate = Convert.ToDateTime(myData.Split('?')[1].Split('&')[11].Split('=')[1]);
            tbProperty.Agent_ID = Convert.ToInt32(myData.Split('?')[1].Split('&')[12].Split('=')[1]);
            tbProperty.Street = myData.Split('?')[1].Split('&')[13].Split('=')[1];
            tbProperty.City = myData.Split('?')[1].Split('&')[14].Split('=')[1];

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