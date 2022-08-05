using SideLoader;
using UnityEngine;
using System.IO;
using SLExtensions;
using SideLoader_ExtendedEffects;
using System.Collections.Generic;

namespace GMP
{
    public class GMPEffects
    {
        public const string BANDAGE_REFERENCE_FAMILY_ID = "GMP_Bandages";
        public const string FIREFLY_REFERENCE_FAMILY_ID = "GMP_Firefly";

        public const int BETTER_BANDAGE_EFFECT_ID = -31098;
        public const string BETTER_BANDAGE_EFFECT_NAME = "Better_Bandage";

        public const int HQ_BANDAGE_EFFECT_ID = -31800;
        public const string HQ_BANDAGE_EFFECT_NAME = "HQ_Bandage";
        public const float HQ_BANDAGE_EFFECT_MAXHEALTH_ADD = 10f;

        public const int CUR_BANDAGE_EFFECT_ID = -31801;
        public const string CUR_BANDAGE_EFFECT_NAME = "Curative_Protection";
        public const float CUR_BANDAGE_EFFECT_RESIST_ADD = 10f;

        public const int HW_BANDAGE_EFFECT_ID = -31802;
        public const string HW_BANDAGE_EFFECT_NAME = "HW_Protection";
        public const float HW_BANDAGE_EFFECT_RESIST_ADD = 20f;
        public const float HW_BANDAGE_EFFECT_ENV_ADD = 8f;

        public const int COOL_BANDAGE_EFFECT_ID = -31803;
        public const string COOL_BANDAGE_EFFECT_NAME = "Cooling_Protection";
        public const float COOL_BANDAGE_EFFECT_RESIST_ADD = 20f;
        public const float COOL_BANDAGE_EFFECT_ENV_ADD = 8f;

        public const int RESTO_BANDAGE_EFFECT_ID = -31804;
        public const string RESTO_BANDAGE_EFFECT_NAME = "Resto_Bandage";
        public const float RESTO_BANDAGE_EFFECT_MAXHEALTH_ADD = 20f;

        public const int LUCKY_DICE_EFFECT_ID = -31830;
        public const string LUCKY_DICE_EFFECT_NAME = "Lucky_Dice";
        public const float LUCKY_DICE_EFFECT_DURATION = 600f;
        public const string LUCKY_DICE_REFERENCE_FAMILY_ID = "GMP_LuckyDice";

        public const int FIREFLY_EFFECT_ID = -31870;
        public const string FIREFLY_EFFECT_NAME = "Firefly_Puree";
        public const float FIREFLY_EFFECT_DURATION = 600f;

        public static void Init()
        {
            SetUpFamily();
            SetUpEffects();
        }

        public static void SetUpFamily()
        {
            // Set up effect family
            SL_StatusEffectFamily bandageFamily = new SL_StatusEffectFamily
            {
                UID = BANDAGE_REFERENCE_FAMILY_ID,
                StackBehaviour = StatusEffectFamily.StackBehaviors.IndependantUnique,
                MaxStackCount = -1,
                LengthType = StatusEffectFamily.LengthTypes.Short
            };
            bandageFamily.ApplyTemplate();

            SL_StatusEffectFamily luckyDiceFamily = new SL_StatusEffectFamily
            {
                UID = LUCKY_DICE_REFERENCE_FAMILY_ID,
                StackBehaviour = StatusEffectFamily.StackBehaviors.StackAll,
                MaxStackCount = 2,
                LengthType = StatusEffectFamily.LengthTypes.Short
            };
            luckyDiceFamily.ApplyTemplate();

            SL_StatusEffectFamily fireflyFamily = new SL_StatusEffectFamily
            {
                UID = FIREFLY_REFERENCE_FAMILY_ID,
                StackBehaviour = StatusEffectFamily.StackBehaviors.Override,
                MaxStackCount = 1,
                LengthType = StatusEffectFamily.LengthTypes.Short
            };
            fireflyFamily.ApplyTemplate();
        }

        internal static void SetUpEffects()
        {
            SetUpBetterBandage();
            SetUpHQ();
            SetUpResto();
            SetUpCurative();
            SetUpHW();
            SetUpCooling();
            SetUpLuckyDice();
            SetUpMisc();
        }

        public static void SetUpBetterBandage()
        {
            SL_StatusEffect bandageEffect = new SL_StatusEffect
            {
                TargetStatusIdentifier = "Health Recovery Small",
                NewStatusID = BETTER_BANDAGE_EFFECT_ID,
                StatusIdentifier = BETTER_BANDAGE_EFFECT_NAME,
                Name = "Better Banadage",
                Description = "Recover a bonus 0.2 health per second.",
                Purgeable = true,
                DisplayedInHUD = true,
                IsMalusEffect = false,
                Lifespan = 40f,
                RefreshRate = 1f,
                AmplifiedStatusIdentifier = string.Empty,
                FamilyMode = StatusEffect.FamilyModes.Reference,
                ReferenceFamilyUID = BANDAGE_REFERENCE_FAMILY_ID,
                EffectBehaviour = EditBehaviours.Override,
            };
            bandageEffect.SLPackName = Plugin.PACKID;
            bandageEffect.ApplyTemplate();
            bandageEffect.ApplyIcon();
        }

