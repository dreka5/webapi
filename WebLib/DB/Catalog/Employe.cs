using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebLib.DB.Catalog
{
    public class Employe
    {
        
        [Key]
        public Int32 EmployeId { get; set; }
        public String SurName { get; set; }
        public String Name { get; set; }
        public String LastName { get; set; }
        public DateTime BirthDay { get; set; }
        public String Address { get; set; }
        public Int32 fid { get; set; }
        public Int32 State { get; set; }

    }
}