using System;
using Lab5.BL;
using Lab5.BL.Controllers;

namespace Lab5.Drawers
{
    public class StandartTrafficLightDrawer : TrafficLightDrawerBase
    {
        public StandartTrafficLightDrawer(int leftOffset, int topOffset, ITrafficLight trafficLight)
            : base(leftOffset, topOffset, trafficLight, PrepareConsole)
        {
        }


        protected override Point GetPosition(string lightName)
        {
            switch (lightName)
            {
                case StandartTrafficLightController.GreenLightName:
                    return new Point(0, 2);
                case StandartTrafficLightController.YellowLightName:
                    return new Point(0, 1);
                case StandartTrafficLightController.RedLightName:
                    return new Point(0, 0);
                default:
                    throw new ArgumentOutOfRangeException(nameof(lightName), lightName, null);
            }
        }

        protected override ConsoleColor GetColor(string lightName)
        {
            switch (lightName)
            {
                case StandartTrafficLightController.GreenLightName:
                    return ConsoleColor.Green;
                case StandartTrafficLightController.YellowLightName:
                    return ConsoleColor.Yellow;
                case StandartTrafficLightController.RedLightName:
                    return ConsoleColor.Red;
                default:
                    throw new ArgumentOutOfRangeException(nameof(lightName), lightName, null);
            }
        }


        private static void PrepareConsole(Point zoneOffset)
        {
            Console.SetCursorPosition(zoneOffset.Left, zoneOffset.Top);
            Console.WriteLine(DefaultLightSymbol);
            Console.SetCursorPosition(zoneOffset.Left, zoneOffset.Top + 1);
            Console.WriteLine(DefaultLightSymbol);
            Console.SetCursorPosition(zoneOffset.Left, zoneOffset.Top + 2);
            Console.WriteLine(DefaultLightSymbol);
        }
    }
}