using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WebLib.DB.Catalog;
using WebLib.TechData;
using WebLib.TechData.Error;

namespace WebLib.Entity
{

    public class FirmEntity : BaseEntity
    {
        public FirmEntity(CatalogContext context) => DBContext = context;

        public async Task<List<FirmData>> ListGet()
        {
            using (var db = DBContext)
            {
                return  (await db.Firm.OrderBy(x => x.Name).ToListAsync()).T2TList<FirmData>();
            }
        }
        public async Task<CreatedResultData> Create(FirmCreateData data)
        {
            using (var db = DBContext)
            {
                var firm = data.T2T<DB.Catalog.Firm>();
                firm.State = RecordState.ACTIVE;
                db.Add(firm);
                await db.SaveChangesAsync();
                return new CreatedResultData() { createdId = firm.Fid };
            }
        }
        public async Task<CreatedResultData> Update(FirmEditData data)
        {
            using (var db = DBContext)
            {
                var firm= db.Firm.Where(x => x.Fid == data.Fid).FirstOrDefault();
                if (firm == null)
                    throw new WebLibException(ErrorList.NoFirm_102);
                DataConvert.Update(firm, data);
                await db.SaveChangesAsync();
                return new CreatedResultData() { createdId = firm.Fid };
            }
        }
        public async Task<DeleteResultData> Delete(FirmDeleteData data)
        {
            using (var db = DBContext)
            {
                var firm = db.Firm.Where(x => x.Fid == data.Fid).FirstOrDefault();
                firm.State = RecordState.DELETED;
                await db.SaveChangesAsync();
                return new DeleteResultData();
            }
        }
    }
}
