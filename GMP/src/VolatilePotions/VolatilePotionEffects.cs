using System.Collections.Generic;
using SideLoader;
using SLExtensions;
using UnityEngine;

namespace GMP
{
    public class VolatilePotionEffects
    {
        public const string EP_FAMILY = "GMP_ExtendedPotions";
        public const string VP_FAMILY = "GMP_VolatilePotions";

        public const float VP_ELE_PROTECT = 1000f;
        public const float VP_PHYRES = 50f;
        public const float VP_IMPRES = 50f;
        public const float VP_BAR = 15f;
        public const float VP_HEALTHBURN = -25f;
        public const float VP_STAMINABURN = -25f;
        public const int VP_DEATHCHANCE = 10;

        public const int VP_ETHEREALPROTECT_EFFECT_ID = -31825;
        public const string VP_ETHEREALPROTECT_EFFECT_NAME = "VP_EtherealProtection";

        public const int VP_DECAYROTECT_EFFECT_ID = -31826;
        public const string VP_DECAYPROTECT_EFFECT_NAME = "VP_DecayProtection";

        public const int VP_LIGHTNINGPROTECT_EFFECT_ID = -31827;
        public const string VP_LIGHTNINGPROTECT_EFFECT_NAME = "VP_LightningProtection";

        public const int VP_FROSTPROTECT_EFFECT_ID = -31828;
        public const string VP_FROSTPROTECT_EFFECT_NAME = "VP_FrostProtection";

        public const int VP_FIREPROTECT_EFFECT_ID = -31829;
        public const string VP_FIREPROTECT_EFFECT_NAME = "VP_FireProtection";


        public static void Init()
        {
            SetUpFamilies();
            SetUpEffects();
        }

        private static void SetUpFamilies()
        {
            SL_StatusEffectFamily epFamily = new SL_StatusEffectFamily
            {
                UID = EP_FAMILY,
                StackBehaviour = StatusEffectFamily.StackBehaviors.IndependantUnique,
                MaxStackCount = 1,
                LengthType = StatusEffectFamily.LengthTypes.Short
            };
            epFamily.ApplyTemplate();

            SL_StatusEffectFamily vpFamily = new SL_StatusEffectFamily
            {
                UID = VP_FAMILY,
                StackBehaviour = StatusEffectFamily.StackBehaviors.Override,
                MaxStackCount = 1,
                LengthType = StatusEffectFamily.LengthTypes.Short
            };
            vpFamily.ApplyTemplate();
        }

