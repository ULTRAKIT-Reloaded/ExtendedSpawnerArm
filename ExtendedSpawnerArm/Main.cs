using BepInEx;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace ULTRAKIT.SpawnerArm
{
    [BepInPlugin("ULTRAKIT.spawner_arm", "Extended Spawner Arm", "2.0.0")]
    public class Plugin : BaseUnityPlugin
    {
        public static Dictionary<string, Sprite> SpawnIcons = new Dictionary<string, Sprite>();

        public void Start()
        {
            CreateSprites();

            SpawnablesInjector.Init();
            Harmony harmony = new Harmony("ULTRAKIT.ExtendedSpawnerArm");
            harmony.PatchAll();
        }

        private void CreateSprites()
        {
            Sprite fpeye = SetSprite(Properties.Resources.fpeye_jpg);
            Sprite fpface = SetSprite(Properties.Resources.fpface_jpg);
            Sprite levi = SetSprite(Properties.Resources.levi_jpg);
            Sprite minos = SetSprite(Properties.Resources.minos_jpg);
            Sprite wicked = SetSprite(Properties.Resources.wicked_jpg);
            Sprite d_drone = SetSprite(Properties.Resources.d_drone_jpg);
            Sprite cameye = SetSprite(Properties.Resources.cameye_jpg);

            SpawnIcons.Add("DroneFlesh", fpeye);
            SpawnIcons.Add("DroneSkull Variant", fpface);
            SpawnIcons.Add("MinosBoss", minos);
            SpawnIcons.Add("Wicked", wicked);
            SpawnIcons.Add("Leviathan", levi);
            SpawnIcons.Add("Drone Variant", d_drone);
            SpawnIcons.Add("DroneFleshCamera Variant", cameye);
        }

        private static Sprite SetSprite(byte[] bytes)
        {
            Texture2D tex = new Texture2D(128, 128);
            tex.LoadImage(bytes);
            return Sprite.Create(tex, new Rect(0, 0, 128, 128), new Vector2(64, 64));
        }
    }
}
