using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEditor;
using HarmonyLib;
using ULTRAKIT.Core;
using ULTRAKIT.SpawnerArm.Objects.VanillaEnemies;

namespace ULTRAKIT.SpawnerArm
{
    public static class SpawnablesInjector
    {
        // ULTRAKILL enemies added to the spawner arm by default
        static Dictionary<string, EnemyType> SpawnList = new Dictionary<string, EnemyType>
        {
            // Same health as miniboss version { "SwordsMachine", EnemyType.Swordsmachine },
            // Empty fields, needs to be done similar to Leviathan, TODO { "MinosArm" , EnemyType.Minos },
        };

        internal static List<SpawnableObject> _enemies = new List<SpawnableObject>();

        public static void Init()
        {
            // etc, etc, going to be redone anyway
            _enemies.Add(ScriptableObject.CreateInstance<BigMinosSpawnable>().GetSpawnable());
        }
    }
}
