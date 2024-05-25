using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ULTRAKIT.Core;
using UnityEngine;

namespace ULTRAKIT.SpawnerArm.Objects
{
    internal class LeviathanSpawnable : CustomEnemySpawnable
    {
        private void FillFields()
        {
            this.identifier = "extendedspawnerarm.leviathan";
            this.prefab = GenerateLeviathanPrefab();
            this.icon = GraphicsUtilities.CreateSprite(Properties.Resources.levi_jpg, 128, 128);
            this.enemyType = EnemyType.Leviathan;
        }

        public new SpawnableObject GetSpawnable()
        {
            FillFields();
            return base.GetSpawnable();
        }

        private GameObject GenerateLeviathanPrefab()
        {
            GameObject LeviathanBase = new GameObject("Leviathan");
            LeviathanBase.SetActive(false);
            GameObject head = GameObject.Instantiate(AssetLoader.AssetFind<GameObject>("LeviathanHead.prefab"), LeviathanBase.transform);
            GameObject tail = GameObject.Instantiate(AssetLoader.AssetFind<GameObject>("LeviathanTail Variant.prefab"), LeviathanBase.transform);
            GameObject splash = GameObject.Instantiate(AssetLoader.AssetFind<GameObject>("SplashBig.prefab"), LeviathanBase.transform);
            LeviathanController controller = LeviathanBase.AddComponent<LeviathanController>();
            EnemyIdentifier eid = LeviathanBase.AddComponent<EnemyIdentifier>();
            Statue stat = LeviathanBase.AddComponent<Statue>();
            SphereCollider collider = LeviathanBase.AddComponent<SphereCollider>();
            Rigidbody rb = LeviathanBase.AddComponent<Rigidbody>();
            BossIdentifier bid = LeviathanBase.AddComponent<BossIdentifier>();
            BossHealthBar bar = LeviathanBase.AddComponent<BossHealthBar>();

            controller.head = head.GetComponent<LeviathanHead>();
            controller.tail = tail.GetComponent<LeviathanTail>();
            controller.bigSplash = AssetLoader.AssetFind<GameObject>("SplashBig.prefab");
            controller.headWeakPoint = head.transform.Find("Leviathan_SplineHook_Basic/Armature/Bone043/Bone001/Heart");
            controller.tailWeakPoint = tail.transform.Find($"Leviathan_SplineHook_Basic/Armature/{GraphicsUtilities.BonePath(43, 86)}");
            controller.headPartsParent = head.transform.Find("Leviathan_SplineHook_Basic/Armature/Bone043/Bone044");
            controller.tailPartsParent = tail.transform.Find("Leviathan_SplineHook_Basic/Armature/Bone043/Bone044");
            controller.phaseChangeHealth = 100;

            eid.overrideFullName = "Leviathan";
            eid.bigEnemy = true;
            eid.damageBuffModifier = 1.5f;
            eid.enemyClass = EnemyClass.Demon;
            eid.enemyType = EnemyType.Leviathan;
            eid.health = 200;
            eid.healthBuffModifier = 1.5f;
            eid.speedBuffModifier = 1.5f;
            eid.unbounceable = true;
            eid.weakPoint = head.transform.Find("Leviathan_SplineHook_Basic/Armature/Bone043/Bone001/Heart").gameObject;

            stat.affectedByGravity = true;
            stat.bigBlood = true;
            stat.extraDamageMultiplier = 3;
            stat.extraDamageZones = new List<GameObject> { head.transform.Find("Leviathan_SplineHook_Basic/Armature/Bone043/Bone001/Heart").gameObject };
            stat.health = 200;
            stat.specialDeath = true;

            bar.bossName = "LEVIATHAN";
            HealthLayer b1 = new HealthLayer();
            HealthLayer b2 = new HealthLayer();
            b1.health = 100;
            b2.health = 100;
            bar.healthLayers = new HealthLayer[] { b1, b2 };

            rb.isKinematic = true;

            controller.head.shootPoint = head.transform.Find("Leviathan_SplineHook_Basic/Armature/Bone043/Bone001/ShootPoint");
            controller.head.projectileSpreadAmount = 5;
            controller.head.tracker = head.transform.Find("Leviathan_SplineHook_Basic/Armature/Bone043/Bone001");
            controller.head.tailBone = head.transform.Find($"Leviathan_SplineHook_Basic/Armature/{GraphicsUtilities.BonePath(43, 56)}");
            controller.head.lookAtPlayer = true;
            controller.head.biteSwingCheck = head.transform.Find("Leviathan_SplineHook_Basic/Armature/Bone043/Bone001/SwingCheck").GetComponent<SwingCheck2>();
            controller.head.warningFlash = AssetLoader.AssetFind<GameObject>("V2FlashUnparriable.prefab");

            controller.gameObject.tag = "Enemy";

            return LeviathanBase;
        }
    }
}
