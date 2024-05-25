using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditorInternal.Profiling.Memory.Experimental.FileFormat;
using UnityEngine;

namespace ULTRAKIT.SpawnerArm.Objects
{
    public class CustomObjectSpawnable : ScriptableObject
    {
        public string identifier;
        public GameObject prefab;
        public Sprite icon;
        public bool isProp;

        public SpawnableObject GetSpawnable()
        {
            SpawnableObject spawnable = CreateInstance<SpawnableObject>();

            spawnable.identifier = identifier;
            spawnable.gameObject = prefab;
            spawnable.gridIcon = icon;

            spawnable.spawnableObjectType = SpawnableObject.SpawnableObjectDataType.Object;
            spawnable.spawnableType = isProp ? SpawnableType.Prop : SpawnableType.SimpleSpawn;
            spawnable.sandboxOnly = false;

            return spawnable;
        }
    }
}
