using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditorInternal.Profiling.Memory.Experimental.FileFormat;
using UnityEngine;
using ULTRAKIT.SpawnerArm.Objects;
using ULTRAKIT.Core.Objects;

namespace ULTRAKIT.SpawnerArm
{
    public static class SpawnablesLoader
    {
        /// <summary>
        /// Loads spawnables into the registry from a loaded asset bundle.
        /// </summary>
        /// <param name="bundle"></param>
        public static void LoadSpawnables(AssetBundle bundle)
        {
            CustomSpawnable[] spawnables = bundle.LoadAllAssets<CustomSpawnable>();
            foreach (CustomSpawnable spawnable in spawnables)
            {
                spawnable.prefab.AddComponent<RenderFixer>().LayerName = "Outdoors";
                if (!Registry.Spawnables.Contains(spawnable))
                    Registry.Spawnables.Add(spawnable);
            }
        }

        /// <summary>
        /// Loads a spawnable into the registry.
        /// </summary>
        /// <param name="bundle"></param>
        public static void LoadSpawnable(CustomSpawnable spawnable)
        {
            if (spawnable.prefab != null)
                spawnable.prefab.AddComponent<RenderFixer>().LayerName = "Outdoors";

            if (!Registry.Spawnables.Contains(spawnable))
                Registry.Spawnables.Add(spawnable);
        }

        internal static void InjectSpawnables(SpawnMenu spawnMenu)
        {
            List<SpawnableObject> enemies = new List<SpawnableObject>();
            List<SpawnableObject> objects = new List<SpawnableObject>();

            foreach (CustomSpawnable spawnable in Registry.Spawnables)
            {
                if (spawnable is CustomEnemySpawnable)
                {
                    enemies.Add(spawnable.GetSpawnable());
                    Debug.Log("RAW SPAWNABLE ID: " + spawnable.identifier);
                    Debug.Log("GENERATED SPAWNABLE ID: " + spawnable.GetSpawnable().identifier);
                    continue;
                }
                if (spawnable is CustomObjectSpawnable)
                {
                    objects.Add(spawnable.GetSpawnable());
                    continue;
                }
            }

            // Combines custom and vanilla spawnables
            Registry.Enemies = Registry.VanillaSpawnablesDatabase.enemies.Concat(enemies).ToArray();
            Registry.Objects = Registry.VanillaSpawnablesDatabase.objects.Concat(objects).ToArray();

            foreach (SpawnableObject spawnable in Registry.Enemies)
            {
                Debug.Log(spawnable.identifier);
            }
        }
    }
}
