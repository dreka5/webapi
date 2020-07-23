using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using WebLib.DB.Catalog;
using WebLib.Entity;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
namespace WebLib
{
    public abstract class CommonMain
    {

        /// <summary>
        /// объект для работы с сущностью работник
        /// </summary>
        /// <returns></returns>
        protected EmployeEnity EmployeEnity()
        {
            var db = ServiceProvider.GetService<CatalogContext>();
            return  new EmployeEnity(db);
        }

        protected FirmEntity FirmEntity()
        {
            var db = ServiceProvider.GetService<CatalogContext>();
            return new FirmEntity(db);
        }

        protected T GetService<T>()=> this.ServiceProvider.GetService<T>();
        public IServiceProvider ServiceProvider { get; set; }
        public ClaimsPrincipal User { get; set; }

        protected T DeserializeObject<T>(string json)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(json);
        }
        protected string SerializeObject(object data)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }
    }
}
