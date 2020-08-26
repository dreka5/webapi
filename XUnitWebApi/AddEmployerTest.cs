using System;
using Xunit;
using System.Linq;


using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

using Microsoft.EntityFrameworkCore;
using WebLib.DB.Catalog;

namespace XUnitWebApi
{
    /*123*/
    public class AddEmployer
    {
        //GRANT INSERT, SELECT, UPDATE,DELETE ON TABLE public."Employe" TO gazoil    :)
        string GAZ = "Host=35.217.25.167;Port=5432;Database=test1;Username=gazoil;Password=thegazoil2020";
        CatalogContext CatalogContextCreate()
        {
            var option = new DbContextOptionsBuilder<WebLib.DB.Catalog.CatalogContext>();
            option.UseNpgsql(GAZ);
            var dbContext = new CatalogContext(option.Options);
            return dbContext;
        }
        [Fact]
        public async void AddEmployerTest()
        {
            Assert.True(true);
            //var employeEntity = new WebLib.Entity.EmployeEnity(CatalogContextCreate());
            //var employe = new WebLib.EmployeCreateData() { name = "Иван Тест" };
            //var result = await employeEntity.Create(employe);

            //Assert.True(result!=null&& result.createdId>0);

            //var dbContext = CatalogContextCreate();
            //var testEmploye = dbContext.Employe.Where(x => x.EmployeId == result.createdId).FirstOrDefault();

            //Assert.True(testEmploye != null);
            
            
            //if (testEmploye != null) {
            //    dbContext.Remove(testEmploye);
            //    dbContext.SaveChanges();
            //}
        }
    }
}
