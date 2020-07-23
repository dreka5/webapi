using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebLib.DB.Catalog
{
    public class Firm
    {
        
        [Key]
        public Int32 Fid { get; set; }
        public String Name { get; set; }
        public String INN { get; set; }
        public String Address { get; set; }
        public Int32 State { get; set; }

    }
}