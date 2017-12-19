using System;
using Lab5.BL.Configs;

namespace Lab5.BL.Controllers
{
    public class LeftSectionStandartTrafficLightController : StandartTrafficLightController
    {
        public const string LeftGreenLightName = "LeftGreen";


        public LeftSectionStandartTrafficLightController(
            int redSignalDurationSeconds,
            int yellowSignalDurationSeconds,
            int greenSignalDurationSeconds,
            int leftGreenSignalDurationSeconds)
            : base(
                redSignalDurationSeconds,
                yellowSignalDurationSeconds,
                greenSignalDurationSeconds,
                TrafficLightConfig.Create()
                    .AddState(new LightConfig(LeftGreenLightName, TimeSpan.FromSeconds(leftGreenSignalDurationSeconds), 4, TimeSpan.FromMilliseconds(500))))
        {
        }


        protected override async void OnLightStateChanged(LightController lightController)
        {
            base.OnLightStateChanged(lightController);

            if (lightController.Config.Name == GreenLightName && lightController.IsOn && !lightController.IsFlashing)
            {
                await GetLightController(LeftGreenLightName).ExecuteAsync();
            }
        }
    }
}