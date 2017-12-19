using System;
using System.Collections.Generic;
using System.Linq;
using Lab5.BL.Configs;

namespace Lab5.BL.Controllers
{
    public class GenericTrafficLightController : ITrafficLight
    {
        private readonly IEnumerable<LightController> _cycledLights;

        private bool _isEnabled;


        public event EventHandler<LightStateChangedEventArgs> LightStateChanged;


        public IEnumerable<LightController> LightControllers { get; }


        public GenericTrafficLightController(TrafficLightConfig config)
        {
            LightControllers = config.Select(lc => new LightController(lc, OnLightStateChanged));
            _cycledLights = LightControllers.Where(l => l.Config.IncludedInCycle);
        }


        public async void TurnOn()
        {
            if (_isEnabled)
            {
                return;
            }

            _isEnabled = true;
            var nextLight = _cycledLights.First();
            while (_isEnabled)
            {
                await nextLight.ExecuteAsync();

                nextLight = _cycledLights
                        .SkipWhile(l => !l.Config.Equals(nextLight.Config))
                        .ElementAtOrDefault(1)
                    ?? _cycledLights.First();
            }
        }

        public void TurnOff()
        {
            _isEnabled = false;
        }


        protected virtual void OnLightStateChanged(LightController newLight)
        {
            LightStateChanged?.Invoke(this, new LightStateChangedEventArgs(newLight.Config.Name, newLight.IsOn));
        }

        protected LightController GetLightController(string lightName)
        {
            var lightController = LightControllers.FirstOrDefault(l => l.Config.Name == lightName);
            if (lightController == null)
            {
                throw new ArgumentOutOfRangeException(nameof(lightName), lightName, "LightController is not registered.");
            }

            return lightController;
        }
    }
}