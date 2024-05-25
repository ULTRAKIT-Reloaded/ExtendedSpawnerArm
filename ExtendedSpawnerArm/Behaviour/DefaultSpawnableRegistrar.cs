using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ULTRAKIT.SpawnerArm.Objects.VanillaEnemies;
using UnityEngine;

namespace ULTRAKIT.SpawnerArm.Behaviour
{
    internal static class DefaultSpawnableRegistrar
    {
        internal static void RegisterSpawnables()
        {
            SpawnablesLoader.LoadSpawnable(ScriptableObject.CreateInstance<BigMinosSpawnable>());
            SpawnablesLoader.LoadSpawnable(ScriptableObject.CreateInstance<DarkDroneSpawnable>());
            SpawnablesLoader.LoadSpawnable(ScriptableObject.CreateInstance<FleshPrisonEyeSpawnable>());
            SpawnablesLoader.LoadSpawnable(ScriptableObject.CreateInstance<FleshPrisonFaceSpawnable>());
            SpawnablesLoader.LoadSpawnable(ScriptableObject.CreateInstance<LeviathanSpawnable>());
            SpawnablesLoader.LoadSpawnable(ScriptableObject.CreateInstance<PanopticonEyeSpawnable>());
            SpawnablesLoader.LoadSpawnable(ScriptableObject.CreateInstance<WickedSpawnable>());
        }
    }
}
