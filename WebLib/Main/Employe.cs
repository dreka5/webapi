using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebLib.DB.Catalog;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Net.Http;
using Newtonsoft.Json;
using WebLib.TechData;

namespace WebLib
{
    /// <summary>
    /// Класс для управления логикой контролера работник. может содержать не только CRUD
    /// </summary>
    public partial class Employe : CommonMain, IEmploye
    {
        public async Task<CreatedResultData> EmployeCreate(EmployeCreateData data)
        {
            return await EmployeEnity().Create(data);
        }
        /// <summary>
        /// Это не удаление , а деактивация. state=DELETED
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public async Task<DeleteResultData> EmployeDelete(EmployeDeleteData data)
        {
            return await EmployeEnity().Delete(data);
        }

        public async Task<List<EmployeData>> EmployeListGet(EmployeFilter data)
        {
            // TODO -> запустить в паралель 2 авейта
            var firmName = await GetService<IRemoteDataProvider>().GetFirm();
            var workers = await EmployeEnity().ListGet(data);

            if (firmName == null || firmName.Length == 0) return workers; 
            foreach(var w in workers)
            {
                var firm=firmName.Where(x => x.Fid == w.fid).FirstOrDefault();
                if (firm != null)
                    w.firmName = firm.Name;
            }
            return workers;
        }

        public async Task<CreatedResultData> EmployeUpdate(EmployeUpdateData data)
        {
            return await EmployeEnity().Update(data);
        }
    }
    
}