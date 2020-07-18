using System;

namespace WebLib
{
#pragma warning disable IDE1006 // Стили именования
    /// <summary>
    /// Создание работника. необходимые данные
    /// </summary>
    public partial class EmployeCreateData
    {
        /// <summary>
        /// Имя 
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// Фамилия
        /// </summary>
        public string surName { get; set; }
        /// <summary>
        /// отчество
        /// </summary>
        public string lastName { get; set; }
        /// <summary>
        /// дата рождения
        /// </summary>
        public DateTime birthDay { get; set; }
        public string address { get; set; }
    }
}
