using System.Collections.Generic;
using SideLoader;
using SideLoader_ExtendedEffects;
using UnityEngine;

namespace GMP
{
    public class GMPItems
    {
        // Bandages
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

        // Dice
        public const int DICE = -31130;
        const float DICE_WEIGHT = 0.1f;
        const int DICE_VAL = 3;

        public const int FANCY_DICE = -31131;
        const float FANCY_DICE_WEIGHT = 0.2f;
        const int FANCY_DICE_VAL = 9;

        public const int BLANK_DICE = -31132;
        const float BLANK_DICE_WEIGHT = 0.3f;
        const int BLANK_DICE_VAL = 18;
       
        public const int LUCKY_DICE = -31133;
        const float LUCKY_DICE_WEIGHT = 0.5f;
        const int LUCKY_DICE_VAL = 300;

        public const int FIREFLY_PUREE = -31191;
        const float FIREFLY_PUREE_WEIGHT = 0.2f;
        const int FIREFLY_PUREE_VAL = 6;

        public static void CreateBandages()
        {
            Character myChar = CharacterManager.Instance.GetFirstLocalCharacter();
            SL_Item hqBandage = new SL_Item()
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
            hqBandage.SLPackName = Plugin.PACKID;
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
                            new SL_AddStatusEffect { StatusEffect = GMPEffects.CUR_BANDAGE_EFFECT_NAME, ChanceToContract = 100 },
                            new SL_AddStatusEffect { StatusEffect = GMPEffects.BETTER_BANDAGE_EFFECT_NAME, ChanceToContract = 100 }
                        }
                    }
                }
            };
            curBandage.SLPackName = Plugin.PACKID;
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
                            new SL_AddStatusEffect { StatusEffect = GMPEffects.HW_BANDAGE_EFFECT_NAME, ChanceToContract = 100 },
                            new SL_AddStatusEffect { StatusEffect = GMPEffects.BETTER_BANDAGE_EFFECT_NAME, ChanceToContract = 100 }
                        }
                    }
                }
            };
            hwBandage.SLPackName = Plugin.PACKID;
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
                            new SL_RemoveStatusEffect { CleanseType = RemoveStatusEffect.RemoveTypes.StatusType, SelectorValue = "Burning"},
                            new SL_RemoveStatusEffect { CleanseType = RemoveStatusEffect.RemoveTypes.StatusType, SelectorValue = "Scorch"},
                            new SL_AddStatusEffect { StatusEffect = GMPEffects.COOL_BANDAGE_EFFECT_NAME, ChanceToContract = 100 },
                            new SL_AddStatusEffect { StatusEffect = GMPEffects.BETTER_BANDAGE_EFFECT_NAME, ChanceToContract = 100 }
                        }
                    }
                }
            };
            coolBandage.SLPackName = Plugin.PACKID;
            coolBandage.SubfolderName = "CoolingBandage";
            coolBandage.ApplyTemplate();

            SL_Item restoBandage = new SL_Item()
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
            restoBandage.SLPackName = Plugin.PACKID;
            restoBandage.SubfolderName = "RestorativeBandage";
            restoBandage.ApplyTemplate();
        }

        //? Possibly sort this later
        public static void CreateMisc()
        {
            SL_Item dice = new SL_Item()
            {
                Target_ItemID = 6200070, // Tiny Aquamarine
                New_ItemID = DICE,
                Name = "Dice",
                Description = "A simple set of gaming dice. While gambling is technically illegal, they are commonly used in bandit camps, on ships, and generally anywhere people are bored.",
                StatsHolder = new SL_ItemStats { BaseValue = DICE_VAL, RawWeight = DICE_WEIGHT },
                QtyRemovedOnUse = 0,
                IsUsable = true,
                CastType = Character.SpellCastType.PickBerries,
                CastModifier = Character.SpellCastModifier.Immobilized,
                EffectBehaviour = EditBehaviours.Override,
                ItemVisuals = new SL_ItemVisual
                {
                    Prefab_SLPack = Plugin.PACKID,
                    Prefab_AssetBundle = "dice",
                    Prefab_Name = "dice"
                }
            };
            dice.SLPackName = Plugin.PACKID;
            dice.SubfolderName = "Dice";
            dice.ApplyTemplate();

            SL_Item fancyDice = new SL_Item()
            {
                Target_ItemID = 6200070, // Tiny Aquamarine
                New_ItemID = FANCY_DICE,
                Name = "Fancy Dice",
                Description = "A quality set of dice. A finer polish of a deocrative with specks of gold leaf in the dimples.",
                StatsHolder = new SL_ItemStats { BaseValue = FANCY_DICE_VAL, RawWeight = FANCY_DICE_WEIGHT },
                QtyRemovedOnUse = 0,
                IsUsable = true,
                CastType = Character.SpellCastType.PickBerries,
                CastModifier = Character.SpellCastModifier.Immobilized,
                EffectBehaviour = EditBehaviours.Override,
                ItemVisuals = new SL_ItemVisual
                {
                    Prefab_SLPack = Plugin.PACKID,
                    Prefab_AssetBundle = "dice",
                    Prefab_Name = "fancydice"
                }
            };
            fancyDice.SLPackName = Plugin.PACKID;
            fancyDice.SubfolderName = "FancyDice";
            fancyDice.ApplyTemplate();

            SL_Item luckyDice = new SL_Item()
            {
                Target_ItemID = 6200070, // Tiny Aquamarine
                New_ItemID = LUCKY_DICE,
                Name = "Lucky(?) Dice",
                Description = "A golden dice set. You can feel chaotic energy pulsating from them.. urging you to roll them.",
                StatsHolder = new SL_ItemStats { BaseValue = LUCKY_DICE_VAL, RawWeight = LUCKY_DICE_WEIGHT },
                GroupItemInDisplay = false,
                QtyRemovedOnUse = 0,
                IsUsable = true,
                CastType = Character.SpellCastType.PickBerries,
                CastModifier = Character.SpellCastModifier.Immobilized,
                CastSheatheRequired = 1,
                Tags = new string[] { "Item" },
                ItemExtensions = new SL_ItemExtension[]
                {
                    new SL_MultipleUsage { AutoStack = false, MaxStackAmount = 1 }
                },
                EffectBehaviour = EditBehaviours.Override,
                ItemVisuals = new SL_ItemVisual
                {
                    Prefab_SLPack = Plugin.PACKID,
                    Prefab_AssetBundle = "dice",
                    Prefab_Name = "luckydice"
                },
            };
            luckyDice.SLPackName = Plugin.PACKID;
            luckyDice.SubfolderName = "LuckyDice";
            luckyDice.ApplyTemplate();

            SL_Item fireflyPuree = new SL_Item()
            {
                Target_ItemID = 4300290, // Purity Potion
                New_ItemID = FIREFLY_PUREE,
                Name = "Vial of Firefly Puree",
                Description = "A vial filled with the essence of fireflies. Smash it to create a light source.",
                StatsHolder = new SL_ItemStats { BaseValue = LUCKY_DICE_VAL, RawWeight = LUCKY_DICE_WEIGHT },
                QtyRemovedOnUse = 1,
                IsUsable = true,
                CastType = Character.SpellCastType.Flint,
                CastModifier = Character.SpellCastModifier.Immobilized,
                CastSheatheRequired = 1,
                Tags = new string[] { "Item", "Consummable" },
                ItemExtensions = new SL_ItemExtension[]
                {
                    new SL_MultipleUsage { AutoStack = true, MaxStackAmount = 999 }
                },
                EffectBehaviour = EditBehaviours.Destroy,
                EffectTransforms = new SL_EffectTransform[]
                {
                    new SL_EffectTransform
                    {
                        TransformName = "Normal",
                        Effects = new SL_Effect[]
                        {
                            new SL_PlaySoundEffect { MinPitch = 1f, MaxPitch = 1f, Follow = true, Sounds = new List<GlobalAudioManager.Sounds> { GlobalAudioManager.Sounds.SFX_SKILL_Spark } },
                            new SL_AddStatusEffect { StatusEffect = GMPEffects.FIREFLY_EFFECT_NAME, ChanceToContract = 100 },
                            new SL_PlayAssetBundleVFX
                            {
                                SLPackName = Plugin.PACKID,
                                AssetBundleName = "fireflies",
                                PrefabName = "thefireflies",
                            },
                        }
                    }
                },
                //ItemVisuals = new SL_ItemVisual
                //{
                //    Prefab_SLPack = Plugin.PACKID,
                //    Prefab_AssetBundle = "dice",
                //    Prefab_Name = "luckydice"

                //},
            };
            fireflyPuree.SLPackName = Plugin.PACKID;
            fireflyPuree.SubfolderName = "FireflyPuree";
            fireflyPuree.ApplyTemplate();
        }
    }
}

