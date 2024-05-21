using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ULTRAKIT.SpawnerArm.Objects;
using UnityEngine;

namespace ULTRAKIT.SpawnerArm
{
    internal static class Registry
    {
        public static List<CustomSpawnable> Spawnables = new List<CustomSpawnable>();
        public static SpawnableObjectsDatabase SpawnablesDatabase = ScriptableObject.CreateInstance<SpawnableObjectsDatabase>();

        public static SpawnableObject[] Tools = new SpawnableObject[0];
        public static SpawnableObject[] Enemies = new SpawnableObject[0];
        public static SpawnableObject[] Objects = new SpawnableObject[0];

        public static Dictionary<string, Sprite> SpawnIcons = new Dictionary<string, Sprite>();
    }
}
