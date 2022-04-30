using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremiumBonusRide5
{
    public class RType
    {
        public int Cost_per_km = 0;
        public int Cost_Per_minute = 0;
        public int Minimum_fair = 0;

        public RType Normal = new RType()
        {
            Cost_per_km = 10,
            Cost_Per_minute = 1,
            Minimum_fair=0
        };

        public RType premium = new RType()
        {
            Cost_per_km = 15,
            Cost_Per_minute= 2,
            Minimum_fair =20

        };

       }
}
