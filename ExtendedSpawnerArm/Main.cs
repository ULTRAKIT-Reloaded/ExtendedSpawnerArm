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
using ULTRAKIT.Core;

namespace ULTRAKIT.SpawnerArm
{
    [BepInPlugin("ULTRAKIT.spawner_arm", "Extended Spawner Arm", "2.0.0")]
    [BepInDependency("ULTRAKIT.Core", "1.0.0")]
    public class Plugin : BaseUnityPlugin
    {
        public void Start()
        {
            SetSprites();

            SpawnablesInjector.Init();
            Harmony harmony = new Harmony("ULTRAKIT.ExtendedSpawnerArm");
            harmony.PatchAll();
        }

        private void SetSprites()
        {
            Sprite fpeye = GraphicsUtilities.CreateSprite(Properties.Resources.fpeye_jpg, 128, 128);
            Sprite fpface = GraphicsUtilities.CreateSprite(Properties.Resources.fpface_jpg, 128, 128);
            Sprite levi = GraphicsUtilities.CreateSprite(Properties.Resources.levi_jpg, 128, 128);
            Sprite minos = GraphicsUtilities.CreateSprite(Properties.Resources.minos_jpg, 128, 128);
            Sprite wicked = GraphicsUtilities.CreateSprite(Properties.Resources.wicked_jpg, 128, 128);
            Sprite d_drone = GraphicsUtilities.CreateSprite(Properties.Resources.d_drone_jpg, 128, 128);
            Sprite cameye = GraphicsUtilities.CreateSprite(Properties.Resources.cameye_jpg, 128, 128);

            Registry.SpawnIcons.Add("DroneFlesh", fpeye);
            Registry.SpawnIcons.Add("DroneSkull Variant", fpface);
            Registry.SpawnIcons.Add("MinosBoss", minos);
            Registry.SpawnIcons.Add("Wicked", wicked);
            Registry.SpawnIcons.Add("Leviathan", levi);
            Registry.SpawnIcons.Add("Drone Variant", d_drone);
            Registry.SpawnIcons.Add("DroneFleshCamera Variant", cameye);
        }
    }
}
