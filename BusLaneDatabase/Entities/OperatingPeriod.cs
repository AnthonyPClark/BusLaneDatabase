using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusLaneDatabase.Entities
{
    public struct OperatingPeriod
    {
        public TimeSpan starttime { get; set; }
        public  double duration { get; set; }
    }
}