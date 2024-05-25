using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ULTRAKIT.Core;
using UnityEngine;

namespace ULTRAKIT.SpawnerArm.Objects.VanillaEnemies
{
    internal class FleshPrisonEyeSpawnable : CustomEnemySpawnable
    {
        internal void FillFields()
        {
            this.identifier = "extendedspawnerarm.fleshprisoneye";
            this.prefab = AssetLoader.AssetFind<GameObject>("DroneFlesh.prefab");
            this.icon = GraphicsUtilities.CreateSprite(Properties.Resources.fpeye_jpg, 128, 128);
            this.enemyType = EnemyType.Drone;
        }
    }
}
