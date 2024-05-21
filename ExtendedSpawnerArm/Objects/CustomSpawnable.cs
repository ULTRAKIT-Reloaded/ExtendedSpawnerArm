using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ULTRAKIT.SpawnerArm.Objects
{
    public class CustomSpawnable : ScriptableObject
    {
        public SpawnableObject.SpawnableObjectDataType type;
        public string identifier;
        public GameObject prefab;
        public Sprite icon;
    }
}
