using ExileCore;
using ExileCore.PoEMemory.MemoryObjects;
using ExileCore.Shared.Enums;
using SharpDX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliriumSpawnerHighlight
{
    public class DeliriumSpawner : BaseSettingsPlugin<DeliriumSpawnerSettings>
    {

        private Dictionary<string, DeliriumSpawnerType> SpawnerMetadataToType = new Dictionary<string, DeliriumSpawnerType>
        {
            { "DoodadDaemonEggFodderSpawner", DeliriumSpawnerType.Good },
            { "DoodadDaemonGlobSpawn", DeliriumSpawnerType.Good },
            { "DoodadDaemonBloodBagVolatile", DeliriumSpawnerType.Bad },
            { "BoneRib", DeliriumSpawnerType.Unknown },
            { "RibCage", DeliriumSpawnerType.Unknown },
        };

        private Dictionary<Entity, DeliriumSpawnerType> SpawnerEntities = new Dictionary<Entity, DeliriumSpawnerType>();


        public override void EntityAdded(Entity entity)
        {
            foreach (var spawner in SpawnerMetadataToType)
            {
                if (entity.Metadata.Contains(spawner.Key))
                {
                    SpawnerEntities.Add(entity, spawner.Value);
                    return;
                }
            }
        }

        public override void EntityRemoved(Entity entity)
        {
            if (SpawnerEntities.ContainsKey(entity))
            {
                SpawnerEntities.Remove(entity);
            }
        }

        public override void Render()
        {
            foreach (var spawnerEntity in SpawnerEntities)
            {
                if (!DeliriumSpawnerTypeHelper.GetSettingsDraw(Settings, spawnerEntity.Value)) continue;

                var color = DeliriumSpawnerTypeHelper.GetSettingsColor(Settings, spawnerEntity.Value);
                var size = DeliriumSpawnerTypeHelper.GetSettingsSize(Settings, spawnerEntity.Value);
                DrawEntity(spawnerEntity.Key, color, size);
            }
        }

        private void DrawEntity(Entity entity, Color color, int size)
        {
            if (!entity.IsAlive) return;
            if (!entity.IsValid) return;
            var entityPos = GameController.IngameState.Camera.WorldToScreen(entity.Pos);
            Graphics.DrawFrame(new RectangleF(entityPos.X, entityPos.Y, size, size), color, size);
        }
    }
}
