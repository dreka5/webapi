using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi
{
    public class WebControllerBase: ControllerBase
    {
     
        /// <summary>
        /// константа API для роутинга  
        /// </summary>
        protected const string API = "api/v1.0/";

        
        protected WebLib.Employe Employe()
        {
            var E = new WebLib.Employe() { User = User, ServiceProvider= HttpContext.RequestServices };
            return E;
        }

        protected WebLib.Firm Firm()
        {
            var F = new WebLib.Firm() { User = User, ServiceProvider = HttpContext.RequestServices };
            return F;
        }
    }
}
