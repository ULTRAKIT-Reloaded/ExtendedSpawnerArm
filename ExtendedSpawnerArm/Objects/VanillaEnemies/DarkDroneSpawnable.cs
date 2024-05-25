using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ULTRAKIT.Core;
using UnityEngine;

namespace ULTRAKIT.SpawnerArm.Objects.VanillaEnemies
{
    internal class DarkDroneSpawnable : CustomEnemySpawnable
    {
        internal void FillFields()
        {
            this.identifier = "extendedspawnerarm.darkdrone";
            this.prefab = AssetLoader.AssetFind<GameObject>("Drone Variant.prefab");
            this.icon = GraphicsUtilities.CreateSprite(Properties.Resources.d_drone_jpg, 128, 128);
            this.enemyType = EnemyType.Drone;
        }
    }
}
