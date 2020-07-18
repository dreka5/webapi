using System;

namespace WebLib
{
#pragma warning disable IDE1006 // Стили именования
    /// <summary>
    /// данные работника наружу
    /// </summary>
    public partial class EmployeData
    {
        public int id { get; set; }
        public string surName { get; set; }
        public string name { get; set; }
        public string lastName { get; set; }
        public DateTime birthDay { get; set; }
        public string address { get; set; }
    }
}
