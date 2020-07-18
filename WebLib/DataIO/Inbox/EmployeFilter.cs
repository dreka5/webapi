using System;

namespace WebLib
{
#pragma warning disable IDE1006 // Стили именования
    /// <summary>
    /// Фильтр поиска сотрудника
    /// </summary>
    public partial class EmployeFilter
    {
        /// <summary>
        /// фильтр по имени
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// фильтр по фамилии
        /// </summary>
        public string surName { get; set; }
    }
}
