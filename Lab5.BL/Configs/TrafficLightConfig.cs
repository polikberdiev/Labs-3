using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Lab5.BL.Configs
{
    public class TrafficLightConfig : IEnumerable<LightConfig>
    {
        private readonly IList<LightConfig> _lightConfigs;


        public TrafficLightConfig(IEnumerable<LightConfig> configs)
        {
            _lightConfigs = configs.ToList();
        }


        IEnumerator<LightConfig> IEnumerable<LightConfig>.GetEnumerator()
        {
            return _lightConfigs.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _lightConfigs.GetEnumerator();
        }


        public TrafficLightConfig AddCycledState(LightConfig config)
        {
            config.IncludedInCycle = true;
            _lightConfigs.Add(config);

            return this;
        }

        public TrafficLightConfig AddState(LightConfig config)
        {
            config.IncludedInCycle = false;
            _lightConfigs.Add(config);

            return this;
        }

        public static TrafficLightConfig Create()
        {
            return new TrafficLightConfig(new List<LightConfig>());
        }

        public static TrafficLightConfig BasedOn(TrafficLightConfig config)
        {
            return new TrafficLightConfig(config);
        }
    }
}