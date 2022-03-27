using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FareCalculate
{
    public class CalculateFare
    {
        const int COST_PER_KM = 10;
        const int COST_PER_MINUTE = 1;
        const int MINIMUM_FAIR = 5;

        public double CalculateFair(double distance, int time)
        {
            var fair = (distance * COST_PER_KM) + (time * COST_PER_MINUTE);
            if (fair > MINIMUM_FAIR)
            {
                return fair;
            }
            return MINIMUM_FAIR;
        }
    }
}
