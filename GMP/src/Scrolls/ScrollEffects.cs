using System;
using System.Collections.Generic;
using SideLoader;
using SLExtensions;

namespace GMP
{
    public class ScrollEffects
    {
        private const string BLUE_SCROLL_FAMILY = "GMP_BlueScrolls";
        private const int BLUE_SCROLL_MAX_STACK = 3;

        public const int S_WARRIOR_EFFECT = -31850;
        public const string S_WARRIOR_EFFECT_NAME = "Scroll_Warrior";
        private const float S_WARRIOR_PHYATK = 20f;
        private const float S_WARRIOR_IMPATK = 30f;

        public const int S_MAGE_EFFECT = -31851;
        public const string S_MAGE_EFFECT_NAME = "Scroll_Mage";
        private const float S_MAGE_MANACOST = -20f;
        private const float S_MAGE_PHYRES = 15f;
        private const float S_MAGE_SHIMM = 20f;

        public const int S_STOUTNESS_EFFECT = -31852;
        public const string S_STOUTNESS_EFFECT_NAME = "Scroll_Stoutness";
        private const float S_STOUTNESS_IMPRES = 30f;
        private const float S_STOUTNESS_PHYRES = 20f;

        public const int S_ELEMRES_EFFECT = -31853;
        public const string S_ELEMRES_EFFECT_NAME = "Scroll_ElementalResistance";
        private const float S_ELEMRES_ELEMRES = 25f;
        private const float S_ELEMRES_ENVRES = 15f;

        public const int S_CHEETAH_EFFECT = -31854;
        public const string S_CHEETAH_EFFECT_NAME = "Scroll_Cheetah";
        private const float S_CHEETAH_SPEED = 30f;

        public const int S_SHIMMER_EFFECT = -31855;
        public const string S_SHIMMER_EFFECT_NAME = "Scroll_Shimmer";
        private const float S_SHIMMER_BAR = 8f;
        private const float S_SHIMMER_SHIMM = 15f;

        public const int S_LES_REGENERATION_EFFECT = -31856;
        public const string S_LES_REGENERATION_EFFECT_NAME = "Scroll_LesserRegeneration";

        public const int S_LES_REINVIGORATION_EFFECT = -31857;  
        public const string S_LES_REINVIGORATION_EFFECT_NAME = "Scroll_LesserReinvigoration";

        public const int S_LES_ACUITY_EFFECT = -31858;
        public const string S_LES_ACUITY_EFFECT_NAME = "Scroll_LesserAcuity";

        //?HERE
        public const int S_MAJ_REGENERATION_EFFECT = -31859;
        public const string S_MAJ_REGENERATION_EFFECT_NAME = "Scroll_MajorRegeneration";

        public const int S_MAJ_REINVIGORATION_EFFECT = -31860;
        public const string S_MAJ_REINVIGORATION_EFFECT_NAME = "Scroll_MajorReinvigoration";

        public const int S_MAJ_ACUITY_EFFECT = -31861;
        public const string S_MAJ_ACUITY_EFFECT_NAME = "Scroll_MajorAcuity";

        public const int S_MAJ_REJUVENATION_EFFECT = -31862;
        public const string S_MAJ_REJUVENATION_EFFECT_NAME = "Scroll_MajorRejuvenation";

        public const int S_MAJ_REFRESH_EFFECT = -31863;
        public const string S_MAJ_REFRESH_EFFECT_NAME = "Scroll_MajorRefresh";

        public const int S_MAJ_MENTALRESPITE_EFFECT = -31864;
        public const string S_MAJ_MENTALRESPITE_EFFECT_NAME = "Scroll_MajorMentalRespite";
        private const float S_MAJ_EFFECT_VAL = 50f;


        public static void Init()
        {
            SetUpFamilies();
            SetUpBlueScrolls();
        }

        private static void SetUpFamilies()
        {
            SL_StatusEffectFamily blueScrollFamily = new SL_StatusEffectFamily
            {
                UID = BLUE_SCROLL_FAMILY,
                StackBehaviour = StatusEffectFamily.StackBehaviors.IndependantUnique,
                MaxStackCount = 3,
                LengthType = StatusEffectFamily.LengthTypes.Short
            };
            blueScrollFamily.ApplyTemplate();
        }

