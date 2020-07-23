using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;



namespace WebLib
{
    public partial class Firm : CommonMain, IFirm
    {
        public async Task<CreatedResultData> FirmCreate(FirmCreateData data)
        {
            return await FirmEntity().Create(data);
        }

        public async Task<DeleteResultData> FirmDelete(FirmDeleteData data)
        {
            return await FirmEntity().Delete(data);
        }

        public async Task<CreatedResultData> FirmEdit(FirmEditData data)
        {
            return await FirmEntity().Update(data);
        }

        public async Task<List<FirmData>> FirmList()
        {
            return await FirmEntity().ListGet();
        }
    }
}