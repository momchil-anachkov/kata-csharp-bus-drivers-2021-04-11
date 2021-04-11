using NUnit.Framework;
using GossipingBusDrivers;

namespace GossipingBusDriversTest
{
    public class GossipingBusDriversTest
    {
        
        /*
         * There is no way to express many of these tests verbally, so just look at the data
         */

        [Test]
        public void Test1()
        {
            int[][] busRoutes =
            {
                new []{ 1 },
                new []{ 1 }
            };
            
            Assert.AreEqual(1, GossipStops.Calculate(busRoutes));
        }
        
        [Test]
        public void Test2()
        {
            int[][] busRoutes =
            {
                new []{ 1, 2 },
                new []{ 2 }
            };
            
            Assert.AreEqual(2, GossipStops.Calculate(busRoutes));
        }
        
        [Test]
        public void Test3()
        {
            int[][] busRoutes =
            {
                new []{ 1, 2 },
                new []{ 2, 1 }
            };
            
            Assert.AreEqual(480, GossipStops.Calculate(busRoutes));
        }
        
        [Test]
        public void Test4()
        {
            int[][] busRoutes =
            {
                new []{ 1, 2, 3 },
                new []{ 2, 1 }
            };
            
            Assert.AreEqual(4, GossipStops.Calculate(busRoutes));
        }
        
        [Test]
        public void Test5()
        {
            int[][] busRoutes =
            {
                new []{ 1, 2, 3 },
                new []{ 2, 1, 3 }
            };
            
            Assert.AreEqual(3, GossipStops.Calculate(busRoutes));
        }
        
        [Test]
        public void Test6()
        {
            int[][] busRoutes =
            {
                new []{ 1, 2, 3 },
                new []{ 2, 1, 3 },
                new []{ 2, 1, 5, 7 }
            };
            
            Assert.AreEqual(5, GossipStops.Calculate(busRoutes));
        }
        
        [Test]
        public void Test7()
        {
            int[][] busRoutes =
            {
                new []{ 1, 2, 3 },    // 1, 2, 3
                new []{ 2, 1, 3 },    // 1, 2, 3
                new []{ 2, 1, 5, 7 }, // 1, 2, 3
                new []{ 3, 5, 7, 8 },
            };
            
            Assert.AreEqual(10, GossipStops.Calculate(busRoutes));
        }
    }
}