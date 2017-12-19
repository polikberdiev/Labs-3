using System;

namespace Lab5.BL
{
    public class LightStateChangedEventArgs : EventArgs
    {
        public string LightName { get; }

        public bool IsOn { get; }


        public LightStateChangedEventArgs(string lightName, bool isOn)
        {
            LightName = lightName;
            IsOn = isOn;
        }
    }
}