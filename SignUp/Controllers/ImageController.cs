using SignUp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace SignUp.Controllers
{
    public class ImageController : ApiController
      
    {
        private prop24Entities db = new prop24Entities();
        public HttpResponseMessage Post(tbImage Image)
        {
        if (ModelState.IsValid)
            {
                db.tbImages.Add(Image);
                db.SaveChanges();
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, Image);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = Image.FileName }));
                return response;
             }
        else
        {
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        }
    }


}
}
