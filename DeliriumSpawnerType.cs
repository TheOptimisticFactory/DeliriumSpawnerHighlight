using SharpDX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliriumSpawnerHighlight
{
    public enum DeliriumSpawnerType
    {
        Good,
        Bad,
        Unknown
    }

    public class DeliriumSpawnerTypeHelper
    {
        public static bool GetSettingsDraw(DeliriumSpawnerSettings settings, DeliriumSpawnerType type)
        {
            if (settings == null) throw new ArgumentNullException(nameof(settings));

            switch (type)
            {
                case DeliriumSpawnerType.Good:
                    return settings.GoodSpawner.Enable.Value;
                case DeliriumSpawnerType.Bad:
                    return settings.BadSpawner.Enable.Value;
                case DeliriumSpawnerType.Unknown:
                    return settings.UnknownSpawner.Enable.Value;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type));
            }
        }

        public static Color GetSettingsColor(DeliriumSpawnerSettings settings, DeliriumSpawnerType type)
        {
            if (settings == null) throw new ArgumentNullException(nameof(settings));

            switch (type)
            {
                case DeliriumSpawnerType.Good:
                    return settings.GoodSpawner.Color.Value;
                case DeliriumSpawnerType.Bad:
                    return settings.BadSpawner.Color.Value;
                case DeliriumSpawnerType.Unknown:
                    return settings.UnknownSpawner.Color.Value;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type));
            }
        }

        public static int GetSettingsSize(DeliriumSpawnerSettings settings, DeliriumSpawnerType type)
        {
            if (settings == null) throw new ArgumentNullException(nameof(settings));

            switch (type)
            {
                case DeliriumSpawnerType.Good:
                    return settings.GoodSpawner.Size.Value;
                case DeliriumSpawnerType.Bad:
                    return settings.BadSpawner.Size.Value;
                case DeliriumSpawnerType.Unknown:
                    return settings.UnknownSpawner.Size.Value;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type));
            }
        }
    }

    
}