        public static void SetUpHQ()
        {
            SL_StatusEffect bandageEffect = new SL_StatusEffect
            {
                TargetStatusIdentifier = "Health Recovery 3",
                NewStatusID = HQ_BANDAGE_EFFECT_ID,
                StatusIdentifier = HQ_BANDAGE_EFFECT_NAME,
                Name = "High Quality Banadage",
                Description = "Recover a bonus 0.3 health per second.",
                Purgeable = true,
                DisplayedInHUD = true,
                IsMalusEffect = false,
                Lifespan = 40f,
                RefreshRate = 1f,
                AmplifiedStatusIdentifier = string.Empty,
                FamilyMode = StatusEffect.FamilyModes.Reference,
                ReferenceFamilyUID = BANDAGE_REFERENCE_FAMILY_ID,
                EffectBehaviour = EditBehaviours.Override,
            };
            bandageEffect.SLPackName = Plugin.PACKID;
            bandageEffect.ApplyTemplate();
            bandageEffect.ApplyIcon();
        }

        public static void SetUpResto()
        {
            SL_StatusEffect bandageEffect = new SL_StatusEffect
            {
                TargetStatusIdentifier = "Health Recovery 5",
                NewStatusID = RESTO_BANDAGE_EFFECT_ID,
                StatusIdentifier = RESTO_BANDAGE_EFFECT_NAME,
                Name = "Restorative Banadage",
                Description = "Recover a bonus 0.5 health per second.",
                Purgeable = true,
                DisplayedInHUD = true,
                IsMalusEffect = false,
                Lifespan = 40f,
                RefreshRate = 1f,
                AmplifiedStatusIdentifier = string.Empty,
                FamilyMode = StatusEffect.FamilyModes.Reference,
                ReferenceFamilyUID = BANDAGE_REFERENCE_FAMILY_ID,
                EffectBehaviour = EditBehaviours.Override,
            };
            bandageEffect.SLPackName = Plugin.PACKID;
            bandageEffect.ApplyTemplate();
            bandageEffect.ApplyIcon();
        }

        public static void SetUpCurative()
        {
            SL_StatusEffect bandageEffect = new SL_StatusEffect
            {
                TargetStatusIdentifier = "Possessed",
                NewStatusID = CUR_BANDAGE_EFFECT_ID,
                StatusIdentifier = CUR_BANDAGE_EFFECT_NAME,
                Name = "Curative Banadage",
                Description = "Increased Decay Resistance.",
                Purgeable = true,
                DisplayedInHUD = true,
                IsMalusEffect = false,
                Lifespan = 240f,
                RefreshRate = 1f,
                AmplifiedStatusIdentifier = string.Empty,
                FamilyMode = StatusEffect.FamilyModes.Reference,
                ReferenceFamilyUID = BANDAGE_REFERENCE_FAMILY_ID,
                EffectBehaviour = EditBehaviours.Destroy,
                Effects = new SL_EffectTransform[]
                {
                    new SL_EffectTransform
                    {
                        TransformName = "Normal",
                        Effects = new SL_Effect[]
                        {
                            new SL_AffectStat { Stat_Tag = "DecayResistance", AffectQuantity = CUR_BANDAGE_EFFECT_RESIST_ADD }
                        }
                    }
                }
            };
            bandageEffect.SLPackName = Plugin.PACKID;
            bandageEffect.ApplyTemplate();
            bandageEffect.ApplyIcon();
        }

        public static void SetUpHW()
        {
            SL_StatusEffect bandageEffect = new SL_StatusEffect
            {
                TargetStatusIdentifier = "Warm",
                NewStatusID = HW_BANDAGE_EFFECT_ID,
                StatusIdentifier = HW_BANDAGE_EFFECT_NAME,
                Name = "Heavy Wool Bandage",
                Description = "Increased Cold Resistance and protection from cold weather.",
                Purgeable = true,
                DisplayedInHUD = true,
                IsMalusEffect = false,
                Lifespan = 240f,
                RefreshRate = 1f,
                AmplifiedStatusIdentifier = string.Empty,
                FamilyMode = StatusEffect.FamilyModes.Reference,
                ReferenceFamilyUID = BANDAGE_REFERENCE_FAMILY_ID,
                EffectBehaviour = EditBehaviours.Destroy,
                Effects = new SL_EffectTransform[]
                {
                    new SL_EffectTransform
                    {
                        TransformName = "Normal",
                        Effects = new SL_Effect[]
                        {
                            new SL_AffectStat { Stat_Tag = "FrostResistance", AffectQuantity = HW_BANDAGE_EFFECT_RESIST_ADD },
                            new SL_AffectStat { Stat_Tag = "EnvColdProtection", AffectQuantity = HW_BANDAGE_EFFECT_ENV_ADD }
                        }
                    }
                }
            };
            bandageEffect.SLPackName = Plugin.PACKID;
            bandageEffect.ApplyTemplate();
            bandageEffect.ApplyIcon();
        }

