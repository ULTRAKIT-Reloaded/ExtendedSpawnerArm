using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ULTRAKIT.Core;
using UnityEngine;

namespace ULTRAKIT.SpawnerArm.Objects.VanillaEnemies
{
    internal class PanopticonEyeSpawnable : CustomEnemySpawnable
    {
        internal void FillFields()
        {
            this.identifier = "extendedspawnerarm.panopticoneye";
            this.prefab = AssetLoader.AssetFind<GameObject>("DroneFleshCamera Variant.prefab");
            this.icon = GraphicsUtilities.CreateSprite(Properties.Resources.cameye_jpg, 128, 128);
            this.enemyType = EnemyType.Drone;
        }
    }
}
