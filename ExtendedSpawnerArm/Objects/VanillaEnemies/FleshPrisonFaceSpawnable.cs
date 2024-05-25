using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ULTRAKIT.Core;
using UnityEngine;

namespace ULTRAKIT.SpawnerArm.Objects.VanillaEnemies
{
    internal class FleshPrisonFaceSpawnable : CustomEnemySpawnable
    {
        internal void FillFields()
        {
            this.identifier = "extendedspawnerarm.fleshprisonface";
            this.prefab = AssetLoader.AssetFind<GameObject>("DroneSkull Variant.prefab");
            this.icon = GraphicsUtilities.CreateSprite(Properties.Resources.fpface_jpg, 128, 128);
            this.enemyType = EnemyType.Drone;
        }
    }
}
