using System;
using System.Threading.Tasks;
using Lab5.BL.Configs;

namespace Lab5.BL
{
    public class LightController
    {
        private readonly Action<LightController> _onLightStateChanged;


        public LightConfig Config { get; }

        public bool IsOn { get; private set; }

        public bool IsFlashing { get; private set; }


        internal LightController(LightConfig config, Action<LightController> onLightStateChanged)
        {
            _onLightStateChanged = onLightStateChanged;
            Config = config;
        }


        public async Task ExecuteAsync()
        {
            SwitchOnOff(true);

            await Task.Delay(Config.DurationOfInvolvement);

            var count = Config.FlashCountOnShutdown * 2;
            IsFlashing = count > 0;
            for (var i = 0; i < count; i++)
            {
                SwitchOnOff();
                await Task.Delay(Config.OneFlashDuration);
            }
            IsFlashing = false;

            SwitchOnOff(false);
        }


        public override string ToString()
        {
            return Config.Name;
        }


        private void SwitchOnOff(bool? turnOn = null)
        {
            var isOn = turnOn ?? !IsOn;
            if (IsOn == isOn)
            {
                return;
            }

            IsOn = isOn;
            _onLightStateChanged(this);
        }
    }
}