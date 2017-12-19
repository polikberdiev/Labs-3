using System;

namespace Lab5.BL
{
    public interface ITrafficLight
    {
        event EventHandler<LightStateChangedEventArgs> LightStateChanged;


        void TurnOn();

        void TurnOff();
    }
}