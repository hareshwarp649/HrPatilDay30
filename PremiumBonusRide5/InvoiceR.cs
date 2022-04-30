using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremiumBonusRide5
{
    public class InvoiceR
    {
        const int Cost_per_km=10;
        const int Cost_per_minute = 1;
        const int Minimum_fair = 5;

        List<Ride> rides = new List<Ride>();
        RRepository RRepository = new RRepository();
        public double CalculateFair(double distance , int time)
        {
            var fair = (distance * Cost_per_km) + (time * Cost_per_minute);
            if(fair > Minimum_fair)
            {
                return fair;
            }
            return Minimum_fair;
        }
        public double CalculateFair(double distance ,int time ,RType type)
        {
            var fair = (distance * Cost_per_km) + (time * Cost_per_minute);
            if (fair > Minimum_fair)
            {
                return fair;

            }
            return Minimum_fair;
        }
        public void AddRide(string userId , double distance, int time)
        {
            var userRides = RRepository.GetRideByUserId(userId);
            if(userRides == null)
            {
                var userride = new List<Ride>();
                userride.Add(new Ride()
                {
                    distance = distance,
                    time = time
                });
                RRepository.AddRideInRRepo(userId, userride);       
            }
            else
            {
                userRides.Add(new Ride()
                {
                    distance = distance,
                    time = time,
                   
                });
                RRepository.AddRideInRRepo(userId, userRides);

            }
        }
        public void AddRide(RType rType,string userId, double distance, int time)
        {
            var userRides = RRepository.GetRideByUserId(userId);
            if(userId == null)
            {
                var userrides = new List<Ride>();
                userrides.Add(new Ride()
                {
                    distance =distance,
                    time = time,
                    type= rType
                });
                RRepository.AddRideInRRepo(userId, userrides);

            }

            else
            {
                userRides.Add(new Ride()
                {
                    distance = distance,
                    time = time,
                    type = rType
                });
                RRepository.AddRideInRRepo(userId, userRides);
            }
        }
        public InvoiceSummary GetInvoiceSummary(String userId)
        {
            var userRides = RRepository.GetRideByUserId(userId);
            double fair = 0;
            foreach(Ride ride in userRides)
            {
                fair += CalculateFair(ride.distance, ride.time, ride.type);
            }
            var summary = new InvoiceSummary()
            {
                TotalNoOfRides = userRides.Count,
                AvgFair = fair / userRides.Count,
                TotalFair = fair
            };
            return summary;
        }

    }
}
