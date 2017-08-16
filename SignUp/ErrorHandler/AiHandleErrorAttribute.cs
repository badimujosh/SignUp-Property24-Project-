using System;using System.Web.Mvc;using Microsoft.ApplicationInsights;namespace SignUp.ErrorHandler{    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true)] #pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'AiHandleErrorAttribute'
    public class AiHandleErrorAttribute : HandleErrorAttribute
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'AiHandleErrorAttribute'    {#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'AiHandleErrorAttribute.OnException(ExceptionContext)'
        public override void OnException(ExceptionContext filterContext)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'AiHandleErrorAttribute.OnException(ExceptionContext)'        {            if (filterContext != null && filterContext.HttpContext != null && filterContext.Exception != null)            {                //If customError is Off, then AI HTTPModule will report the exception                if (filterContext.HttpContext.IsCustomErrorEnabled)                {                       var ai = new TelemetryClient();                    ai.TrackException(filterContext.Exception);                }             }            base.OnException(filterContext);        }    }}