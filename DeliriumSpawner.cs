using ExileCore;
using ExileCore.PoEMemory.Components;
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

        private Dictionary<string, SpawnerType> SpawnerMetadataToType = new Dictionary<string, SpawnerType>
        {
            { "DoodadDaemonEggFodderSpawner", SpawnerType.Good },
            { "DoodadDaemonGlobSpawn", SpawnerType.Good },
            { "DoodadDaemonBloodBagVolatile", SpawnerType.Bad },
            { "BoneRib", SpawnerType.Unknown },
            { "RibCage", SpawnerType.Unknown },
            //Incursion Temple of Azoatl Spawners(Poison Garden)
            { "InfestationEggGreenParasite", SpawnerType.Good },
            { "InfestationEggGreenPlatform", SpawnerType.Good },
            { "InfestationEggGreenSmallPlatform", SpawnerType.Good },
            { "InfestationEggGreenLargePlatform", SpawnerType.Good }

        };

        private Dictionary<Entity, SpawnerType> SpawnerEntities = new Dictionary<Entity, SpawnerType>();


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
            RemoveNotValidEntities();
            foreach (var spawnerEntity in SpawnerEntities)
            {
                if (!DeliriumSpawnerTypeHelper.GetSettingsDraw(Settings, spawnerEntity.Value)){
                    continue;
                }
                if (spawnerEntity.Key.Metadata.Contains("InfestationEggGreen"))
                {
                    if (spawnerEntity.Key.GetComponent<Chest>().IsOpened)
                    {
                        continue;
                    }
                }else if (!spawnerEntity.Key.IsAlive || !spawnerEntity.Key.IsValid)
                {
                    continue;
                }

                var color = DeliriumSpawnerTypeHelper.GetSettingsColor(Settings, spawnerEntity.Value);
                var size = DeliriumSpawnerTypeHelper.GetSettingsSize(Settings, spawnerEntity.Value);
                DrawEntity(spawnerEntity.Key, color, size);
            }
        }

        private void RemoveNotValidEntities()
        {
            var toRemoveList = new List<Entity>();
            foreach (var spawnerEntity in SpawnerEntities.Keys)
            {
                if (!spawnerEntity.IsAlive || !spawnerEntity.IsValid)
                {
                    toRemoveList.Add(spawnerEntity);
                }
            }
            foreach (var toRemove in toRemoveList)
            {
                SpawnerEntities.Remove(toRemove);
            }
        }

        private void DrawEntity(Entity entity, Color color, int size)
        {
            var entityPos = GameController.IngameState.Camera.WorldToScreen(entity.Pos);
            Graphics.DrawFrame(new RectangleF(entityPos.X, entityPos.Y, size, size), color, size);
        }
    }
}
