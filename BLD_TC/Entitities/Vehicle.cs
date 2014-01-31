using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BLD_TC.Entitities
{
    public class Vehicle
    {
        [ScaffoldColumn(false)]
        public int ID { get; set; }
        [DisplayName("Vehicle Type")]
        public string type { get; set; }
    }
}