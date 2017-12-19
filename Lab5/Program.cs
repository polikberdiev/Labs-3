using System;
using System.Linq;
using Lab5.BL;
using Lab5.BL.Controllers;
using Lab5.DrawerFactory;

namespace Lab5
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            ITrafficLightDrawerFactory factory = new TrafficLightDrawerFactory();

            var trafficLights = new ITrafficLight[]
            {
                new PedestrianTrafficLightController(10, 4),
                new StandartTrafficLightController(5, 1, 10),
                new LeftSectionStandartTrafficLightController(4, 1, 6, 3), 
            };

            var drawers = trafficLights
                .Select((tl, i) => factory.Create(4, i * 6 + 1, tl));

            foreach (var trafficLightDrawer in drawers)
            {
                trafficLightDrawer.Start();
            }

            Console.ReadLine();
        }
    }
}