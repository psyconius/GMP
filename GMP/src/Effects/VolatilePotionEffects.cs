using System.Collections.Generic;
using SideLoader;
using SLExtensions;
using UnityEngine;

namespace GMP
{
    public class VolatilePotionEffects
    {
        // Families
        public const string EP_FAMILY = "GMP_ExtendedPotions";
        public const string VP_FAMILY = "GMP_VolatilePotions";

        // Extended Potions
        public const float EP_ELE_RESIST = 50f;

        public const int EP_ETHEREALRESIST_EFFECT_ID = -31020;
        public const string EP_ETHEREALRESIST_EFFECT_NAME = "EP_EtherealResist";
        public const int EP_DECAYRESIST_EFFECT_ID = -31021;
        public const string EP_DECAYRESIST_EFFECT_NAME = "EP_DecayResist";
        public const int EP_LIGHTNINGRESIST_EFFECT_ID = -31022;
        public const string EP_LIGHTNINGRESIST_EFFECT_NAME = "EP_LightningResist";
        public const int EP_FROSTRESIST_EFFECT_ID = -31023;
        public const string EP_FROSTRESIST_EFFECT_NAME = "EP_FrostResist";
        public const int EP_FIRERESIST_EFFECT_ID = -31024;
        public const string EP_FIRERESIST_EFFECT_NAME = "EP_FireResist";

        // Volatile Potions
        public const float VP_ELE_PROTECT = 10000f;
        public const float VP_PHYRES = 50f;
        public const float VP_IMPRES = 50f;
        public const float VP_BAR = 15f;
        public const float VP_HEALTHBURN = -25f;
        public const float VP_STAMINABURN = -25f;
        public const int VP_DEATHCHANCE = 10;

        public const int VP_ETHEREALPROTECT_EFFECT_ID = -31865;
        public const string VP_ETHEREALPROTECT_EFFECT_NAME = "VP_EtherealProtection";

        public const int VP_DECAYROTECT_EFFECT_ID = -31866;
        public const string VP_DECAYPROTECT_EFFECT_NAME = "VP_DecayProtection";

        public const int VP_LIGHTNINGPROTECT_EFFECT_ID = -31867;
        public const string VP_LIGHTNINGPROTECT_EFFECT_NAME = "VP_LightningProtection";

        public const int VP_FROSTPROTECT_EFFECT_ID = -31868;
        public const string VP_FROSTPROTECT_EFFECT_NAME = "VP_FrostProtection";

        public const int VP_FIREPROTECT_EFFECT_ID = -31869;
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
            SL_StatusEffect etherealResist = new SL_StatusEffect
            {
                TargetStatusIdentifier = "Mist",
                NewStatusID = EP_ETHEREALRESIST_EFFECT_ID,
                StatusIdentifier = EP_ETHEREALRESIST_EFFECT_NAME,
                Name = "Potion of Ethereal Resistance",
                Description = "Adds 50% ethereal resistance.",
                Purgeable = true,
                DisplayedInHUD = true,
                IsMalusEffect = false,
                Lifespan = 120f,
                AmplifiedStatusIdentifier = string.Empty,
                FamilyMode = StatusEffect.FamilyModes.Reference,
                ReferenceFamilyUID = EP_FAMILY,
                EffectBehaviour = EditBehaviours.Destroy,
                Effects = new SL_EffectTransform[]
               {
                    new SL_EffectTransform
                    {
                        TransformName = "Effect",
                        Effects = new SL_Effect[]
                        {
                            new SL_AffectStat { Stat_Tag = "EtherealResistance", AffectQuantity = EP_ELE_RESIST, IsModifier = false },
                            new SL_PlayVFX { VFXPrefab = SL_PlayVFX.VFXPrefabs.VFXBoonEthereal }
                        }
                    },
               }
            };
            etherealResist.SLPackName = Plugin.PACKID;
            etherealResist.ApplyTemplate();
            etherealResist.ApplyIcon();

            SL_StatusEffect decayResist = new SL_StatusEffect
            {
                TargetStatusIdentifier = "Possessed",
                NewStatusID = EP_DECAYRESIST_EFFECT_ID,
                StatusIdentifier = EP_DECAYRESIST_EFFECT_NAME,
                Name = "Potion of Decay Resistance",
                Description = "Adds 50% decay resistance.",
                Purgeable = true,
                DisplayedInHUD = true,
                IsMalusEffect = false,
                Lifespan = 120f,
                AmplifiedStatusIdentifier = string.Empty,
                FamilyMode = StatusEffect.FamilyModes.Reference,
                ReferenceFamilyUID = EP_FAMILY,
                EffectBehaviour = EditBehaviours.Destroy,
                Effects = new SL_EffectTransform[]
               {
                    new SL_EffectTransform
                    {
                        TransformName = "Effect",
                        Effects = new SL_Effect[]
                        {
                            new SL_AffectStat { Stat_Tag = "DecayResistance", AffectQuantity = EP_ELE_RESIST, IsModifier = false },
                            new SL_PlayVFX { VFXPrefab = SL_PlayVFX.VFXPrefabs.VFXBoonDecay }
                        }
                    },
               }
            };
            decayResist.SLPackName = Plugin.PACKID;
            decayResist.ApplyTemplate();
            decayResist.ApplyIcon();

