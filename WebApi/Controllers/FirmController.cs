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
    [ApiController]
    [Route(API+ "[controller]")]
    public  partial class FirmController:WebControllerBase
    {
       
         
        /// <summary>
        /// создание фирмы
        /// </summary>
 
        [ProducesResponseType(typeof(ErrorData), 400)]
        [ProducesResponseType(typeof(CreatedResultData), 200)]
        [HttpPost][Route("add")]
        public async Task <CreatedResultData> FirmCreate( FirmCreateData data) =>await Firm().FirmCreate(data);

         
        /// <summary>
        /// деактивация учётной записи фирмы
        /// </summary>
 
        [ProducesResponseType(typeof(ErrorData), 400)]
        [ProducesResponseType(typeof(DeleteResultData), 200)]
        [HttpPost][Route("delete")]
        public async Task <DeleteResultData> FirmDelete( FirmDeleteData data) =>await Firm().FirmDelete(data);

         
        /// <summary>
        /// редактирование фирмы
        /// </summary>
 
        [ProducesResponseType(typeof(ErrorData), 400)]
        [ProducesResponseType(typeof(CreatedResultData), 200)]
        [HttpPost][Route("update")]
        public async Task <CreatedResultData> FirmEdit( FirmEditData data) =>await Firm().FirmEdit(data);

         
        /// <summary>
        /// список фирм
        /// </summary>
 
        [ProducesResponseType(typeof(ErrorData), 400)]
        [ProducesResponseType(typeof(List<FirmData>), 200)]
        [HttpGet][Route("")]
        public async Task <List<FirmData>> FirmList(  ) =>await Firm().FirmList();


    }
}