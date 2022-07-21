using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;
using SideLoader;
using GMP.Effects;
using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// RENAME 'OutwardModTemplate' TO SOMETHING ELSE
namespace GMP
{
    [BepInPlugin(GUID, NAME, VERSION)]
    public class Plugin : BaseUnityPlugin
    {

        // Choose a GUID for your project. Change "myname" and "mymod".
        public const string GUID = "gothiska.GMP";
        // Choose a NAME for your project, generally the same as your Assembly Name.
        public const string NAME = "GMP - Gothiska Mod Pack";
        // Increment the VERSION when you release a new version of your mod.
        public const string VERSION = "0.1.0";

        // For accessing your BepInEx Logger from outside of this class (eg Plugin.Log.LogMessage("");)
        internal static ManualLogSource Log;

        // If you need settings, define them like so:
        // public static ConfigEntry<bool> ExampleConfig;

        public const int DEF_BANDAGE = 4400010;

        public const int HQ_BANDAGE = -31100;
        public const int CUR_BANDAGE = -31101;
        public const int HW_BANDAGE = -31102;
        public const int COOL_BANDAGE = -31103;
        public const int RESTO_BANDAGE = -31104;

        const float BANDAGE_WEIGHT = 0.4f;

        const int HQ_BANDAGE_VAL = 45;
        const int CUR_BANDAGE_VAL = 21;
        const int HW_BANDAGE_VAL = 21;
        const int COOL_BANDAGE_VAL = 21;
        const int RESTO_BANDAGE_VAL = 90;

        // Awake is called when your plugin is created. Use this to set up your mod.
        internal void Awake()
        {
            Log = this.Logger;
            Log.LogMessage($"Successfully loaded {NAME} {VERSION}!");

            // Any config settings you define should be set up like this:
            // ExampleConfig = Config.Bind("ExampleCategory", "ExampleSetting", false, "This is an example setting.");

            // Harmony is for patching methods. If you're not patching anything, you can comment-out or delete this line.
            Harmony.CreateAndPatchAll(typeof(Harmonize));

            SL.BeforePacksLoaded += SL_BeforePacksLoaded;
            SL.OnPacksLoaded += SL_OnPacksLoaded;
        }

        private void Update()
        {
            // hurt self to test
            if (Input.GetKeyUp(KeyCode.KeypadMinus))
            {
                Character myChar = CharacterManager.Instance.GetFirstLocalCharacter();
                myChar.StatusEffectMngr.AddStatusEffect("Bleeding");
                myChar.StatusEffectMngr.AddStatusEffect("Poisoned"); 
            }

            if (Input.GetKeyUp(KeyCode.KeypadPlus))
            {
                Character myChar = CharacterManager.Instance.GetFirstLocalCharacter();
                myChar.StatusEffectMngr.RemoveShortStatuses();
            }

            if (Input.GetKeyUp(KeyCode.KeypadPeriod))
            {
                Character myChar = CharacterManager.Instance.GetFirstLocalCharacter();
                Log.LogMessage("Decay resist: " + myChar.Stats.m_totalDamageResistance[2]);
                Log.LogMessage("Frost resist: " + myChar.Stats.m_totalDamageResistance[4]);
                Log.LogMessage("Cold Weather Defense: " + myChar.Stats.m_coldProtection);
            }
        }
        private void SL_BeforePacksLoaded()
        {
            
        }

        private void SL_OnPacksLoaded()
        {
            GMPEffects.Init();
            CreateBandages();
        }

