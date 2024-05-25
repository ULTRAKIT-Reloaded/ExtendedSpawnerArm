using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ULTRAKIT.SpawnerArm.Objects
{
    public abstract class CustomSpawnable : ScriptableObject
    {
        public string identifier;
        public GameObject prefab;
        public Sprite icon;

        public abstract SpawnableObject GetSpawnable();
    }
}
