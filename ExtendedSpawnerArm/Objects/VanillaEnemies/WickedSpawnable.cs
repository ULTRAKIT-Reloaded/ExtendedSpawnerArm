using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ULTRAKIT.Core;
using UnityEngine;

namespace ULTRAKIT.SpawnerArm.Objects.VanillaEnemies
{
    internal class WickedSpawnable : CustomEnemySpawnable
    {
        internal void FillFields()
        {
            this.identifier = "extendedspawnerarm.wicked";
            this.prefab = AssetLoader.AssetFind<GameObject>("Wicked.prefab");
            this.icon = GraphicsUtilities.CreateSprite(Properties.Resources.wicked_jpg, 128, 128);
            this.enemyType = EnemyType.Wicked;
        }
    }
}
