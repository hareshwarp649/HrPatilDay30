using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremiumBonusRide5
{
    public class InvoiceSummary
    {
        public int TotalNoOfRides
        {
            get;
            set;
        }
        public double AvgFair { get; set; }
        public double TotalFair { get; set; }
    }
}
