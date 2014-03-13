using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusLaneDatabase.Entities;

namespace BusLaneDatabase.Models
{
    public class BusLaneModel
    {
        public virtual int Id { get; set; }
        //TODO: add formatting for buslaneId as XXn, where XX= borough code, n = up to 3 digit number
        public virtual string buslaneId { get; set; }
        //TODO: add restriction on possible values
        public virtual string colour { get; set; }
        private Dictionary<string, IList<OperatingPeriod>> operatingtimes;

       //Each bus lane has a dictionary of 8 length containing a list of times for each day of the week. 
       // The 8th item is optional for 'event days'

        // need to handle more than one operating time per day and ensure they do not overlap
        // need to check for null operating time on a particular day
        // need to check timespans are not negative and less than 24 hrs

        public void SetOperatingTimesFor(string day, TimeSpan starttime, double duration)
        {
            operatingtimes = new Dictionary<string, IList<OperatingPeriod>>();
            List<OperatingPeriod> operatingtime = new List<OperatingPeriod>();
            OperatingPeriod operatingperiod = new OperatingPeriod();
            operatingperiod.starttime = starttime;
            operatingperiod.duration = duration;
            operatingtime.Add(operatingperiod);
            operatingtimes[day] = operatingtime; 
        }

        public OperatingPeriod GetOperatingPeriodFor(string day)
        {
            IList<OperatingPeriod> operatingtime;
            //Operational time may be blank for a day, so..
            if (operatingtimes.TryGetValue(day, out operatingtime))
            { 
                return operatingtime[0];
            }
            else 
            {
                return new OperatingPeriod();
            }
        }  
    }
}