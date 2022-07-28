using System;
using System.Collections.Generic;
using SideLoader;
using SLExtensions;

namespace GMP
{
    public class VolatilePotions
    {
        private const float EP_WEIGHT = 0.5f;
        private const string TAG_EP = "Extended Potion";
        private const float VP_WEIGHT = 0.5f;
        private const string TAG_VP = "Volatile Potion";


        public const int VP_PROTECT_VAL = 75;
        public const int VP_ETHEREALPROTECT = -31025;
        public const int VP_DECAYPROTECT = -31026;
        public const int VP_LIGHTNINGPROTECT = -31027;
        public const int VP_FROSTPROTECT = -31028;
        public const int VP_FIREPROTECT = -31029;

        public static void Init()
        {
            SetUpTags();
            VolatilePotionEffects.Init();
            SetUpPotions();
        }

        private static void SetUpTags()
        {
            var potionTags = new SL_TagManifest
            {
                Tags = new List<SL_TagDefinition>
                {
                    new SL_TagDefinition { TagName = TAG_EP },
                    new SL_TagDefinition { TagName = TAG_VP },
                }
            };
            potionTags.ApplyTemplate();
        }

        private static void SetUpPotions()
        {
            SL_Item etherealProtect = new SL_Item()
            {
                Target_ItemID = 4300430, //barrier potion
                New_ItemID = VP_ETHEREALPROTECT,
                Name = "Volatile Potion of Ethereal Protection",
                Description = "Grants immunity to ethereal damage, increased physical and impact resistance, and a strong barrier. BEWARE! Causes damage when consumed and can cause instant death!",
                StatsHolder = new SL_ItemStats { BaseValue = VP_PROTECT_VAL, RawWeight = VP_WEIGHT },
                IsUsable = true,
                CastType = Character.SpellCastType.Potion,
                CastModifier = Character.SpellCastModifier.Immobilized,
                CastSheatheRequired = 0,
                //Tags = new string[] { "Item", "Potion", TAG_VP },
                EffectBehaviour = EditBehaviours.Destroy,
                EffectTransforms = new SL_EffectTransform[]
                {
                    new SL_EffectTransform
                    {
                        TransformName = "Effect",
                        Effects = new SL_Effect[]
                        {
                            new SL_AddStatusEffect { StatusEffect = VolatilePotionEffects.VP_ETHEREALPROTECT_EFFECT_NAME, ChanceToContract = 100 },
                            new SL_AffectBurntHealth { AffectQuantity = VolatilePotionEffects.VP_STAMINABURN, IsModifier = false },
                            new SL_AffectBurntStamina { AffectQuantity = VolatilePotionEffects.VP_HEALTHBURN, IsModifier = false }
                        }
                    },
                    new SL_EffectTransform
                    {
                        TransformName = "ExtraEffects",
                        EffectConditions = new SL_EffectCondition[]
                        {
                            new SL_ProbabilityCondition { ChancePercent = 100 }//?VolatilePotionEffects.VP_DEATHCHANCE } 
                        },
                        Effects = new SL_Effect[]
                        {
                            new SL_Death { Delay = 1f },
                            new SL_PlayTimedVFX { VFXPrefab = SL_PlayVFX.VFXPrefabs.VFXAetherBombExplosion, AutoStopTime = 3 },
                            new SL_PlayTimedVFX { VFXPrefab = SL_PlayVFX.VFXPrefabs.VFXGiftOfBlood, AutoStopTime = 3 },
                            new SL_PlayTimedVFX { VFXPrefab = SL_PlayVFX.VFXPrefabs.LichRustReanimate_ExplosionFX, AutoStopTime = 3 },
                            new SL_PlayTimedVFX { VFXPrefab = SL_PlayVFX.VFXPrefabs.TormentBlast_NormalDoom_VfxDoom, AutoStopTime = 3 },
                            new SL_PlaySoundEffect { MinPitch = 1f, MaxPitch = 1f, Follow = true, Sounds = new List<GlobalAudioManager.Sounds> { GlobalAudioManager.Sounds.ENV_HeavyExplosion01 } },

                        }
                    }
                },
                ItemVisuals = new SL_ItemVisual
                {
                    Prefab_SLPack = Plugin.PACKID,
                    Prefab_AssetBundle = "volatilepotions",
                    Prefab_Name = "vp_etherealp"
                },
            };
            etherealProtect.SLPackName = Plugin.PACKID;
            etherealProtect.SubfolderName = "VP_EtherealProtection";
            etherealProtect.ApplyTemplate();

            SL_Item decayProtect = new SL_Item()
            {
                Target_ItemID = VP_ETHEREALPROTECT,
                New_ItemID = VP_DECAYPROTECT,
                Name = "Volatile Potion of Decay Protection",
                Description = "Grants immunity to decay damage, increased physical and impact resistance, and a strong barrier. BEWARE! Causes damage when consumed and can cause instant death!",
                StatsHolder = new SL_ItemStats { BaseValue = VP_PROTECT_VAL, RawWeight = VP_WEIGHT },
                IsUsable = true,
                CastType = Character.SpellCastType.Potion,
                CastModifier = Character.SpellCastModifier.Immobilized,
                CastSheatheRequired = 0,
                //Tags = new string[] { "Item", "Potion", TAG_VP },
                EffectBehaviour = EditBehaviours.Override,
                EffectTransforms = new SL_EffectTransform[]
                {
                    new SL_EffectTransform
                    {
                        TransformName = "Effect",
                        Effects = new SL_Effect[]
                        {
                            new SL_AddStatusEffect { StatusEffect = VolatilePotionEffects.VP_DECAYPROTECT_EFFECT_NAME, ChanceToContract = 100 },
                            new SL_AffectBurntHealth { AffectQuantity = VolatilePotionEffects.VP_STAMINABURN, IsModifier = false },
                            new SL_AffectBurntStamina { AffectQuantity = VolatilePotionEffects.VP_HEALTHBURN, IsModifier = false }
                        }
                    },
                },
                ItemVisuals = new SL_ItemVisual
                {
                    Prefab_SLPack = Plugin.PACKID,
                    Prefab_AssetBundle = "volatilepotions",
                    Prefab_Name = "vp_decayp"
                },
            };
            decayProtect.SLPackName = Plugin.PACKID;
            decayProtect.SubfolderName = "VP_DecayProtection";
            decayProtect.ApplyTemplate();

            SL_Item lightningProtect = new SL_Item()
            {
                Target_ItemID = VP_ETHEREALPROTECT, 
                New_ItemID = VP_LIGHTNINGPROTECT,
                Name = "Volatile Potion of Lightning Protection",
                Description = "Grants immunity to lightning damage, increased physical and impact resistance, and a strong barrier. BEWARE! Causes damage when consumed and can cause instant death!",
                StatsHolder = new SL_ItemStats { BaseValue = VP_PROTECT_VAL, RawWeight = VP_WEIGHT },
                IsUsable = true,
                CastType = Character.SpellCastType.Potion,
                CastModifier = Character.SpellCastModifier.Immobilized,
                CastSheatheRequired = 0,
                //Tags = new string[] { "Item", "Potion", TAG_VP },
                EffectBehaviour = EditBehaviours.Override,
                EffectTransforms = new SL_EffectTransform[]
                {
                    new SL_EffectTransform
                    {
                        TransformName = "Effect",
                        Effects = new SL_Effect[]
                        {
                            new SL_AddStatusEffect { StatusEffect = VolatilePotionEffects.VP_LIGHTNINGPROTECT_EFFECT_NAME, ChanceToContract = 100 },
                            new SL_AffectBurntHealth { AffectQuantity = VolatilePotionEffects.VP_STAMINABURN, IsModifier = false },
                            new SL_AffectBurntStamina { AffectQuantity = VolatilePotionEffects.VP_HEALTHBURN, IsModifier = false }
                        }
                    },
                },
                ItemVisuals = new SL_ItemVisual
                {
                    Prefab_SLPack = Plugin.PACKID,
                    Prefab_AssetBundle = "volatilepotions",
                    Prefab_Name = "vp_lightningp"
                },
            };
            lightningProtect.SLPackName = Plugin.PACKID;
            lightningProtect.SubfolderName = "VP_LightningProtection";
            lightningProtect.ApplyTemplate();

            SL_Item frostProtect = new SL_Item()
            {
                Target_ItemID = VP_ETHEREALPROTECT,
                New_ItemID = VP_FROSTPROTECT,
                Name = "Volatile Potion of Frost Protection",
                Description = "Grants immunity to frost damage, increased physical and impact resistance, and a strong barrier. BEWARE! Causes damage when consumed and can cause instant death!",
                StatsHolder = new SL_ItemStats { BaseValue = VP_PROTECT_VAL, RawWeight = VP_WEIGHT },
                IsUsable = true,
                CastType = Character.SpellCastType.Potion,
                CastModifier = Character.SpellCastModifier.Immobilized,
                CastSheatheRequired = 0,
                //Tags = new string[] { "Item", "Potion", TAG_VP },
                EffectBehaviour = EditBehaviours.Override,
                EffectTransforms = new SL_EffectTransform[]
                {
                    new SL_EffectTransform
                    {
                        TransformName = "Effect",
                        Effects = new SL_Effect[]
                        {
                            new SL_AddStatusEffect { StatusEffect = VolatilePotionEffects.VP_FROSTPROTECT_EFFECT_NAME, ChanceToContract = 100 },
                            new SL_AffectBurntHealth { AffectQuantity = VolatilePotionEffects.VP_STAMINABURN, IsModifier = false },
                            new SL_AffectBurntStamina { AffectQuantity = VolatilePotionEffects.VP_HEALTHBURN, IsModifier = false }
                        }
                    },
                },
                ItemVisuals = new SL_ItemVisual
                {
                    Prefab_SLPack = Plugin.PACKID,
                    Prefab_AssetBundle = "volatilepotions",
                    Prefab_Name = "vp_frostp"
                },
            };
            frostProtect.SLPackName = Plugin.PACKID;
            frostProtect.SubfolderName = "VP_FrostProtection";
            frostProtect.ApplyTemplate();

            SL_Item fireProtect = new SL_Item()
            {
                Target_ItemID = VP_ETHEREALPROTECT,
                New_ItemID = VP_FIREPROTECT,
                Name = "Volatile Potion of Fire Protection",
                Description = "Grants immunity to fire damage, increased physical and impact resistance, and a strong barrier. BEWARE! Causes damage when consumed and can cause instant death!",
                StatsHolder = new SL_ItemStats { BaseValue = VP_PROTECT_VAL, RawWeight = VP_WEIGHT },
                IsUsable = true,
                CastType = Character.SpellCastType.Potion,
                CastModifier = Character.SpellCastModifier.Immobilized,
                CastSheatheRequired = 0,
                //Tags = new string[] { "Item", "Potion", TAG_VP },
                EffectBehaviour = EditBehaviours.Override,
                EffectTransforms = new SL_EffectTransform[]
                {
                    new SL_EffectTransform
                    {
                        TransformName = "Effect",
                        Effects = new SL_Effect[]
                        {
                            new SL_AddStatusEffect { StatusEffect = VolatilePotionEffects.VP_FIREPROTECT_EFFECT_NAME, ChanceToContract = 100 },
                            new SL_AffectBurntHealth { AffectQuantity = VolatilePotionEffects.VP_STAMINABURN, IsModifier = false },
                            new SL_AffectBurntStamina { AffectQuantity = VolatilePotionEffects.VP_HEALTHBURN, IsModifier = false }
                        }
                    },
                },
                ItemVisuals = new SL_ItemVisual
                {
                    Prefab_SLPack = Plugin.PACKID,
                    Prefab_AssetBundle = "volatilepotions",
                    Prefab_Name = "vp_firep"
                },
            };
            fireProtect.SLPackName = Plugin.PACKID;
            fireProtect.SubfolderName = "VP_FireProtection";
            fireProtect.ApplyTemplate();
        }
    }
}
