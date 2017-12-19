using Lab5.BL;
using Lab5.Drawers;

namespace Lab5.DrawerFactory
{
    public interface ITrafficLightDrawerFactory
    {
        ITrafficLightDrawer Create(int leftOffset, int topOffset, ITrafficLight trafficLight);
    }
}