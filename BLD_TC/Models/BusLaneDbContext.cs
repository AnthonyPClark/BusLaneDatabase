using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using BLD_TC.Entitities;

namespace BLD_TC.Models
{
    public class BusLaneDbContext: DbContext
    {
        public DbSet<Vehicle> vehicles { get; set; }
        public DbSet<BusLane> buslanes { get; set; }

        public DbSet<BusLaneEditModel> BusLaneEditModels { get; set; }
    }
}