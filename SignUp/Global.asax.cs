using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Http;

namespace SignUp
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'Global'
    public class Global : HttpApplication
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'Global'
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
           /* var xml = GlobalConfiguration.Configuration.Formatters.XmlFormatter;
            xml.UseXmlSerializer = true;
            var json = GlobalConfiguration.Configuration.Formatters.JsonFormatter;
            json.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.All;*/
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);            
        }
    }
}