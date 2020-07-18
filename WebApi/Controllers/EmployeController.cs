using WebApi;
using WebLib;
using WebLib.TechData.Error;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace WebApi
{
    /// <summary>
    /// Контроллер работника
    /// </summary>
    [ApiController]
    [Route(API+ "[controller]")]
    public  partial class EmployeController:WebControllerBase
    {
       
        
        /// <summary>
        /// создание учётной записи работника
        /// </summary>

        [ProducesResponseType(typeof(ErrorData), 400)]
        [ProducesResponseType(typeof(CreatedResultData), 200)]
        [HttpPost][Route("employe/add")]
        public async Task <CreatedResultData> EmployeCreate( EmployeCreateData data) =>await Employe().EmployeCreate(data);

         
        /// <summary>
        /// деактивация учётной записи работника
        /// </summary>
 
        [ProducesResponseType(typeof(ErrorData), 400)]
        [ProducesResponseType(typeof(DeleteResultData), 200)]
        [HttpPost][Route("employe/delete")]
        public async Task <DeleteResultData> EmployeDelete( EmployeDeleteData data) =>await Employe().EmployeDelete(data);

         
        /// <summary>
        /// список сотрудников
        /// </summary>
 
        [ProducesResponseType(typeof(ErrorData), 400)]
        [ProducesResponseType(typeof(List<EmployeData>), 200)]
        [HttpGet][Route("employe")]
        public async Task <List<EmployeData>> EmployeListGet([FromQuery] EmployeFilter data) =>await Employe().EmployeListGet(data);


    }
}