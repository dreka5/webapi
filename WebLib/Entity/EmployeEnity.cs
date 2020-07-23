using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WebLib.DB.Catalog;

namespace WebLib.Entity
{
    public class EmployeEnity:BaseEntity
    {
        public EmployeEnity(CatalogContext context) => DBContext = context ;
        /// <summary>
        /// список сотрудников 
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>

        public async Task<List<EmployeData>> ListGet(EmployeFilter filter)
        {
            using (var db = DBContext)
            {
                var list = from em in db.Employe
                           orderby em.SurName, em.Name
                           select new EmployeData
                           {
                               name = em.Name,
                               address = em.Address,
                               birthDay = em.BirthDay,
                               id = em.EmployeId,
                               lastName = em.LastName,
                               surName = em.SurName,
                                fid=em.fid 
                           };
                if (filter.surName != null)
                    list = list.Where(x => x.surName.ToLower().Contains(filter.surName.ToLower()));
                if (filter.name != null)
                    list = list.Where(x => x.name.ToLower().Contains(filter.name.ToLower()));
                return await list.ToListAsync();
            }
        }
        /// <summary>
        /// деактивация записи
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public async Task<DeleteResultData> Delete(EmployeDeleteData data)
        {
            using (var db = DBContext)
            {
                var employe=db.Employe.Where(x => x.EmployeId == data.id).FirstOrDefault();
                employe.State = RecordState.DELETED;
                await db.SaveChangesAsync();
                return new DeleteResultData();
            }
        }
        /// <summary>
        /// создание записи
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public async Task<CreatedResultData> Create(EmployeCreateData data)
        {
            using (var db = DBContext)
            {
                DateTime smalDay;
                //на базе лучше поставить смалл тайм
                if (!DateTime.TryParse(data.birthDay.ToShortDateString(), out smalDay))
                    smalDay = data.birthDay;
                var employe = new DB.Catalog.Employe()
                {
                    Name = data.name,
                    Address = data.address,
                    BirthDay = smalDay,
                    LastName = data.lastName,
                    SurName = data.surName,
                    State=RecordState.ACTIVE
                };
                db.Add(employe);
                await db.SaveChangesAsync();
                return new CreatedResultData() { createdId = employe.EmployeId };
            }
        }
        public async Task<CreatedResultData> Update(EmployeUpdateData updateData)
        {
            using (var db = DBContext)
            {
                var employe = db.Employe.Where(x => x.EmployeId == updateData.id).FirstOrDefault();
                //employe.Address = data.address;
                employe.BirthDay = updateData.birthDay;
                employe.SurName = updateData.surName;
                employe.Name = updateData.name;
                employe.LastName = updateData.lastName;
                employe.fid = updateData.fid;
                await db.SaveChangesAsync();
                return new CreatedResultData() { createdId=updateData.id };
            }
        }
    }
}
