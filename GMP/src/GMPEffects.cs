using System;
using SideLoader;

namespace GMP.Effects
{
    public class GMPEffects
    {
        //public static GMPEffects Instance { get; private set; }

        public const string BANDAGE_REFERENCE_FAMILY_ID = "GMP Bandages";

        public const int HQ_BANDAGE_EFFECT_ID = -31120;
        public const string HQ_BANDAGE_EFFECT_NAME = "HQ Bandage Bonus Regen";
        public const int HQ_BANDAGE_EFFECT_MAXHEALTH_ADD = 10;

        public const int CUR_BANDAGE_EFFECT_ID = -31121;
        public const string CUR_BANDAGE_EFFECT_NAME = "Curative Protection Add";
        public const int CUR_BANDAGE_EFFECT_RESIST_ADD = 10;

        public const int HW_BANDAGE_EFFECT_ID = -31122;
        public const string HW_BANDAGE_EFFECT_NAME = "HW Protection Add";
        public const int HW_BANDAGE_EFFECT_RESIST_ADD = 20;
        public const int HW_BANDAGE_EFFECT_ENV_ADD = 8;

        public const int RESTO_BANDAGE_EFFECT_ID = -31124;
        public const string RESTO_BANDAGE_EFFECT_NAME = "Resto Bandage Bonus Regen";
        public const int RESTO_BANDAGE_EFFECT_MAXHEALTH_ADD = 20;


        private void Awake()
        {
            //Instance = this;
        }

        public static void Init()
        {
            SetUpFamily();
            SetUpEffects();
        }

        public static void SetUpFamily()
        {
            // Set up effect family
            SL_StatusEffectFamily family = new SL_StatusEffectFamily
            {
                UID = BANDAGE_REFERENCE_FAMILY_ID,
                StackBehaviour = StatusEffectFamily.StackBehaviors.IndependantUnique,
                MaxStackCount = -1,
                LengthType = StatusEffectFamily.LengthTypes.Short
            };
            family.ApplyTemplate();
        }

        internal static void SetUpEffects()
        { 
            SetUpHQ();
            SetUpResto();
            SetUpCurative();
            SetUpHW();
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
                ActionOnHit = StatusEffect.ActionsOnHit.None,
                DisplayedInHUD = true,
                IsMalusEffect = false,
                Lifespan = 40,
                RefreshRate = 1f,
                AmplifiedStatusIdentifier = string.Empty,
                FamilyMode = StatusEffect.FamilyModes.Reference,
                Priority = 1,
                ReferenceFamilyUID = BANDAGE_REFERENCE_FAMILY_ID,
                EffectBehaviour = EditBehaviours.Override,
            };
            //bandageEffect.SLPackName = "GMP";
            //bandageEffect.SubfolderName = "HQBandage";
            bandageEffect.ApplyTemplate();
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
                ActionOnHit = StatusEffect.ActionsOnHit.None,
                DisplayedInHUD = true,
                IsMalusEffect = false,
                Lifespan = 40,
                RefreshRate = 1f,
                AmplifiedStatusIdentifier = string.Empty,
                FamilyMode = StatusEffect.FamilyModes.Reference,
                Priority = 1,
                ReferenceFamilyUID = BANDAGE_REFERENCE_FAMILY_ID,
                EffectBehaviour = EditBehaviours.Override,
            };
            //bandageEffect.SLPackName = "GMP";
            //bandageEffect.SubfolderName = "RestoBandage";
            bandageEffect.ApplyTemplate();
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
                ActionOnHit = StatusEffect.ActionsOnHit.None,
                DisplayedInHUD = true,
                IsMalusEffect = false,
                Lifespan = 240,
                RefreshRate = 1f,
                AmplifiedStatusIdentifier = string.Empty,
                FamilyMode = StatusEffect.FamilyModes.Reference,
                Priority = 1,
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
            //bandageEffect.SLPackName = "GMP";
            //bandageEffect.SubfolderName = "CurativeBandage";
            bandageEffect.ApplyTemplate();
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
                ActionOnHit = StatusEffect.ActionsOnHit.None,
                DisplayedInHUD = true,
                IsMalusEffect = false,
                Lifespan = 240,
                RefreshRate = 1f,
                AmplifiedStatusIdentifier = string.Empty,
                FamilyMode = StatusEffect.FamilyModes.Reference,
                Priority = 1,
                ReferenceFamilyUID = BANDAGE_REFERENCE_FAMILY_ID,
                EffectBehaviour = EditBehaviours.Destroy,
                Effects = new SL_EffectTransform[]
                {
                    new SL_EffectTransform
                    {
                        TransformName = "Normal",
                        Effects = new SL_Effect[]
                        {
                            new SL_AffectStat { Stat_Tag = "ColdResistance", AffectQuantity = HW_BANDAGE_EFFECT_RESIST_ADD },
                            new SL_AffectStat { Stat_Tag = "EnvHeatProtection", AffectQuantity = HW_BANDAGE_EFFECT_ENV_ADD }
                        }
                    }
                }
            };
            //bandageEffect.SLPackName = "GMP";
            //bandageEffect.SubfolderName = "HWBandage";
            bandageEffect.ApplyTemplate();
        }
    }
}


