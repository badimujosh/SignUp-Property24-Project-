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
using System.Web.Mvc;


namespace SignUp.Controllers
{
    

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'tbAgentsController'
    public class tbAgentsController : ApiController
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'tbAgentsController'
    {
        private prop24Entities db = new prop24Entities();

        // GET: api/tbAgents
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'tbAgentsController.GettbAgents()'
      /* public IQueryable<tbAgent> GettbAgents()
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'tbAgentsController.GettbAgents()'
        {
            return db.tbAgents;
        }*/

        // GET: api/tbAgents/5
        [ResponseType(typeof(tbAgent))]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'tbAgentsController.GettbAgent(tbAgent)'
        public IHttpActionResult GettbAgent(string Username, string Password)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'tbAgentsController.GettbAgent(tbAgent)'
        {
            /*
            tbAgent = db.tbAgents.Find(Username,pass);
           
            */
           var objLogin= db.tbAgents.Where(a => a.Email.Equals(Username) && a.Password.Equals(Password)).FirstOrDefault();
            
            if (objLogin.Email== null && objLogin.Password == null)
            {
                return null;
            }

            return Ok(objLogin); 
        }

        // PUT: api/tbAgents/5
        [ResponseType(typeof(void))]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'tbAgentsController.PuttbAgent(int, tbAgent)'
        public IHttpActionResult PuttbAgent(tbAgent tbAgent)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'tbAgentsController.PuttbAgent(int, tbAgent)'
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var objUpdate = db.tbAgents.Where(a => a.Agent_ID == tbAgent.Agent_ID).FirstOrDefault<tbAgent>();
            if (objUpdate!=null)
            {
                objUpdate.FirstName = tbAgent.FirstName;
                objUpdate.LastName = tbAgent.LastName;
                objUpdate.Password = tbAgent.Password;
                objUpdate.MobileNum = tbAgent.MobileNum;
                objUpdate.Agent_ID = tbAgent.Agent_ID;
                objUpdate.Role = tbAgent.Role;
                objUpdate.Email = tbAgent.Email;
                db.SaveChanges();
            } 
            else 
            {
                return NotFound();
            }

            return Ok();
        }

        // POST: api/tbAgents
        [ResponseType(typeof(tbAgent))]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'tbAgentsController.PosttbAgent(tbAgent)'
        public IHttpActionResult PosttbAgent(tbAgent tbAgent)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'tbAgentsController.PosttbAgent(tbAgent)'
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            tbAgent.Agent_ID = new Random().Next();
            db.tbAgents.Add(tbAgent);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (tbAgentExists(tbAgent.Agent_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = tbAgent.Agent_ID }, tbAgent);
        }

        // DELETE: api/tbAgents/5
        [ResponseType(typeof(tbAgent))]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'tbAgentsController.DeletetbAgent(int)'
        public IHttpActionResult DeletetbAgent(int id)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'tbAgentsController.DeletetbAgent(int)'
        {
            tbAgent tbAgent = db.tbAgents.Find(id);
            if (tbAgent == null)
            {
                return NotFound();
            }

            db.tbAgents.Remove(tbAgent);
            db.SaveChanges();

            return Ok(tbAgent);
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'tbAgentsController.Dispose(bool)'
        protected override void Dispose(bool disposing)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'tbAgentsController.Dispose(bool)'
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tbAgentExists(int id)
        {
            return db.tbAgents.Count(e => e.Agent_ID == id) > 0;
        }
    };


   


}