using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremiumRides5
{
    internal class RideRepository
    {
        public Dictionary<string, List<Ride>> userrides;

        public RideRepository()
        {
            userrides = new Dictionary<string, List<Ride>>();
        }
        public void AddRideInRideRepo(string userId, List<Ride> rides)
        {
            userrides[userId] = rides;
        }
        public List<Ride> GetRideByUserId(string userId)
        {
            try
            {
                return userrides[userId];
            }
            catch (Exception )
            {
                return null;
            }
        }
    }
}
