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
using BepInEx.Logging;

namespace ULTRAKIT.SpawnerArm
{
    [BepInPlugin("ULTRAKIT.SpawnerArm", "Extended Spawner Arm", "2.0.0")]
    [BepInDependency("ULTRAKIT.Core", "1.0.0")]
    public class Mod : BaseUnityPlugin
    {
        public static new ManualLogSource Logger { get; private set; }

        private void Awake()
        {
            Logger = base.Logger;
        }

        public void Start()
        {
            SpawnablesInjector.Init();
            Harmony harmony = new Harmony("ULTRAKIT.ExtendedSpawnerArm");
            harmony.PatchAll();

            Logger.LogInfo("ULTRAKIT Module Loaded: Extended Spawner Arm");
        }
    }
}
