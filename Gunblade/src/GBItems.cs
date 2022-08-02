using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using SideLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace Gunblade
{
    public class GBItems
    {
        public const string TAG_GB = "Gunblade";
        public const int DEF_FLINTLOCK = 5110100;

        public const int FLINTLOCK_GB = -31200;

        public static void Init()
        {
            SetUpTags();
            SetUpGunblades();
        }

        private static void SetUpTags()
        {
            var gbTags = new SL_TagManifest
            {
                Tags = new List<SL_TagDefinition>
                {
                    new SL_TagDefinition { TagName = TAG_GB },
                }
            };
            gbTags.ApplyTemplate();

            
        }

        private static void SetUpGunblades()
        {
            SL_ProjectileWeapon flintlockGB = new SL_ProjectileWeapon()
            {
                
                Target_ItemID = DEF_FLINTLOCK,
                New_ItemID = FLINTLOCK_GB,
                Name = "Flintlock Gunblade",
                Description = "Basic gun with an attached blade that needs the Fire/Reload skill to shoot. Locking on enemies is vital to hit with pistols.",
                Tags = new string[] { "Pistol", "Trinket", "Item", "Weapon", "Dague", TAG_GB },
                //StatsHolder = new SL_WeaponStats()
                //{

                //},
                ItemVisuals = new SL_ItemVisual()
                {
                    Prefab_SLPack = "Gunblade",
                    Prefab_AssetBundle = "gunblade",
                    Prefab_Name = "flintlock_gb"
                },

                SpecialItemVisuals = new SL_ItemVisual()
                {
                    Prefab_SLPack = "Gunblade",
                    Prefab_AssetBundle = "gunblade",
                    Prefab_Name = "flintlock_gb-sv"
                },
            };
            flintlockGB.SLPackName = "Gunblade";
            flintlockGB.SubfolderName = "Flintlock_GB";
            flintlockGB.ApplyTemplate();

            //var fGB = ResourcesPrefabManager.Instance.GetItemPrefab(FLINTLOCK_GB);
            //var broadBlade = ResourcesPrefabManager.Instance.GetItemPrefab(5110001);
            //MeleeHitDetector broadBladeMHD = broadBlade.gameObject.AddComponent<MeleeHitDetector>();
            //MeleeHitDetector fGBMHD = fGB.gameObject.AddComponent<MeleeHitDetector>();
            //fGBMHD.Damage = broadBladeMHD.Damage;
            //fGBMHD.Impact = broadBladeMHD.Impact;
            //fGBMHD.Radius = broadBladeMHD.Radius;
            //fGBMHD.Unblockable = broadBladeMHD.Unblockable;
            //fGBMHD.LinecastCount = broadBladeMHD.LinecastCount;
            //fGBMHD.m_linecastStart = broadBladeMHD.m_linecastStart;
            //fGBMHD.LinecastTrans = broadBladeMHD.LinecastTrans;
            //fGBMHD.WeaponCenter.Set(broadBladeMHD.WeaponCenter.x, broadBladeMHD.WeaponCenter.y, broadBladeMHD.WeaponCenter.z);
        }
    }
}
