using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ShopMyPham_MVC.Framework
{
    [Table("IBeacon")]
    public class Beacon
    {
        [Key]
        public Int64 MacID { get; set; }
        public Int64 LocationX { get; set; }
        public Int64 LocationY { get; set; }
        public Int64 ShopID { get; set; }
        public String Information { get; set; }
        public String Name { get; set; }
    }
}