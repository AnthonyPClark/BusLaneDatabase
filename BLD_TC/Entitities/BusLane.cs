using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;

namespace BLD_TC.Entitities
{
    public class BusLane
    {
        [HiddenInput(DisplayValue = false)]
        public int ID { get; set; }
        [DataType(DataType.Date)]
        [DisplayName("Date Implemented")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Required]
        public DateTime implementationDate { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayName("Lane Start Time")]
        [DisplayFormat(DataFormatString = "{0:hh\\:mm}", ApplyFormatInEditMode = true)]
        //[Required]
        public DateTime startTime { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayName("Lane End Time")]
        [DisplayFormat(DataFormatString = "{0:hh\\:mm}", ApplyFormatInEditMode = true)]
       // [Required]
        public DateTime endTime { get; set; }
        [DisplayName("Allowed Vechicles")]
        //[Required]
        public List<Vehicle> vehicles { get; set; }
        [DisplayName("Lane Length")]
        [Required]
        public Double length { get; set; }
        [StringLength(500)]
        [DisplayName("Lane Description")]
        [Required]
        public String Description { get; set; }
        public Boolean removed { get; set; }
        public String removedBy { get; set; }
    }
}