﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceService4
{
    public class InvoiceService
    {
        const int COST_PER_KM = 10;
        const int COST_PER_MINUTE = 1;
        const int MINIMUM_FAIR = 5;
        List<Ride> rides = new List<Ride>();
        RideRepository RideRepository = new RideRepository();
        public double CalculateFair(double distance, int time)
        {
            var fair = (distance * COST_PER_KM) + (time * COST_PER_MINUTE);
            if (fair > MINIMUM_FAIR)
            {
                return fair;
            }
            return MINIMUM_FAIR;
        }

        public void AddRide(string userId, double distance, int time)
        {
            var userRides = RideRepository.GetRideByUserId(userId);
            if (userRides == null)
            {
                var userride = new List<Ride>();
                userride.Add(new Ride()
                {
                    distance = distance,
                    time = time
                });
                RideRepository.AddRideInRideRepo(userId, userride);
            }
            else
            {
                userRides.Add(new Ride()
                {
                    distance = distance,
                    time = time
                });
                RideRepository.AddRideInRideRepo(userId, userRides);
            }
        }

        public InvoiceSumary CalculateAggregate(String userId)
        {
            var userRides = RideRepository.GetRideByUserId(userId);
            double fair = 0;
            foreach (Ride ride in userRides)
            {
                fair += CalculateFair(ride.distance, ride.time);
            }
            var summary = new InvoiceSumary()
            {
                TotalNoOfRides = userRides.Count,
                AvgFair = fair / userRides.Count,
                TotalFair = fair
            };
            return summary;
        }
    }
}