        private static void SetUpEffects()
        {
            SL_StatusEffect etherealP = new SL_StatusEffect
            {
                TargetStatusIdentifier = "Mist",
                NewStatusID = VP_ETHEREALPROTECT_EFFECT_ID,
                StatusIdentifier = VP_ETHEREALPROTECT_EFFECT_NAME,
                Name = "Volatile Ethereal Protection",
                Description = "Immunity to ethereal. 50% physical resistance. 15 barrier. Burns 25 health and stamina.",
                Purgeable = true,
                DisplayedInHUD = true,
                IsMalusEffect = false,
                Lifespan = 60,
                AmplifiedStatusIdentifier = string.Empty,
                FamilyMode = StatusEffect.FamilyModes.Reference,
                ReferenceFamilyUID = VP_FAMILY,
                EffectBehaviour = EditBehaviours.Destroy,
                Effects = new SL_EffectTransform[]
                {
                    new SL_EffectTransform
                    {
                        TransformName = "Effect",
                        Effects = new SL_Effect[]
                        {
                            new SL_PlayVFX { VFXPrefab = SL_PlayVFX.VFXPrefabs.VFXBoonEthereal },
                            new SL_AffectStat { Stat_Tag = "EtherealProtection", AffectQuantity = VP_ELE_PROTECT, IsModifier = false},
                            new SL_AffectStat { Stat_Tag = "PhysicalResistance", AffectQuantity = VP_PHYRES, IsModifier = false },
                            new SL_AffectStat { Stat_Tag = "Barrier", AffectQuantity = VP_BAR, IsModifier = false }
                        }
                    },
                }
            };
            etherealP.SLPackName = Plugin.PACKID;
            etherealP.ApplyTemplate();
            etherealP.ApplyIcon();

            SL_StatusEffect decayP = new SL_StatusEffect
            {
                TargetStatusIdentifier = "Mist",
                NewStatusID = VP_DECAYROTECT_EFFECT_ID,
                StatusIdentifier = VP_DECAYPROTECT_EFFECT_NAME,
                Name = "Volatile Decay Protection",
                Description = "Immunity to decay. 50% physical resistance. 15 barrier. Burns 25 health and stamina.",
                Purgeable = true,
                DisplayedInHUD = true,
                IsMalusEffect = false,
                Lifespan = 60,
                AmplifiedStatusIdentifier = string.Empty,
                FamilyMode = StatusEffect.FamilyModes.Reference,
                ReferenceFamilyUID = VP_FAMILY,
                EffectBehaviour = EditBehaviours.Destroy,
                Effects = new SL_EffectTransform[]
               {
                    new SL_EffectTransform
                    {
                        TransformName = "Effect",
                        Effects = new SL_Effect[]
                        {
                            new SL_PlayVFX { VFXPrefab = SL_PlayVFX.VFXPrefabs.VFXBoonDecay },
                            new SL_AffectStat { Stat_Tag = "DecayProtection", AffectQuantity = VP_ELE_PROTECT, IsModifier = false},
                            new SL_AffectStat { Stat_Tag = "PhysicalResistance", AffectQuantity = VP_PHYRES, IsModifier = false },
                            new SL_AffectStat { Stat_Tag = "Barrier", AffectQuantity = VP_BAR, IsModifier = false }
                        }
                    },
               }
            };
            decayP.SLPackName = Plugin.PACKID;
            decayP.ApplyTemplate();
            decayP.ApplyIcon();

            SL_StatusEffect lightningP = new SL_StatusEffect
            {
                TargetStatusIdentifier = "Bless",
                NewStatusID = VP_LIGHTNINGPROTECT_EFFECT_ID,
                StatusIdentifier = VP_LIGHTNINGPROTECT_EFFECT_NAME,
                Name = "Volatile Lightning Protection",
                Description = "Immunity to lightning. 50% physical resistance. 15 barrier. Burns 25 health and stamina.",
                Purgeable = true,
                DisplayedInHUD = true,
                IsMalusEffect = false,
                Lifespan = 60,
                AmplifiedStatusIdentifier = string.Empty,
                FamilyMode = StatusEffect.FamilyModes.Reference,
                ReferenceFamilyUID = VP_FAMILY,
                EffectBehaviour = EditBehaviours.Destroy,
                Effects = new SL_EffectTransform[]
                {
                    new SL_EffectTransform
                    {
                        TransformName = "Effect",
                        Effects = new SL_Effect[]
                        {
                            new SL_PlayVFX { VFXPrefab = SL_PlayVFX.VFXPrefabs.VFXBoonBolt },
                            new SL_AffectStat { Stat_Tag = "ElectricProtection", AffectQuantity = VP_ELE_PROTECT, IsModifier = false},
                            new SL_AffectStat { Stat_Tag = "PhysicalResistance", AffectQuantity = VP_PHYRES, IsModifier = false },
                            new SL_AffectStat { Stat_Tag = "Barrier", AffectQuantity = VP_BAR, IsModifier = false }
                        }
                    },
                }
            };
            lightningP.SLPackName = Plugin.PACKID;
            lightningP.ApplyTemplate();
            lightningP.ApplyIcon();

            SL_StatusEffect frostP = new SL_StatusEffect
            {
                TargetStatusIdentifier = "Cool",
                NewStatusID = VP_FROSTPROTECT_EFFECT_ID,
                StatusIdentifier = VP_FROSTPROTECT_EFFECT_NAME,
                Name = "Volatile Frost Protection",
                Description = "Immunity to frost. 50% physical resistance. 15 barrier. Burns 25 health and stamina.",
                Purgeable = true,
                DisplayedInHUD = true,
                IsMalusEffect = false,
                Lifespan = 60,
                AmplifiedStatusIdentifier = string.Empty,
                FamilyMode = StatusEffect.FamilyModes.Reference,
                ReferenceFamilyUID = VP_FAMILY,
                EffectBehaviour = EditBehaviours.Destroy,
                Effects = new SL_EffectTransform[]
               {
                    new SL_EffectTransform
                    {
                        TransformName = "Effect",
                        Effects = new SL_Effect[]
                        {
                            new SL_PlayVFX { VFXPrefab = SL_PlayVFX.VFXPrefabs.VFXBoonIce },
                            new SL_AffectStat { Stat_Tag = "FrostProtection", AffectQuantity = VP_ELE_PROTECT, IsModifier = false},
                            new SL_AffectStat { Stat_Tag = "PhysicalResistance", AffectQuantity = VP_PHYRES, IsModifier = false },
                            new SL_AffectStat { Stat_Tag = "Barrier", AffectQuantity = VP_BAR, IsModifier = false }
                        }
                    },
               }
            };
            frostP.SLPackName = Plugin.PACKID;
            frostP.ApplyTemplate();
            frostP.ApplyIcon();

            SL_StatusEffect fireP = new SL_StatusEffect
            {
                TargetStatusIdentifier = "Warm",
                NewStatusID = VP_FIREPROTECT_EFFECT_ID,
                StatusIdentifier = VP_FIREPROTECT_EFFECT_NAME,
                Name = "Volatile Fire Protection",
                Description = "Immunity to fire. 50% physical resistance. 15 barrier. Burns 25 health and stamina.",
                Purgeable = true,
                DisplayedInHUD = true,
                IsMalusEffect = false,
                Lifespan = 60,
                AmplifiedStatusIdentifier = string.Empty,
                FamilyMode = StatusEffect.FamilyModes.Reference,
                ReferenceFamilyUID = VP_FAMILY,
                EffectBehaviour = EditBehaviours.Destroy,
                Effects = new SL_EffectTransform[]
               {
                    new SL_EffectTransform
                    {
                        TransformName = "Effect",
                        Effects = new SL_Effect[]
                        {
                            new SL_PlayVFX { VFXPrefab = SL_PlayVFX.VFXPrefabs.VFXBoonFire },
                            new SL_AffectStat { Stat_Tag = "FireProtection", AffectQuantity = VP_ELE_PROTECT, IsModifier = false},
                            new SL_AffectStat { Stat_Tag = "PhysicalResistance", AffectQuantity = VP_PHYRES, IsModifier = false },
                            new SL_AffectStat { Stat_Tag = "Barrier", AffectQuantity = VP_BAR, IsModifier = false }
                        }
                    },
               }
            };
            fireP.SLPackName = Plugin.PACKID;
            fireP.ApplyTemplate();
            fireP.ApplyIcon();
        }
    }

}

