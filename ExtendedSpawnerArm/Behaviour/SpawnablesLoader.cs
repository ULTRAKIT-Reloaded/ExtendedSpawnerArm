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
        private static List<CustomSpawnable> spawnables => Registry.Spawnables;
        private static SpawnableObjectsDatabase spawnablesDatabase => Registry.SpawnablesDatabase;

        public static bool init = false;

        /// <summary>
        /// Loads spawnables into the spawner arm automatically from a loaded asset bundle.
        /// </summary>
        /// <param name="bundle"></param>
        public static void LoadSpawnables(AssetBundle bundle)
        {
            CustomSpawnable[] ukS = bundle.LoadAllAssets<CustomSpawnable>();
            foreach (CustomSpawnable ukSpawnable in ukS)
            {
                ukSpawnable.prefab.AddComponent<RenderFixer>().LayerName = "Outdoors";
                if (!spawnables.Contains(ukSpawnable))
                    spawnables.Add(ukSpawnable);
            }
        }

        /// <summary>
        /// Removes spawnables from the registry.
        /// </summary>
        /// <param name="bundle"></param>
        public static void UnloadSpawnables(AssetBundle bundle)
        {
            CustomSpawnable[] ukS = bundle.LoadAllAssets<CustomSpawnable>();
            foreach (CustomSpawnable ukSpawnable in ukS)
            {
                if (spawnables.Contains(ukSpawnable))
                    spawnables.Remove(ukSpawnable);
            }
        }

        /// <summary>
        /// Internal, do not use. Converts UKSpawnables into native SpawnableObjects.
        /// </summary>
        /// <param name="spawnMenu"></param>
        public static void InjectSpawnables(SpawnMenu spawnMenu)
        {
            List<SpawnableObject> tools = new List<SpawnableObject>();
            List<SpawnableObject> enemies = new List<SpawnableObject>();
            List<SpawnableObject> objects = new List<SpawnableObject>();

            foreach (CustomSpawnable ukSpawnable in Registry.Spawnables)
            {
                SpawnableObject spawnable = ScriptableObject.CreateInstance<SpawnableObject>();
                spawnable.identifier = ukSpawnable.identifier;
                spawnable.spawnableObjectType = ukSpawnable.type;
                spawnable.objectName = ukSpawnable.identifier;
                spawnable.type = "UKSpawnable";
                spawnable.enemyType = EnemyType.MinosPrime;
                spawnable.gameObject = ukSpawnable.prefab;
                spawnable.preview = new GameObject();
                spawnable.gridIcon = ukSpawnable.icon;

                switch (ukSpawnable.type)
                {
                    case SpawnableObject.SpawnableObjectDataType.Tool:
                        spawnable.spawnableType = SpawnableType.BuildHand;
                        tools.Add(spawnable);
                        break;
                    case SpawnableObject.SpawnableObjectDataType.Enemy:
                        spawnable.spawnableType = SpawnableType.SimpleSpawn;
                        enemies.Add(spawnable);
                        break;
                    case SpawnableObject.SpawnableObjectDataType.Object:
                        spawnable.spawnableType = SpawnableType.SimpleSpawn;
                        objects.Add(spawnable);
                        break;
                }
            }

            enemies.AddRange(SpawnablesInjector._enemies);

            // Adds loaded spawnables onto the pre-existing list
            Registry.Tools = spawnablesDatabase.sandboxTools.Concat(tools).ToArray();
            Registry.Enemies = spawnablesDatabase.enemies.Concat(enemies).ToArray();
            Registry.Objects = spawnablesDatabase.objects.Concat(objects).ToArray();
        }
    }
}
