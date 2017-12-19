using System;
using System.Text;
using Lab5.BL;

namespace Lab5.Drawers
{
    public abstract class TrafficLightDrawerBase : ITrafficLightDrawer
    {
        public const char DefaultLightSymbol = '\u25CF';

        private const ConsoleColor DefaultColor = ConsoleColor.Gray;
        private static readonly object ConsoleLocker = new object();

        private readonly Point _zoneOffset;
        private readonly ITrafficLight _trafficLight;
        private readonly Action<Point> _prepareConsoleAction;


        protected TrafficLightDrawerBase(
            int leftOffset,
            int topOffset,
            ITrafficLight trafficLight,
            Action<Point> prepareConsoleAction)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.CursorVisible = false;

            _zoneOffset = new Point(leftOffset, topOffset);
            _trafficLight = trafficLight;
            _prepareConsoleAction = prepareConsoleAction;
            _trafficLight.LightStateChanged += TrafficLightOnLightStateChanged;
        }


        public void Start()
        {
            lock (ConsoleLocker)
            {
                _prepareConsoleAction(_zoneOffset);
            }
            _trafficLight.TurnOn();
        }


        protected virtual char GetLightSymbol(string lightName)
        {
            return DefaultLightSymbol;
        }

        protected abstract Point GetPosition(string lightName);

        protected abstract ConsoleColor GetColor(string lightName);


        private void TrafficLightOnLightStateChanged(object sender, LightStateChangedEventArgs e)
        {
            var position = GetPosition(e.LightName);
            var color = e.IsOn ? GetColor(e.LightName) : DefaultColor;
            lock (ConsoleLocker)
            {
                Console.SetCursorPosition(_zoneOffset.Left + position.Left, _zoneOffset.Top + position.Top);
                Console.ForegroundColor = color;
                Console.Write(GetLightSymbol(e.LightName));
                Console.ForegroundColor = DefaultColor;
            }
        }


        protected class Point
        {
            public int Left { get; }

            public int Top { get; }


            public Point(int left, int top)
            {
                Left = left;
                Top = top;
            }
        }
    }

}