﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultipleRides2
{
    public class MultipleRide
    {
        const int COST_PER_KM = 10;
        const int COST_PER_MINUTE = 1;
        const int MINIMUM_FAIR = 5;
        List<Rides> rides = new List<Rides>();

        public double CalculateFair(double distance, int time)
        {
            var fair = (distance * COST_PER_KM) + (time * COST_PER_MINUTE);
            if (fair > MINIMUM_FAIR)
            {
                return fair;
            }
            return MINIMUM_FAIR;
        }

        public void AddRide(double distance, int time)
        {
            rides.Add(new Rides()
            {
                distance = distance,
                time = time
            });
        }

        public double CalculateAggregate()
        {
            double fair = 0;
            foreach (Rides ride in rides)
            {
                fair += CalculateFair(ride.distance, ride.time);
            }
            return fair;
        }
    }
}