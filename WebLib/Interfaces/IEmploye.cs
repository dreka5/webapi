using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using WebLib;
   #pragma warning disable IDE1006 // Стили именования
public partial interface IEmploye
{
    /// <summary>
    /// создание учётной записи работника
    /// </summary>
    Task<CreatedResultData> EmployeCreate(EmployeCreateData data);
    /// <summary>
    /// деактивация учётной записи работника
    /// </summary>
    Task<DeleteResultData> EmployeDelete(EmployeDeleteData data);
    /// <summary>
    /// список сотрудников
    /// </summary>
    Task<List<EmployeData>> EmployeListGet(EmployeFilter data);
    /// <summary>
    /// список сотрудников
    /// </summary>
    Task<CreatedResultData> EmployeUpdate(EmployeUpdateData data);
}
