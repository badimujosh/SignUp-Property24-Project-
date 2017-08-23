using SignUp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace SignUp.Controllers
{
    public class ImgUploadController : ApiController
    {
        [HttpPost]
        [Route("api/Image")]
        public String POST()
        {
            int counter = 0;

            //collection files
            System.Web.HttpFileCollection files = System.Web.HttpContext.Current.Request.Files;
            string url = HttpContext.Current.Request.Url.AbsoluteUri;
            tbImageProp obj = new tbImageProp();
            prop24Entities db = new prop24Entities();
            String Status = "";
            for (int i = 0; i < files.Count; i++)
            {

                //get the posted file
                System.Web.HttpPostedFile file = files[i];

                string fileName = new FileInfo(file.FileName).Name;

                String prop_ID = url.Split('=')[1];

                if (file.ContentLength > 0)
                {
                    Guid id = Guid.NewGuid();

                    string modifiedFileName = id.ToString() + "_" + fileName;

                    byte[] imageBuffer = new byte[file.ContentLength];
                    file.InputStream.Read(imageBuffer, 0, file.ContentLength);

                    obj.Prop_ID = Convert.ToInt32(prop_ID);
                    obj.ImageDetail = imageBuffer;
                    

                    counter++;




                }

            }

            if (counter > 0)
            {
                return Status;
            }
            return "Upload Failed";
        }
    }
}
