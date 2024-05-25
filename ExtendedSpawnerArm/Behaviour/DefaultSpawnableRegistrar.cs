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
            BigMinosSpawnable bigMinosSpawnable = ScriptableObject.CreateInstance<BigMinosSpawnable>();
            bigMinosSpawnable.FillFields();
            SpawnablesLoader.LoadSpawnable(bigMinosSpawnable);

            DarkDroneSpawnable darkDroneSpawnable = ScriptableObject.CreateInstance<DarkDroneSpawnable>();
            darkDroneSpawnable.FillFields();
            SpawnablesLoader.LoadSpawnable(darkDroneSpawnable);

            FleshPrisonEyeSpawnable fleshPrisonEyeSpawnable = ScriptableObject.CreateInstance<FleshPrisonEyeSpawnable>();
            fleshPrisonEyeSpawnable.FillFields();
            SpawnablesLoader.LoadSpawnable(fleshPrisonEyeSpawnable);

            FleshPrisonFaceSpawnable fleshPrisonFaceSpawnable = ScriptableObject.CreateInstance<FleshPrisonFaceSpawnable>();
            fleshPrisonFaceSpawnable.FillFields();
            SpawnablesLoader.LoadSpawnable(fleshPrisonFaceSpawnable);
            
            LeviathanSpawnable leviathanSpawnable = ScriptableObject.CreateInstance<LeviathanSpawnable>();
            leviathanSpawnable.FillFields();
            SpawnablesLoader.LoadSpawnable(leviathanSpawnable);

            PanopticonEyeSpawnable panopticonEyeSpawnable = ScriptableObject.CreateInstance<PanopticonEyeSpawnable>();
            panopticonEyeSpawnable.FillFields();
            SpawnablesLoader.LoadSpawnable(panopticonEyeSpawnable);

            WickedSpawnable wickedSpawnable = ScriptableObject.CreateInstance<WickedSpawnable>();
            wickedSpawnable.FillFields();
            SpawnablesLoader.LoadSpawnable(wickedSpawnable);
        }
    }
}