        private static void SetUpBlueScrolls()
        {
            SL_StatusEffect warriorEffect = new SL_StatusEffect
            {
                TargetStatusIdentifier = "Rage",
                NewStatusID = S_WARRIOR_EFFECT,
                StatusIdentifier = S_WARRIOR_EFFECT_NAME,
                Name = "Scroll of the Warrior",
                Description = "Raises physical damage by 20% and impact damage by 30% for 10 minutes.",
                Purgeable = true,
                DisplayedInHUD = true,
                IsMalusEffect = false,
                Lifespan = 600f,
                AmplifiedStatusIdentifier = string.Empty,
                FamilyMode = StatusEffect.FamilyModes.Reference,
                ReferenceFamilyUID = BLUE_SCROLL_FAMILY,
                EffectBehaviour = EditBehaviours.Destroy,
                Effects = new SL_EffectTransform[]
                {
                    new SL_EffectTransform
                    {
                        TransformName = "Effect",
                        Effects = new SL_Effect[]
                        {
                            new SL_PlayVFX { VFXPrefab = SL_PlayVFX.VFXPrefabs.VFXRage },
                            new SL_AffectStat { Stat_Tag = "Impact", AffectQuantity = S_WARRIOR_IMPATK, IsModifier = true },
                            new SL_AffectStat { Stat_Tag = "PhysicalDamage", AffectQuantity = S_WARRIOR_PHYATK, IsModifier = true }
                        }
                    }
                }
            };
            warriorEffect.SLPackName = Plugin.PACKID;
            warriorEffect.ApplyTemplate();
            warriorEffect.ApplyIcon();

            SL_StatusEffect mageEffect = new SL_StatusEffect
            {
                TargetStatusIdentifier = "Gaberry Wine",
                NewStatusID = S_MAGE_EFFECT,
                StatusIdentifier = S_MAGE_EFFECT_NAME,
                Name = "Scroll of the Mage",
                Description = "Decreases mana use by 20%, raises physical protection by 15%, and increases all elemental damage by 15%.",
                Purgeable = true,
                DisplayedInHUD = true,
                IsMalusEffect = false,
                Lifespan = 600f,
                AmplifiedStatusIdentifier = string.Empty,
                FamilyMode = StatusEffect.FamilyModes.Reference,
                ReferenceFamilyUID = BLUE_SCROLL_FAMILY,
                EffectBehaviour = EditBehaviours.Destroy,
                Effects = new SL_EffectTransform[]
                {

                    new SL_EffectTransform
                    {
                        TransformName = "Effect",
                        Effects = new SL_Effect[]
                        {
                            new SL_AffectStat { Stat_Tag = "EtherealDamage", AffectQuantity = S_MAGE_SHIMM, IsModifier = true },
                            new SL_AffectStat { Stat_Tag = "DecayDamage", AffectQuantity = S_MAGE_SHIMM, IsModifier = true },
                            new SL_AffectStat { Stat_Tag = "ElectricDamage", AffectQuantity = S_MAGE_SHIMM, IsModifier = true },
                            new SL_AffectStat { Stat_Tag = "FrostDamage", AffectQuantity = S_MAGE_SHIMM, IsModifier = true },
                            new SL_AffectStat { Stat_Tag = "FireDamage", AffectQuantity = S_MAGE_SHIMM, IsModifier = true },
                            new SL_AffectStat { Stat_Tag = "PhysicalResistance", AffectQuantity = S_MAGE_PHYRES, IsModifier = false },
                            new SL_AffectStat { Stat_Tag = "ManaUse", AffectQuantity = S_MAGE_MANACOST, IsModifier = true }
                        }
                    },
                }
            };
            mageEffect.SLPackName = Plugin.PACKID;
            mageEffect.ApplyTemplate();
            mageEffect.ApplyIcon();

            SL_StatusEffect stoutEffect = new SL_StatusEffect
            {
                TargetStatusIdentifier = "Impact Up",
                NewStatusID = S_STOUTNESS_EFFECT,
                StatusIdentifier = S_STOUTNESS_EFFECT_NAME,
                Name = "Scroll of Stoutness",
                Description = "Increases impact resistance by 30% and physical resistance by 20%",
                Purgeable = true,
                DisplayedInHUD = true,
                IsMalusEffect = false,
                Lifespan = 600f,
                AmplifiedStatusIdentifier = string.Empty,
                FamilyMode = StatusEffect.FamilyModes.Reference,
                ReferenceFamilyUID = BLUE_SCROLL_FAMILY,
                EffectBehaviour = EditBehaviours.Destroy,
                Effects = new SL_EffectTransform[]
               {
                    new SL_EffectTransform
                    {
                        TransformName = "Effect",
                        Effects = new SL_Effect[]
                        {
                            new SL_AffectStat { Stat_Tag = "ImpactResistance", AffectQuantity = S_STOUTNESS_IMPRES, IsModifier = false },
                            new SL_AffectStat { Stat_Tag = "PhysicalResistance", AffectQuantity = S_STOUTNESS_PHYRES, IsModifier = false },
                        }
                    },
               }
            };
            stoutEffect.SLPackName = Plugin.PACKID;
            stoutEffect.ApplyTemplate();
            stoutEffect.ApplyIcon();

            SL_StatusEffect elemresEffect = new SL_StatusEffect
            {
                TargetStatusIdentifier = "Impact Up",
                NewStatusID = S_ELEMRES_EFFECT,
                StatusIdentifier = S_ELEMRES_EFFECT_NAME,
                Name = "Scroll of Elemental Resistance",
                Description = "Increases all elemental resistances by 25% and weather resistances by 15",
                Purgeable = true,
                DisplayedInHUD = true,
                IsMalusEffect = false,
                Lifespan = 600f,
                AmplifiedStatusIdentifier = string.Empty,
                FamilyMode = StatusEffect.FamilyModes.Reference,
                ReferenceFamilyUID = BLUE_SCROLL_FAMILY,
                EffectBehaviour = EditBehaviours.Destroy,
                Effects = new SL_EffectTransform[]
               {
                    new SL_EffectTransform
                    {
                        TransformName = "Effect",
                        Effects = new SL_Effect[]
                        {
                            new SL_AffectStat { Stat_Tag = "EtherealResistance", AffectQuantity = S_ELEMRES_ELEMRES, IsModifier = false },
                            new SL_AffectStat { Stat_Tag = "DecayResistance", AffectQuantity = S_ELEMRES_ELEMRES, IsModifier = false },
                            new SL_AffectStat { Stat_Tag = "ElectricResistance", AffectQuantity = S_ELEMRES_ELEMRES, IsModifier = false },
                            new SL_AffectStat { Stat_Tag = "FrostResistance", AffectQuantity = S_ELEMRES_ELEMRES, IsModifier = false },
                            new SL_AffectStat { Stat_Tag = "FireResistance", AffectQuantity = S_ELEMRES_ELEMRES, IsModifier = false },
                            new SL_AffectStat { Stat_Tag = "EnvColdProtection", AffectQuantity = S_ELEMRES_ENVRES, },
                            new SL_AffectStat { Stat_Tag = "EnvHeatProtection", AffectQuantity = S_ELEMRES_ENVRES, }
                        }
                    },
               }
            };
            elemresEffect.SLPackName = Plugin.PACKID;
            elemresEffect.ApplyTemplate();
            elemresEffect.ApplyIcon();

            SL_StatusEffect cheetahEffect = new SL_StatusEffect
            {
                TargetStatusIdentifier = "Speed Up",
                NewStatusID = S_CHEETAH_EFFECT,
                StatusIdentifier = S_CHEETAH_EFFECT_NAME,
                Name = "Scroll of the Cheetah",
                Description = "Increases movement speed by 30%.",
                Purgeable = true,
                DisplayedInHUD = true,
                IsMalusEffect = false,
                Lifespan = 300f,
                AmplifiedStatusIdentifier = string.Empty,
                FamilyMode = StatusEffect.FamilyModes.Reference,
                ReferenceFamilyUID = BLUE_SCROLL_FAMILY,
                EffectBehaviour = EditBehaviours.Destroy,
                Effects = new SL_EffectTransform[]
               {
                    new SL_EffectTransform
                    {
                        TransformName = "Effect",
                        Effects = new SL_Effect[]
                        {
                            new SL_PlayVFX { VFXPrefab = SL_PlayVFX.VFXPrefabs.VFXLeapAttack },
                            new SL_AffectStat { Stat_Tag = "MovementSpeed", AffectQuantity = S_CHEETAH_SPEED, IsModifier = true } 
                        }
                    },
               }
            };
            cheetahEffect.SLPackName = Plugin.PACKID;
            cheetahEffect.ApplyTemplate();
            cheetahEffect.ApplyIcon();

            SL_StatusEffect shimmerEffect = new SL_StatusEffect
            {
                TargetStatusIdentifier = "Speed Up",
                NewStatusID = S_SHIMMER_EFFECT,
                StatusIdentifier = S_SHIMMER_EFFECT_NAME,
                Name = "Scroll of Shimmering Barrer",
                Description = "Grants 8 barrier and +15% elemental resistance.",
                Purgeable = true,
                DisplayedInHUD = true,
                IsMalusEffect = false,
                Lifespan = 300f,
                AmplifiedStatusIdentifier = string.Empty,
                FamilyMode = StatusEffect.FamilyModes.Reference,
                ReferenceFamilyUID = BLUE_SCROLL_FAMILY,
                EffectBehaviour = EditBehaviours.Destroy,
                Effects = new SL_EffectTransform[]
               {
                    new SL_EffectTransform
                    {
                        TransformName = "Effect",
                        Effects = new SL_Effect[]
                        {
                            new SL_PlayVFX { VFXPrefab = SL_PlayVFX.VFXPrefabs.VFXForceBubble },
                            new SL_AffectStat { Stat_Tag = "EtherealResistance", AffectQuantity = S_SHIMMER_SHIMM, IsModifier = false },
                            new SL_AffectStat { Stat_Tag = "DecayResistance", AffectQuantity = S_SHIMMER_SHIMM, IsModifier = false },
                            new SL_AffectStat { Stat_Tag = "ElectricResistance", AffectQuantity = S_SHIMMER_SHIMM, IsModifier = false },
                            new SL_AffectStat { Stat_Tag = "FrostResistance", AffectQuantity = S_SHIMMER_SHIMM, IsModifier = false },
                            new SL_AffectStat { Stat_Tag = "FireResistance", AffectQuantity = S_SHIMMER_SHIMM, IsModifier = false },
                            new SL_AffectStat { Stat_Tag = "Barrier", AffectQuantity = S_SHIMMER_BAR, IsModifier = false }
                        }
                    },
               }
            };
            shimmerEffect.SLPackName = Plugin.PACKID;
            shimmerEffect.ApplyTemplate();
            shimmerEffect.ApplyIcon();

            SL_StatusEffect lesregenerationEffect = new SL_StatusEffect
            {
                TargetStatusIdentifier = "Health Recovery 2",
                NewStatusID = S_LES_REGENERATION_EFFECT,
                StatusIdentifier = S_LES_REGENERATION_EFFECT_NAME,
                Name = "Scroll of Lesser Regeneration",
                Description = "Regenerate 0.25 health per second.",
                Purgeable = true,
                DisplayedInHUD = true,
                IsMalusEffect = false,
                Lifespan = 300f,
                RefreshRate = 1f,
                AmplifiedStatusIdentifier = string.Empty,
                FamilyMode = StatusEffect.FamilyModes.Reference,
                ReferenceFamilyUID = BLUE_SCROLL_FAMILY,
                EffectBehaviour = EditBehaviours.NONE,
            };
            lesregenerationEffect.SLPackName = Plugin.PACKID;
            lesregenerationEffect.ApplyTemplate();
            lesregenerationEffect.ApplyIcon();

            SL_StatusEffect lesreinvigorationEffect = new SL_StatusEffect
            {
                TargetStatusIdentifier = "Stamina Recovery 2",
                NewStatusID = S_LES_REINVIGORATION_EFFECT,
                StatusIdentifier = S_LES_REINVIGORATION_EFFECT_NAME,
                Name = "Scroll of Lesser Reinvigoration",
                Description = "Regenerate 0.25 stamina per second.",
                Purgeable = true,
                DisplayedInHUD = true,
                IsMalusEffect = false,
                Lifespan = 300f,
                RefreshRate = 1f,
                AmplifiedStatusIdentifier = string.Empty,
                FamilyMode = StatusEffect.FamilyModes.Reference,
                ReferenceFamilyUID = BLUE_SCROLL_FAMILY,
                EffectBehaviour = EditBehaviours.NONE,
            };
            lesreinvigorationEffect.SLPackName = Plugin.PACKID;
            lesreinvigorationEffect.ApplyTemplate();
            lesreinvigorationEffect.ApplyIcon();

            SL_StatusEffect lesacuityEffect = new SL_StatusEffect
            {
                TargetStatusIdentifier = "Mana Ratio Recovery 2",
                NewStatusID = S_LES_ACUITY_EFFECT,
                StatusIdentifier = S_LES_ACUITY_EFFECT_NAME,
                Name = "Scroll of Lesser Acuity",
                Description = "Regenerate 0.25 mana per second.",
                Purgeable = true,
                DisplayedInHUD = true,
                IsMalusEffect = false,
                Lifespan = 300f,
                RefreshRate = 1f,
                AmplifiedStatusIdentifier = string.Empty,
                FamilyMode = StatusEffect.FamilyModes.Reference,
                ReferenceFamilyUID = BLUE_SCROLL_FAMILY,
                EffectBehaviour = EditBehaviours.NONE,
            };
            lesacuityEffect.SLPackName = Plugin.PACKID;
            lesacuityEffect.ApplyTemplate();
            lesacuityEffect.ApplyIcon();

            SL_StatusEffect majregenerationEffect = new SL_StatusEffect
            {
                TargetStatusIdentifier = "Health Recovery 5",
                NewStatusID = S_MAJ_REGENERATION_EFFECT,
                StatusIdentifier = S_MAJ_REGENERATION_EFFECT_NAME,
                Name = "Scroll of Major Regeneration",
                Description = "Regenerate 0.5 health per second.",
                Purgeable = true,
                DisplayedInHUD = true,
                IsMalusEffect = false,
                Lifespan = 300f,
                RefreshRate = 1f,
                AmplifiedStatusIdentifier = string.Empty,
                FamilyMode = StatusEffect.FamilyModes.Reference,
                ReferenceFamilyUID = BLUE_SCROLL_FAMILY,
                EffectBehaviour = EditBehaviours.NONE,
            };
            majregenerationEffect.SLPackName = Plugin.PACKID;
            majregenerationEffect.ApplyTemplate();
            majregenerationEffect.ApplyIcon();

            SL_StatusEffect majreinvigorationEffect = new SL_StatusEffect
            {
                TargetStatusIdentifier = "Stamina Recovery 5",
                NewStatusID = S_MAJ_REINVIGORATION_EFFECT,
                StatusIdentifier = S_MAJ_REINVIGORATION_EFFECT_NAME,
                Name = "Scroll of Major Reinvigoration",
                Description = "Regenerate 0.5 stamina per second.",
                Purgeable = true,
                DisplayedInHUD = true,
                IsMalusEffect = false,
                Lifespan = 300f,
                RefreshRate = 1f,
                AmplifiedStatusIdentifier = string.Empty,
                FamilyMode = StatusEffect.FamilyModes.Reference,
                ReferenceFamilyUID = BLUE_SCROLL_FAMILY,
                EffectBehaviour = EditBehaviours.NONE,
            };
            majreinvigorationEffect.SLPackName = Plugin.PACKID;
            majreinvigorationEffect.ApplyTemplate();
            majreinvigorationEffect.ApplyIcon();

            SL_StatusEffect majacuityEffect = new SL_StatusEffect
            {
                TargetStatusIdentifier = "Mana Ratio Recovery 5",
                NewStatusID = S_MAJ_ACUITY_EFFECT,
                StatusIdentifier = S_MAJ_ACUITY_EFFECT_NAME,
                Name = "Scroll of Major Acuity",
                Description = "Regenerate 0.5 mana per second.",
                Purgeable = true,
                DisplayedInHUD = true,
                IsMalusEffect = false,
                Lifespan = 300f,
                RefreshRate = 1f,
                AmplifiedStatusIdentifier = string.Empty,
                FamilyMode = StatusEffect.FamilyModes.Reference,
                ReferenceFamilyUID = BLUE_SCROLL_FAMILY,
                EffectBehaviour = EditBehaviours.NONE,
            };
            lesacuityEffect.SLPackName = Plugin.PACKID;
            lesacuityEffect.ApplyTemplate();
            lesacuityEffect.ApplyIcon();
        }
    }
}

