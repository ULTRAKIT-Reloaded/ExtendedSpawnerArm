using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ULTRAKIT.SpawnerArm.Objects
{
    public class CustomEnemySpawnable : CustomSpawnable
    {
        public EnemyType enemyType;

        public override SpawnableObject GetSpawnable()
        {
            SpawnableObject spawnable = CreateInstance<SpawnableObject>();

            spawnable.identifier = identifier;
            spawnable.gameObject = prefab;
            spawnable.gridIcon = icon;
            spawnable.enemyType = enemyType;

            spawnable.spawnableObjectType = SpawnableObject.SpawnableObjectDataType.Enemy;
            spawnable.spawnableType = SpawnableType.SimpleSpawn;
            spawnable.preview = new GameObject();
            spawnable.sandboxOnly = false;

            return spawnable;
        }
    }
}
