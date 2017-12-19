using System;
using Lab5.BL;
using Lab5.BL.Controllers;
using Lab5.Drawers;

namespace Lab5.DrawerFactory
{
    public class TrafficLightDrawerFactory : ITrafficLightDrawerFactory
    {
        public ITrafficLightDrawer Create(int leftOffset, int topOffset, ITrafficLight trafficLight)
        {
            switch (trafficLight.GetType().Name)
            {
                case nameof(StandartTrafficLightController):
                    return new StandartTrafficLightDrawer(leftOffset, topOffset, trafficLight);
                case nameof(PedestrianTrafficLightController):
                    return new PedestrianTrafficLightDrawer(leftOffset, topOffset, trafficLight);
                case nameof(LeftSectionStandartTrafficLightController):
                    return new LeftSectionStandartTrafficLightDrawer(leftOffset, topOffset, trafficLight);
                default:
                    throw new NotSupportedException();
            }
        }
    }
}