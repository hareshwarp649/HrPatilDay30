using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremiumBonusRide5
{
    internal class RRepository
    {
        public Dictionary<string, List <Ride>> userrides;
        public RRepository()
        {
            userrides = new Dictionary<string, List<Ride>>();

        }
        public void AddRideInRRepo(string userID, List<Ride> rides)
        {
            userrides[userID] = rides;
        }
        public List<Ride> GetRideByUserId(string userId)
        {
            try
            {
                return userrides[userId];
            }
            catch (Exception)
            {
                return null;
            }

        }
    }
}
