using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ULTRAKIT.Core;
using UnityEngine;

namespace ULTRAKIT.SpawnerArm.Objects.VanillaEnemies
{
    internal class BigMinosSpawnable : CustomEnemySpawnable
    {
        private void FillFields()
        {
            this.identifier = "extendedspawnerarm.minos";
            this.prefab = AssetLoader.AssetFind<GameObject>("MinosBoss.prefab");
            this.icon = GraphicsUtilities.CreateSprite(Properties.Resources.minos_jpg, 128, 128);
            this.enemyType = EnemyType.Minos;
        }

        public new SpawnableObject GetSpawnable()
        {
            FillFields();
            SetHealthBar();
            return base.GetSpawnable();
        }

        private void SetHealthBar()
        {
            BossHealthBar bhb = prefab.GetComponentInChildren<BossHealthBar>();
            if (bhb == null)
            {
                bhb = prefab.GetComponentInChildren<EnemyIdentifier>(true).gameObject.AddComponent<BossHealthBar>();
                bhb.bossName = "CORPSE OF KING MINOS";
            }
        }
    }
}
