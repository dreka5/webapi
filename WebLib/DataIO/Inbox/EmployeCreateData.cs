using System;

namespace WebLib
{
   #pragma warning disable IDE1006 // Стили именования
   public partial class EmployeCreateData
   {
       public string surName { get; set; }
       public string name { get; set; }
       public string lastName { get; set; }
       public DateTime birthDay { get; set; }
       public string address { get; set; }
   }
}
