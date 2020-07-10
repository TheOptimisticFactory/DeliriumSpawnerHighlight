using SharpDX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliriumSpawnerHighlight
{
    public enum SpawnerType
    {
        Good,
        Bad,
        Unknown
    }

    public class DeliriumSpawnerTypeHelper
    {
        public static bool GetSettingsDraw(DeliriumSpawnerSettings settings, SpawnerType type)
        {
            if (settings == null) throw new ArgumentNullException(nameof(settings));

            switch (type)
            {
                case SpawnerType.Good:
                    return settings.GoodSpawner.Enable.Value;
                case SpawnerType.Bad:
                    return settings.BadSpawner.Enable.Value;
                case SpawnerType.Unknown:
                    return settings.UnknownSpawner.Enable.Value;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type));
            }
        }

        public static Color GetSettingsColor(DeliriumSpawnerSettings settings, SpawnerType type)
        {
            if (settings == null) throw new ArgumentNullException(nameof(settings));

            switch (type)
            {
                case SpawnerType.Good:
                    return settings.GoodSpawner.Color.Value;
                case SpawnerType.Bad:
                    return settings.BadSpawner.Color.Value;
                case SpawnerType.Unknown:
                    return settings.UnknownSpawner.Color.Value;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type));
            }
        }

        public static int GetSettingsSize(DeliriumSpawnerSettings settings, SpawnerType type)
        {
            if (settings == null) throw new ArgumentNullException(nameof(settings));

            switch (type)
            {
                case SpawnerType.Good:
                    return settings.GoodSpawner.Size.Value;
                case SpawnerType.Bad:
                    return settings.BadSpawner.Size.Value;
                case SpawnerType.Unknown:
                    return settings.UnknownSpawner.Size.Value;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type));
            }
        }
    }

    
}
