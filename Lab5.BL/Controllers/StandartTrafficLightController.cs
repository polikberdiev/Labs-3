using System;
using Lab5.BL.Configs;

namespace Lab5.BL.Controllers
{
    public class StandartTrafficLightController : GenericTrafficLightController
    {
        public const string RedLightName = "Red";
        public const string YellowLightName = "Yellow";
        public const string GreenLightName = "Green";


        public StandartTrafficLightController(
            int redSignalDurationSeconds,
            int yellowSignalDurationSeconds,
            int greenSignalDurationSeconds)
            : this(
                redSignalDurationSeconds,
                yellowSignalDurationSeconds,
                greenSignalDurationSeconds,
                TrafficLightConfig.Create())
        {
        }

        protected StandartTrafficLightController(
            int redSignalDurationSeconds,
            int yellowSignalDurationSeconds,
            int greenSignalDurationSeconds,
            TrafficLightConfig config)
            : base(TrafficLightConfig.BasedOn(config)
                    .AddCycledState(new LightConfig(RedLightName, TimeSpan.FromSeconds(redSignalDurationSeconds)))
                    .AddCycledState(new LightConfig(YellowLightName, TimeSpan.FromSeconds(yellowSignalDurationSeconds)))
                    .AddCycledState(new LightConfig(GreenLightName, TimeSpan.FromSeconds(greenSignalDurationSeconds), 3, TimeSpan.FromMilliseconds(500))))
        {
        }
    }
}