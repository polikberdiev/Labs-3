using System;

namespace Lab5.BL.Configs
{
    public class LightConfig
    {
        public string Name { get; }

        public TimeSpan DurationOfInvolvement { get; }

        public int FlashCountOnShutdown { get; }

        public TimeSpan OneFlashDuration { get; }

        public bool IncludedInCycle { get; internal set; }


        public LightConfig(string name, TimeSpan durationOfInvolvement)
            : this(name, durationOfInvolvement, 0, TimeSpan.Zero)
        {
        }

        public LightConfig(
            string name,
            TimeSpan durationOfInvolvement,
            int flashCountOnShutdown,
            TimeSpan oneFlashDuration)
        {
            Name = name;
            DurationOfInvolvement = durationOfInvolvement;
            FlashCountOnShutdown = flashCountOnShutdown;
            OneFlashDuration = oneFlashDuration;
        }
    }
}