        public static void SetUpCooling()
        {
            SL_StatusEffect bandageEffect = new SL_StatusEffect
            {
                TargetStatusIdentifier = "Cool",
                NewStatusID = COOL_BANDAGE_EFFECT_ID,
                StatusIdentifier = COOL_BANDAGE_EFFECT_NAME,
                Name = "Cooling Bandage",
                Description = "Increased Heat Resistance and protection from hot weather.",
                Purgeable = true,
                DisplayedInHUD = true,
                IsMalusEffect = false,
                Lifespan = 240f,
                RefreshRate = 1f,
                AmplifiedStatusIdentifier = string.Empty,
                FamilyMode = StatusEffect.FamilyModes.Reference,
                ReferenceFamilyUID = BANDAGE_REFERENCE_FAMILY_ID,
                EffectBehaviour = EditBehaviours.Destroy,
                Effects = new SL_EffectTransform[]
                {
                    new SL_EffectTransform
                    {
                        TransformName = "Effects",
                        Effects = new SL_Effect[]
                        {
                            new SL_AffectStat { Stat_Tag = "FireResistance", AffectQuantity = COOL_BANDAGE_EFFECT_RESIST_ADD },
                            new SL_AffectStat { Stat_Tag = "EnvHeatProtection", AffectQuantity = COOL_BANDAGE_EFFECT_ENV_ADD }
                        }
                    }
                }
            };
            bandageEffect.SLPackName = Plugin.PACKID;
            bandageEffect.ApplyTemplate();
            bandageEffect.ApplyIcon();
        }

        private static void SetUpLuckyDice()
        {
            // Strictly to show the Lucky Dice effect icon in addition to the RandomEffect from the item(and to know that the dice have been used within the re-use cycle time
            SL_StatusEffect luckyDiceEffect = new SL_StatusEffect
            {
                TargetStatusIdentifier = "Bless",
                NewStatusID = LUCKY_DICE_EFFECT_ID,
                StatusIdentifier = LUCKY_DICE_EFFECT_NAME,
                Name = "Lucky Dice",
                Description = "The chaotic effects of the dice only seem to work once every 10 minutes.",
                Purgeable = true, //? CHANGE TO FALSE AFTER TESTING
                DisplayedInHUD = true,
                IsMalusEffect = false,
                Lifespan = LUCKY_DICE_EFFECT_DURATION,
                AmplifiedStatusIdentifier = string.Empty,
                FamilyMode = StatusEffect.FamilyModes.Reference,
                ReferenceFamilyUID = LUCKY_DICE_REFERENCE_FAMILY_ID,
                EffectBehaviour = EditBehaviours.DestroyEffects,
            };
            luckyDiceEffect.SLPackName = Plugin.PACKID;
            luckyDiceEffect.ApplyTemplate();
            luckyDiceEffect.ApplyIcon();
        }

        private static void SetUpMisc()
        {
            SL_StatusEffect firefly = new SL_StatusEffect
            {
                TargetStatusIdentifier = "Pouch Over Encumbered",
                NewStatusID = FIREFLY_EFFECT_ID,
                StatusIdentifier = FIREFLY_EFFECT_NAME,
                Name = "Reanimated Fireflies",
                Description = "The essence of fireflies.",
                Purgeable = true,
                //RefreshRate = FIREFLY_EFFECT_DURATION,
                DisplayedInHUD = true,
                IsMalusEffect = false,
                Lifespan = FIREFLY_EFFECT_DURATION,
                AmplifiedStatusIdentifier = string.Empty,
                FamilyMode = StatusEffect.FamilyModes.Reference,
                ReferenceFamilyUID = FIREFLY_REFERENCE_FAMILY_ID,
                EffectBehaviour = EditBehaviours.Destroy,
                Effects = new SL_EffectTransform[]
                {
                    new SL_EffectTransform
                    {
                        TransformName = "Effects",
                        Effects = new SL_Effect[]
                        {
                            new FireFlyEffectTemplate()
                        }
                    },
                }
            };
            firefly.SLPackName = Plugin.PACKID;
            firefly.ApplyTemplate();
            firefly.ApplyIcon();
        }
    }
}


