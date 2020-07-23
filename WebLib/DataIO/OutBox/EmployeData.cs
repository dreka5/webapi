using System;

namespace WebLib
{
   #pragma warning disable IDE1006 // Стили именования
   public partial class EmployeData
   {
       public int id { get; set; }
       public string surName { get; set; }
       public string name { get; set; }
       public string lastName { get; set; }
       public DateTime birthDay { get; set; }
       public string address { get; set; }

       public int fid { get; set; }
       public string firmName { get; set; }
    }
}
