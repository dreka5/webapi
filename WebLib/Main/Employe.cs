using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebLib.DB.Catalog;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
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
            return await EmployeEnity().ListGet(data);
        }
    }
}