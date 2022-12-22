using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMM;
using UnityEngine.SceneManagement;

namespace ExtendedSpawnerArm
{
    [UKPlugin("petersone1.extendedSpawner", "Extended Spawner Arm", "1.0.0", "Adds missing spawnables to the spawner arm", true, false)]
    public class Plugin : UKMod
    {
        public override void OnModLoaded()
        {
            SpawnerInjector.Init();
            Harmony harmony = new Harmony("ExtendedSpawnerArm");
            harmony.PatchAll();
        }
    }
}
