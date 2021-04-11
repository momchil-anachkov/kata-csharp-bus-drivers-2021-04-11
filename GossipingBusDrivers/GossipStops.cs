using System.Collections.Generic;
using System.Linq;

namespace GossipingBusDrivers
{
    public class GossipStops
    {
        static public int Calculate(int[][] busRoutes)
        {
            HashSet<int> distinctStops = DistinctStops(busRoutes);
            HashSet<int>[] gossips = InitGossips(busRoutes);

            int minutesPassed = 0;
            bool everyoneKnowsEverything = false;
            while (minutesPassed < 480)
            {
                var currentStops = CalculateCurrentStops(busRoutes, minutesPassed);

                foreach (var stop in distinctStops)
                {
                    var driversAtStop = GetDriversAtStop(currentStops, stop);
                    Gossip(driversAtStop, gossips);
                }

                minutesPassed += 1;

                if (EveryoneHasMetEveryone(gossips))
                {
                    break;
                }
            }

            return minutesPassed;
        }

        private static void Gossip(List<int> driversAtStop, HashSet<int>[] driversMet)
        {
            foreach (var driver in driversAtStop)
            {
                foreach (var otherDriver in driversAtStop)
                {
                    foreach (var gossip in driversMet[otherDriver])
                    {
                        driversMet[driver].Add(gossip);
                    }
                }
            }
        }

        private static List<int> GetDriversAtStop(int[] currentStops, int stop)
        {
            List<int> driversAtStop = new List<int>();
            for (int driver = 0; driver < currentStops.Length; driver++)
            {
                if (currentStops[driver] == stop)
                {
                    driversAtStop.Add(driver);
                }
            }

            return driversAtStop;
        }

        private static int[] CalculateCurrentStops(int[][] busRoutes, int iterations)
        {
            int[] currentStops = busRoutes.Select(route => route[iterations % route.Length]).ToArray();
            return currentStops;
        }

        private static HashSet<int>[] InitGossips(int[][] busRoutes)
        {
            HashSet<int>[] driversMet = new HashSet<int>[busRoutes.Length];
            for (int i = 0; i < driversMet.Length; i++)
            {
                driversMet[i] = new HashSet<int>();
                driversMet[i].Add(i);
            }

            return driversMet;
        }

        private static bool EveryoneHasMetEveryone(HashSet<int>[] driverMeetings)
        {
            bool everyoneHasMetEveryone = true;
            foreach (var driver in driverMeetings)
            {
                everyoneHasMetEveryone &= driver.Count == driverMeetings.Length;
            }
            return everyoneHasMetEveryone;
        }

        private static HashSet<int> DistinctStops(int[][] busRoutes)
        {
            HashSet<int> distinctStops = new HashSet<int>();
            foreach (int[] route in busRoutes)
            {
                foreach (int stop in route)
                {
                    distinctStops.Add(stop);
                }
            }

            return distinctStops;
        }
    }
}