        internal void CreateBandages()
        {
            Character myChar = CharacterManager.Instance.GetFirstLocalCharacter();
            SL_Item hqBandage = new SL_Item() //? DONE
            {
                Target_ItemID = DEF_BANDAGE,
                New_ItemID = HQ_BANDAGE,
                Name = "High Quality Bandage",
                Description = "A bandage made of higher quality material and soaked in a healing solution.",
                StatsHolder = new SL_ItemStats { BaseValue = HQ_BANDAGE_VAL, RawWeight = BANDAGE_WEIGHT },
                EffectBehaviour = EditBehaviours.Override,
                EffectTransforms = new SL_EffectTransform[]
                {
                    new SL_EffectTransform
                    {
                        TransformName = "Normal",
                        Effects = new SL_Effect[]
                        {
                            new SL_AddStatusEffect { StatusEffect = GMPEffects.HQ_BANDAGE_EFFECT_NAME, ChanceToContract = 100 },
                            new SL_AffectBurntHealth { AffectQuantity = GMPEffects.HQ_BANDAGE_EFFECT_MAXHEALTH_ADD, IsModifier = false }
                        }
                    }
                }
            };
            hqBandage.SLPackName = "GMP";
            hqBandage.SubfolderName = "HQBandage";
            hqBandage.ApplyTemplate();

            SL_Item curBandage = new SL_Item()
            {
                Target_ItemID = DEF_BANDAGE,
                New_ItemID = CUR_BANDAGE,
                Name = "Curative Bandage",
                Description = "A bandage made of higher quality material and soaked in a curative solution.",
                StatsHolder = new SL_ItemStats { BaseValue = CUR_BANDAGE_VAL, RawWeight = BANDAGE_WEIGHT },
                EffectBehaviour = EditBehaviours.Override,
                EffectTransforms = new SL_EffectTransform[]
                {
                    new SL_EffectTransform
                    {
                        TransformName = "Normal",
                        Effects = new SL_Effect[]
                        {
                            new SL_RemoveStatusEffect { CleanseType = RemoveStatusEffect.RemoveTypes.StatusType, SelectorValue = "Poison"},
                            new SL_RemoveStatusEffect { CleanseType = RemoveStatusEffect.RemoveTypes.StatusType, SelectorValue = "Decay"},
                            new SL_AddStatusEffect { StatusEffect = GMPEffects.CUR_BANDAGE_EFFECT_NAME, ChanceToContract = 100 }
                        }
                    }
                }
            };
            curBandage.SLPackName = "GMP";
            curBandage.SubfolderName = "CurativeBandage";
            curBandage.ApplyTemplate();

            SL_Item hwBandage = new SL_Item()
            {
                Target_ItemID = DEF_BANDAGE,
                New_ItemID = HW_BANDAGE,
                Name = "Heavy Wool Bandage",
                Description = "A bandage made of higher quality material and fortified with thick hide soaked in a warming solution.",
                StatsHolder = new SL_ItemStats { BaseValue = HW_BANDAGE_VAL, RawWeight = BANDAGE_WEIGHT },
                EffectBehaviour = EditBehaviours.Override,
                EffectTransforms = new SL_EffectTransform[]
                {
                    new SL_EffectTransform
                    {
                        TransformName = "Normal",
                        Effects = new SL_Effect[]
                        {
                            new SL_RemoveStatusEffect { CleanseType = RemoveStatusEffect.RemoveTypes.StatusType, SelectorValue = "Chill"},
                            new SL_AddStatusEffect { StatusEffect = GMPEffects.HW_BANDAGE_EFFECT_NAME, ChanceToContract = 100 }
                        }
                    }
                }
            };
            hwBandage.SLPackName = "GMP";
            hwBandage.SubfolderName = "HWBandage";
            hwBandage.ApplyTemplate();

            SL_Item coolBandage = new SL_Item()
            {
                Target_ItemID = DEF_BANDAGE,
                New_ItemID = COOL_BANDAGE,
                Name = "Cooling Bandage",
                Description = "A bandage made of higher quality material and fortified with a breathable mesh soaked in a cooling solution.",
                StatsHolder = new SL_ItemStats { BaseValue = COOL_BANDAGE_VAL, RawWeight = BANDAGE_WEIGHT },
                EffectBehaviour = EditBehaviours.Override,
                EffectTransforms = new SL_EffectTransform[]
                {
                    new SL_EffectTransform
                    {
                        TransformName = "Normal",
                        Effects = new SL_Effect[]
                        {
                            new SL_RemoveStatusEffect { CleanseType = RemoveStatusEffect.RemoveTypes.StatusType, SelectorValue = "Burn"},
                            new SL_AffectStat { Stat_Tag = "FireResistance", AffectQuantity = 20, Duration = 240 },
                            new SL_AffectStat { Stat_Tag = "EnvHeatProtection", AffectQuantity = 8, Duration = 240 }
                        }
                    }
                }
            };
            coolBandage.SLPackName = "GMP";
            coolBandage.SubfolderName = "CoolingBandage";
            coolBandage.ApplyTemplate();

            SL_Item restoBandage = new SL_Item() //? done
            {
                Target_ItemID = DEF_BANDAGE,
                New_ItemID = RESTO_BANDAGE,
                Name = "Restorative Bandage",
                Description = "A bandage made of higher quality material and soaked in an extremely potent restorative solution.",
                StatsHolder = new SL_ItemStats { BaseValue = RESTO_BANDAGE_VAL, RawWeight = BANDAGE_WEIGHT },
                EffectBehaviour = EditBehaviours.Override,
                EffectTransforms = new SL_EffectTransform[]
                {
                    new SL_EffectTransform
                    {
                        TransformName = "Normal",
                        Effects = new SL_Effect[]
                        {
                            new SL_AddStatusEffect { StatusEffect = GMPEffects.RESTO_BANDAGE_EFFECT_NAME, ChanceToContract = 100 },
                            new SL_AffectBurntHealth { AffectQuantity = GMPEffects.RESTO_BANDAGE_EFFECT_MAXHEALTH_ADD, IsModifier = false }
                        }
                    }
                }
            };
            restoBandage.SLPackName = "GMP";
            restoBandage.SubfolderName = "RestorativeBandage";
            restoBandage.ApplyTemplate();
        }

        // This is an example of a Harmony patch.
        // If you're not using this, you should delete it.
        [HarmonyPatch(typeof(ResourcesPrefabManager), nameof(ResourcesPrefabManager.Load))]
        public class ResourcesPrefabManager_Load
        {
            static void Postfix()
            {
                // This is a "Postfix" (runs after original) on ResourcesPrefabManager.Load
                // For more documentation on Harmony, see the Harmony Wiki.
                // https://harmony.pardeike.net/
            }
        }
    }
}
