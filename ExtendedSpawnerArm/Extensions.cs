using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ExtendedSpawnerArm
{
    public static class Extensions
    {
        public static GameObject PrefabFind(this AssetBundle bundle, string bundlename, string name)
        {
            if (bundle == null)
            {
                if (File.Exists($@"{Application.productName}_Data\StreamingAssets\{bundlename}"))
                {
                    var data = File.ReadAllBytes($@"{Application.productName}_Data\StreamingAssets\{bundlename}");
                    bundle = LoadFromLoaded(bundle, "common") ?? AssetBundle.LoadFromMemory(data);
                }
                else
                {
                    Debug.LogWarning($"Could not find bundle {bundlename} or StreamingAssets file");
                    return new GameObject();
                }
            }
            return bundle.LoadAsset<GameObject>(name) ?? null;
        }

        public static AssetBundle LoadFromLoaded(this AssetBundle bundle, string name)
        {
            foreach (var bndl in AssetBundle.GetAllLoadedAssetBundles())
            {
                if (bndl.name == name)
                {
                    bundle = bndl;
                }
            }
            return bundle ?? null;
        }

        public static void SetPrivate(this object obj, string name, object value)
        {
            obj.GetType().GetField(name, BindingFlags.Instance | BindingFlags.NonPublic).SetValue(obj, value);
        }

        public static T GetPrivate<T>(this object obj, string name)
        {
            return (T)obj.GetType().GetField(name, BindingFlags.Instance | BindingFlags.NonPublic).GetValue(obj);
        }
    }
}