            SL_StatusEffect lightningResist = new SL_StatusEffect
            {
                TargetStatusIdentifier = "Bless",
                NewStatusID = EP_LIGHTNINGRESIST_EFFECT_ID,
                StatusIdentifier = EP_LIGHTNINGRESIST_EFFECT_NAME,
                Name = "Potion of Lightning Resistance",
                Description = "Adds 50% lightning resistance.",
                Purgeable = true,
                DisplayedInHUD = true,
                IsMalusEffect = false,
                Lifespan = 120f,
                AmplifiedStatusIdentifier = string.Empty,
                FamilyMode = StatusEffect.FamilyModes.Reference,
                ReferenceFamilyUID = EP_FAMILY,
                EffectBehaviour = EditBehaviours.Destroy,
                Effects = new SL_EffectTransform[]
               {
                    new SL_EffectTransform
                    {
                        TransformName = "Effect",
                        Effects = new SL_Effect[]
                        {
                            new SL_AffectStat { Stat_Tag = "ElectricResistance", AffectQuantity = EP_ELE_RESIST, IsModifier = false },
                            new SL_PlayVFX { VFXPrefab = SL_PlayVFX.VFXPrefabs.VFXBoonBolt }
                        }
                    },
               }
            };
            lightningResist.SLPackName = Plugin.PACKID;
            lightningResist.ApplyTemplate();
            lightningResist.ApplyIcon();

            SL_StatusEffect frostResist = new SL_StatusEffect
            {
                TargetStatusIdentifier = "Cool",
                NewStatusID = EP_FROSTRESIST_EFFECT_ID,
                StatusIdentifier = EP_FROSTRESIST_EFFECT_NAME,
                Name = "Potion of Frost Resistance",
                Description = "Adds 50% frost resistance.",
                Purgeable = true,
                DisplayedInHUD = true,
                IsMalusEffect = false,
                Lifespan = 120f,
                AmplifiedStatusIdentifier = string.Empty,
                FamilyMode = StatusEffect.FamilyModes.Reference,
                ReferenceFamilyUID = EP_FAMILY,
                EffectBehaviour = EditBehaviours.Destroy,
                Effects = new SL_EffectTransform[]
               {
                    new SL_EffectTransform
                    {
                        TransformName = "Effect",
                        Effects = new SL_Effect[]
                        {
                            new SL_AffectStat { Stat_Tag = "FrostResistance", AffectQuantity = EP_ELE_RESIST, IsModifier = false },
                            new SL_PlayVFX { VFXPrefab = SL_PlayVFX.VFXPrefabs.VFXBoonIce }
                        }
                    },
               }
            };
            frostResist.SLPackName = Plugin.PACKID;
            frostResist.ApplyTemplate();
            frostResist.ApplyIcon();

            SL_StatusEffect fireResist = new SL_StatusEffect
            {
                TargetStatusIdentifier = "Warm",
                NewStatusID = EP_FIRERESIST_EFFECT_ID,
                StatusIdentifier = EP_FIRERESIST_EFFECT_NAME,
                Name = "Potion of Fire Resistance",
                Description = "Adds 50% fire resistance.",
                Purgeable = true,
                DisplayedInHUD = true,
                IsMalusEffect = false,
                Lifespan = 120f,
                AmplifiedStatusIdentifier = string.Empty,
                FamilyMode = StatusEffect.FamilyModes.Reference,
                ReferenceFamilyUID = EP_FAMILY,
                EffectBehaviour = EditBehaviours.Destroy,
                Effects = new SL_EffectTransform[]
                {
                    new SL_EffectTransform
                    {
                        TransformName = "Effect",
                        Effects = new SL_Effect[]
                        {
                            new SL_AffectStat { Stat_Tag = "FireResistance", AffectQuantity = EP_ELE_RESIST, IsModifier = false },
                            new SL_PlayVFX { VFXPrefab = SL_PlayVFX.VFXPrefabs.VFXBoonFire }
                        }
                    },
                }
            };
            fireResist.SLPackName = Plugin.PACKID;
            fireResist.ApplyTemplate();
            fireResist.ApplyIcon();

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

