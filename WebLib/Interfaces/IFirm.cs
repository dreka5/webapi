using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using WebLib;
   #pragma warning disable IDE1006 // Стили именования
public partial interface IFirm
{
    /// <summary>
    /// создание фирмы
    /// </summary>
    Task<CreatedResultData> FirmCreate(FirmCreateData data);
    /// <summary>
    /// деактивация учётной записи фирмы
    /// </summary>
    Task<DeleteResultData> FirmDelete(FirmDeleteData data);
    /// <summary>
    /// редактирование фирмы
    /// </summary>
    Task<CreatedResultData> FirmEdit(FirmEditData data);
    /// <summary>
    /// список фирм
    /// </summary>
    Task<List<FirmData>> FirmList();
}
