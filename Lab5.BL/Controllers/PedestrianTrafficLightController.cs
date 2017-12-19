using System;
using Lab5.BL.Configs;

namespace Lab5.BL.Controllers
{
    public class PedestrianTrafficLightController : GenericTrafficLightController
    {
        public const string RedLightName = "Red";
        public const string GreenLightName = "Green";


        public PedestrianTrafficLightController(
            int redSignalDurationSeconds,
            int greenSignalDurationSeconds)
            : base(TrafficLightConfig.Create()
                  .AddCycledState(new LightConfig(RedLightName, TimeSpan.FromSeconds(redSignalDurationSeconds)))
                  .AddCycledState(new LightConfig(GreenLightName, TimeSpan.FromSeconds(greenSignalDurationSeconds), 3, TimeSpan.FromMilliseconds(500))))
        {
        }
    }
}