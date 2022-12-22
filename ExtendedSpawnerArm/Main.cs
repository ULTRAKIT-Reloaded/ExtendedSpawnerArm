using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMM;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace ExtendedSpawnerArm
{
    [UKPlugin("petersone1.extendedSpawner", "Extended Spawner Arm", "1.0.0", "Adds missing spawnables to the spawner arm", true, false)]
    public class Plugin : UKMod
    {
        public static Sprite fpeye;
        public static Sprite fpface;
        public static Sprite levi;
        public static Sprite minos;
        public static Sprite wicked;

        public override void OnModLoaded()
        {
            fpeye = SetSprite(Properties.Resources.fpeye_jpg);
            fpface = SetSprite(Properties.Resources.fpface_jpg);
            levi = SetSprite(Properties.Resources.levi_jpg);
            minos = SetSprite(Properties.Resources.minos_jpg);
            wicked = SetSprite(Properties.Resources.wicked_jpg);

            SpawnerInjector.Init();
            Harmony harmony = new Harmony("ExtendedSpawnerArm");
            harmony.PatchAll();
        }

        private static Sprite SetSprite(byte[] bytes)
        {
            Texture2D tex = new Texture2D(128, 128);
            tex.LoadImage(bytes);
            return Sprite.Create(tex, new Rect(0, 0, 128, 128), new Vector2(64, 64));
        }
    }
}
