using System.Collections.Generic;
using SideLoader;
using SideLoader_ExtendedEffects;
using SLExtensions;
using UnityEngine;


namespace GMP
{
    // Red Scrolls(offensive and cast via skills that consume a scroll)
    public class RedScrolls
    {
        // Effect Overrides 
        public const int CHILL_OVERRIDE_EFFECT = -31871;
        public const string CHILL_OVERRIDE_EFFECT_NAME = "Shard_Chill";
        private const float CHILL_OVERRIDE_EFFECT_DUR = 15f;

        public const int CRIPPLE_OVERRIDE_EFFECT = -31872;
        public const string CRIPPLE_OVERRIDE_EFFECT_NAME = "Shard_Cripple";
        private const float CRIPPLE_OVERRIDE_EFFECT_DUR = 15f;

        public const int HAMPERED_OVERRIDE_EFFECT = -31873;
        public const string HAMPERED_OVERRIDE_EFFECT_NAME = "Shard_Hampered";
        private const float HAMPERED_OVERRIDE_EFFECT_DUR = 6f;

        // Red Ink Scrolls
        public const int SCROLL_FIREBALL = -31180;
        public const int SCROLL_FREEZINGSHARD = -31181;
        public const int SCROLL_POISONDART = -31182;
        public const int SCROLL_LIGHTNINGBOLT = -31183;
        public const int SCROLL_GHOSTLYBULLETS = -31184;

        // Red Scroll Skills and Parameters
        public const int S_FIREBALL_SKILL = -31800;
        public const string S_FIREBALL_SKILL_NAME = "Fireball";
        public const string S_FIREBALL_FOLDERNAME = "Scroll_FireballSkill";
        private const float S_FIREBALL_RANGE = 30f;
        private const float S_FIREBALL_FORCE = 25f;
        private const float S_FIREBALL_DAM = 60f;
        private const int S_FIREBALL_CHANCE = 50;
        private const float S_FIREBALL_KNOCK = 50f;
        private const float S_FIREBALL_CD = 10f;

        public const int S_FREEZINGSHARD_SKILL = -31801;
        public const string S_FREEZINGSHARD_SKILL_NAME = "Freezing Shard";
        public const string S_FREEZINGSHARD_FOLDERNAME = "Scroll_FreezingShardSkill";
        private const float S_FREEZINGSHARD_RANGE = 25f;
        private const float S_FREEZINGSHARD_FORCE = 20f;
        private const float S_FREEZINGSHARD_DAM = 20f;
        private const float S_FREEZINGSHARD_KNOCK = 9999f;
        private const float S_FREEZINGSHARD_CD = 30f;

        public const int S_POISONDART_SKILL = -31802;
        public const string S_POISONDART_SKILL_NAME = "Poison Dart";
        public const string S_POISONDART_FOLDERNAME = "Scroll_PoisonDartSkill";

        public const int S_LIGHTNINGBOLT_SKILL = -31803;
        public const string S_LIGHTNINGBOLT_SKILL_NAME = "Lightning Bolt";
        public const string S_LIGHTNINGBOLT_FOLDERNAME = "Scroll_LightningBoltSkill";
        private const float S_LIGHTNINGBOLT_RANGE = 35f;
        private const float S_LIGHTNINGBOLT_FORCE = 50f;
        private const float S_LIGHTNINGBOLT_DAM = 40f;
        private const float S_LIGHTNINGBOLT_RAD = 7.5f;
        private const float S_LIGHTNINGBOLT_KNOCK = 25f;
        private const float S_LIGHTNINGBOLT_CD = 15f;

        public const int S_GHOSTLYBULLET_SKILL = -31804;
        public const string S_GHOSTLYBULLETS_SKILL_NAME = "Ghostly Bullets";
        public const string S_GHOSTLYBULLETS_FOLDERNAME = "Scroll_GhostlyBulletsSkill";

        public static void Init()
        {
            SetUpMiscEffects();
            CreateRedScrolls();
            SetUpFauxSkills();
        }

        private static void SetUpMiscEffects()
        {
            SL_StatusEffect shardchill = new SL_StatusEffect
            {
                TargetStatusIdentifier = "Chill",
                NewStatusID = CHILL_OVERRIDE_EFFECT,
                StatusIdentifier = CHILL_OVERRIDE_EFFECT_NAME,
                Name = "Shard Slow",
                Description = "Placeholder for Shard Chill.",
                Purgeable = true,
                DisplayedInHUD = true,
                IsMalusEffect = false,
                Lifespan = CHILL_OVERRIDE_EFFECT_DUR,
                AmplifiedStatusIdentifier = string.Empty,
                FamilyMode = StatusEffect.FamilyModes.Reference,
                ReferenceFamilyUID = ScrollEffects.RED_SCROLL_FAMILY,
                EffectBehaviour = EditBehaviours.Destroy,
                Effects = new SL_EffectTransform[]
                {
                    new SL_EffectTransform
                    {
                        TransformName = "Effects",
                        Effects = new SL_Effect[]
                        {
                            new SL_AffectStat { Stat_Tag = "FrostResistance", AffectQuantity = -25f, IsModifier = false }
                        }
                    }
                }
            };
            Utility.ApplyEffect(shardchill, true);

            SL_StatusEffect shardcripple = new SL_StatusEffect
            {
                TargetStatusIdentifier = "Cripple",
                NewStatusID = CRIPPLE_OVERRIDE_EFFECT,
                StatusIdentifier = CRIPPLE_OVERRIDE_EFFECT_NAME,
                Name = "Shard Slow",
                Description = "Placeholder for Shard Crippled.",
                Purgeable = true,
                DisplayedInHUD = true,
                IsMalusEffect = false,
                Lifespan = CRIPPLE_OVERRIDE_EFFECT_DUR,
                AmplifiedStatusIdentifier = string.Empty,
                FamilyMode = StatusEffect.FamilyModes.Reference,
                ReferenceFamilyUID = ScrollEffects.RED_SCROLL_FAMILY,
                EffectBehaviour = EditBehaviours.Destroy,
                Effects = new SL_EffectTransform[]
                {
                    new SL_EffectTransform
                    {
                        TransformName = "Effects",
                        Effects = new SL_Effect[]
                        {
                            new SL_AffectStat { Stat_Tag = "MovementSpeed", AffectQuantity = -50f, IsModifier = true }
                        }
                    }
                }
            };
            Utility.ApplyEffect(shardcripple, true);

            SL_StatusEffect shardhampered = new SL_StatusEffect
            {
                TargetStatusIdentifier = "Hampered",
                NewStatusID = HAMPERED_OVERRIDE_EFFECT,
                StatusIdentifier = HAMPERED_OVERRIDE_EFFECT_NAME,
                Name = "Frozen in Place",
                Description = "Placeholder for Shard Hampered.",
                Purgeable = true,
                DisplayedInHUD = true,
                IsMalusEffect = false,
                Lifespan = HAMPERED_OVERRIDE_EFFECT_DUR,
                AmplifiedStatusIdentifier = string.Empty,
                FamilyMode = StatusEffect.FamilyModes.Reference,
                ReferenceFamilyUID = ScrollEffects.RED_SCROLL_FAMILY,
                EffectBehaviour = EditBehaviours.OverrideEffects,
                Effects = new SL_EffectTransform[]
                {
                    new SL_EffectTransform
                    {
                        TransformName = "Effects",
                        Effects = new SL_Effect[]
                        {
                            new SL_AffectStat { Stat_Tag = "MovementSpeed", AffectQuantity = -100f, IsModifier = true },
                            new SL_PlayVFX { VFXPrefab = SL_PlayVFX.VFXPrefabs.TormentBlast_NormalChill_VfxChill }
                        }
                    }
                }
            };
            Utility.ApplyEffect(shardhampered, true);
        }

        private static void CreateRedScrolls()
        {
            SL_ItemVisual ivRedScroll = new SL_ItemVisual
            {
                Prefab_SLPack = Plugin.PACKID,
                Prefab_AssetBundle = "scrolls",
                Prefab_Name = "redscroll"
            };

            SL_Item fireballScroll = new SL_Item()
            {
                Target_ItemID = BlueScrolls.BLANK_SCROLL,
                New_ItemID = SCROLL_FIREBALL,
                Name = "Scroll of Fireball",
                Description = "Hurls a fireball towards enemies that damages with a chance to set them on fire. Requires the Fireball skill to cast.",
                StatsHolder = new SL_ItemStats { BaseValue = BlueScrolls.SCROLL_T1_VAL, RawWeight = BlueScrolls.SCROLL_WEIGHT },
                IsUsable = false,
                CastType = Character.SpellCastType.ElementalProjectile,
                CastModifier = Character.SpellCastModifier.Immobilized,
                CastSheatheRequired = 1,
                Tags = new string[] { "Item", BlueScrolls.TAG_SCROLL, BlueScrolls.TAG_RED_SCROLL },
                EffectBehaviour = EditBehaviours.Destroy,
                ItemVisuals = ivRedScroll
            };
            Utility.ApplyItem(fireballScroll, "Scroll_Fireball");

            SL_Item freezingshardScroll = new SL_Item()
            {
                Target_ItemID = BlueScrolls.BLANK_SCROLL,
                New_ItemID = SCROLL_FREEZINGSHARD,
                Name = "Scroll of Freezing Shard",
                Description = "Hurls a frozen shard that freezes and lightly damages enemies. Requires the Frozen Shard skill to cast.",
                StatsHolder = new SL_ItemStats { BaseValue = BlueScrolls.SCROLL_T1_VAL, RawWeight = BlueScrolls.SCROLL_WEIGHT },
                IsUsable = false,
                Tags = new string[] { "Item", BlueScrolls.TAG_SCROLL, BlueScrolls.TAG_RED_SCROLL },
                EffectBehaviour = EditBehaviours.Destroy,
                ItemVisuals = ivRedScroll
            };
            Utility.ApplyItem(freezingshardScroll, "Scroll_FreezingShard");

            SL_Item poisondartScorll = new SL_Item()
            {
                Target_ItemID = BlueScrolls.BLANK_SCROLL,
                New_ItemID = SCROLL_POISONDART,
                Name = "Scroll of Poison Dart",
                Description = "Hurls a poison dart towards enemies that damages lightly and applies extreme poison. Requires the Poison Dart skill to cast.",
                StatsHolder = new SL_ItemStats { BaseValue = BlueScrolls.SCROLL_T1_VAL, RawWeight = BlueScrolls.SCROLL_WEIGHT },
                IsUsable = false,
                CastType = Character.SpellCastType.ElementalProjectile,
                CastModifier = Character.SpellCastModifier.Immobilized,
                CastSheatheRequired = 1,
                Tags = new string[] { "Item", BlueScrolls.TAG_SCROLL, BlueScrolls.TAG_RED_SCROLL },
                EffectBehaviour = EditBehaviours.Destroy,
                ItemVisuals = ivRedScroll
            };
            Utility.ApplyItem(poisondartScorll, "Scroll_PoisonDart");

            SL_Item lightningboltScroll = new SL_Item()
            {
                Target_ItemID = BlueScrolls.BLANK_SCROLL,
                New_ItemID = SCROLL_LIGHTNINGBOLT,
                Name = "Scroll of Lightning Bolt",
                Description = "Hurls a fast bolt of lightning towards enemies that damages in a small radius. Requires the Lightning Bolt skill to cast.",
                StatsHolder = new SL_ItemStats { BaseValue = BlueScrolls.SCROLL_T1_VAL, RawWeight = BlueScrolls.SCROLL_WEIGHT },
                IsUsable = false,
                CastType = Character.SpellCastType.ElementalProjectile,
                CastModifier = Character.SpellCastModifier.Immobilized,
                CastSheatheRequired = 1,
                Tags = new string[] { "Item", BlueScrolls.TAG_SCROLL, BlueScrolls.TAG_RED_SCROLL },
                EffectBehaviour = EditBehaviours.Destroy,
                ItemVisuals = ivRedScroll
            };
            Utility.ApplyItem(lightningboltScroll, "Scroll_LightningBolt");

            SL_Item ghostlybulletsScroll = new SL_Item()
            {
                Target_ItemID = BlueScrolls.BLANK_SCROLL,
                New_ItemID = SCROLL_GHOSTLYBULLETS,
                Name = "Scroll of Ghostly Bullets",
                Description = "Releases several slow moving ethereal projectiles that track enemies. Requires the Ghostly Bullets skill to cast.",
                StatsHolder = new SL_ItemStats { BaseValue = BlueScrolls.SCROLL_T1_VAL, RawWeight = BlueScrolls.SCROLL_WEIGHT },
                IsUsable = false,
                CastType = Character.SpellCastType.ElementalProjectile,
                CastModifier = Character.SpellCastModifier.Immobilized,
                CastSheatheRequired = 1,
                Tags = new string[] { "Item", BlueScrolls.TAG_SCROLL, BlueScrolls.TAG_RED_SCROLL },
                EffectBehaviour = EditBehaviours.Destroy,
                ItemVisuals = ivRedScroll
            };
            Utility.ApplyItem(ghostlybulletsScroll, "Scroll_GhostlyBullets");
        }

        private static void SetUpRedScrolls()
        {
            SL_StatusEffect lightningboltScroll = new SL_StatusEffect
            {
                TargetStatusIdentifier = "Pouch Over Encumbered",
                NewStatusID = S_LIGHTNINGBOLT_SKILL,
                StatusIdentifier = S_LIGHTNINGBOLT_SKILL_NAME,
                Name = "Lightning Bolt",
                Description = "Lightning Bolt Placeholder.",
                Purgeable = true,
                Lifespan = 0.001f,
                DisplayedInHUD = false,
                IsMalusEffect = false,
                AmplifiedStatusIdentifier = string.Empty,
                FamilyMode = StatusEffect.FamilyModes.Reference,
                ReferenceFamilyUID = ScrollEffects.RED_SCROLL_FAMILY,
                EffectBehaviour = EditBehaviours.Destroy,
                Effects = new SL_EffectTransform[]
                {
                    new SL_EffectTransform
                    {
                        TransformName = "Normal",
                        Effects = new SL_Effect[]
                        {
                            new SL_ShootProjectile
                            {
                                Delay = 0,
                                SyncType = Effect.SyncTypes.OwnerSync,
                                CastPosition = Shooter.CastPositionType.Local,
                                LocalPositionAdd = new Vector3(0, 0.5f, 0),
                                NoAim = false,
                                TargetType = Shooter.TargetTypes.Enemies,
                                TransformName = "ShooterTransform",
                                BaseProjectile = SL_ShootProjectile.ProjectilePrefabs.LichGoldLightningBolt,
                                InstantiatedAmount = 1,
                                Lifespan = 2,
                                LateShootTime = 0.1f,
                                Unblockable = true,
                                EffectsOnlyIfHitCharacter = false,
                                EndMode = Projectile.EndLifeMode.Normal,
                                DisableOnHit = false,
                                IgnoreShooterCollision = true,
                                TargetingMode = ShootProjectile.TargetMode.OwnerTarget,
                                TargetCountPerProjectile = 1,
                                TargetRange = 35,
                                AutoTargetMaxAngle = 360,
                                AutoTarget = false,
                                AutoTargetRange = 10,
                                ProjectileForce = S_LIGHTNINGBOLT_FORCE,
                                AddDirection = new Vector3(0, 0, 0),
                                AddRotationForce = new Vector3(0, 0, 0),
                                YMagnitudeAffect = 0,
                                YMagnitudeForce = 0,
                                DefenseLength = 3,
                                DefenseRange = 3,
                                ImpactSoundMaterial = EquipmentSoundMaterials.Metal_Sharp,
                                LightIntensityFade = new Vector2(10f, 2f),
                                PointOffset = new Vector3(0, 0, 0),
                                TrailEnabled = true,
                                TrailTime = 0.001f,
                                EffectBehaviour = EditBehaviours.Destroy,
                                ProjectileEffects = new SL_EffectTransform[]
                                {
                                    new SL_EffectTransform
                                    {
                                        TransformName = "HitEffects",
                                        Effects = new SL_Effect[]
                                        {
                                           
                                        }
                                    }
                                }
                            }
                        }
                    }
                },
            };
            Utility.ApplyEffect(lightningboltScroll, false);
        }

        private static void SetUpFauxSkills()
        {
            // Set array of all weapon types for using red scroll skills.
            Weapon.WeaponType[] allWeaponTypes = { Weapon.WeaponType.Sword_1H, Weapon.WeaponType.Axe_1H, Weapon.WeaponType.Mace_1H, Weapon.WeaponType.Dagger_OH,
                                                   Weapon.WeaponType.Chakram_OH, Weapon.WeaponType.Pistol_OH, Weapon.WeaponType.Halberd_2H, Weapon.WeaponType.Sword_2H,
                                                   Weapon.WeaponType.Axe_2H, Weapon.WeaponType.Mace_2H, Weapon.WeaponType.Spear_2H, Weapon.WeaponType.Shield,
                                                   Weapon.WeaponType.Arrow, Weapon.WeaponType.Bow };

            // Set Projectiles
            SL_ShootProjectile spIceProjectile = IceProjectile();
            SL_ShootProjectile spFireProjectile = FireProjectile();

            SL_AttackSkill freezingShard = new SL_AttackSkill
            {
                Target_ItemID = 8200310,
                New_ItemID = S_FREEZINGSHARD_SKILL,
                Name = S_FREEZINGSHARD_SKILL_NAME,
                Description = $"Launch a frozen shard at enemies. Does modest damage but knocks enemies back, temporarily freezes them in place, cripples their movement, and applies chill effects. \r\n*Requires a Scroll of Freezing Shard.",
                Cooldown = S_FREEZINGSHARD_CD,
                RequireImbue = false,
                QtyRemovedOnUse = 1,
                CastType = Character.SpellCastType.ElementalProjectile,
                CastModifier = Character.SpellCastModifier.Immobilized,
                CastLocomotionEnabled = false,
                MobileCastMovementMult = -1,
                CastSheatheRequired = 1,
                RequiredWeaponTypes = allWeaponTypes,
                DurabilityCost = 0,
                DurabilityCostPercent = 0,
                ManaCost = 0,
                StaminaCost = 0,
                HealthCost = 0,
                RequiredItems = new SL_Skill.SkillItemReq[] { new SL_Skill.SkillItemReq { ItemID = SCROLL_FREEZINGSHARD, Quantity = 1, Consume = true } },
                EffectBehaviour = EditBehaviours.Destroy,
                EffectTransforms = new SL_EffectTransform[]
                {
                    new SL_EffectTransform
                    {
                        TransformName = "Normal",
                        Effects = new SL_Effect[]
                        {
                            spIceProjectile,
                        }
                    }
                }
            };
            Utility.ApplyEffect(freezingShard, S_FREEZINGSHARD_FOLDERNAME, true);

            SL_AttackSkill fireball = new SL_AttackSkill
            {
                Target_ItemID = 8200310,
                New_ItemID = S_FIREBALL_SKILL,
                Name = S_FIREBALL_SKILL_NAME,
                Description = $"Launch a fireball at enemies. Does high damage, inflicts burning, and lowers fire resistance. \r\n*Requires a Scroll of Fireball.",
                Cooldown = S_FREEZINGSHARD_CD,
                RequireImbue = false,
                QtyRemovedOnUse = 1,
                CastType = Character.SpellCastType.ElementalProjectile,
                CastModifier = Character.SpellCastModifier.Immobilized,
                CastLocomotionEnabled = false,
                MobileCastMovementMult = -1,
                CastSheatheRequired = 1,
                RequiredWeaponTypes = allWeaponTypes,
                DurabilityCost = 0,
                DurabilityCostPercent = 0,
                ManaCost = 0,
                StaminaCost = 0,
                HealthCost = 0,
                RequiredItems = new SL_Skill.SkillItemReq[] { new SL_Skill.SkillItemReq { ItemID = SCROLL_FIREBALL, Quantity = 1, Consume = true } },
                EffectBehaviour = EditBehaviours.Destroy,
                EffectTransforms = new SL_EffectTransform[]
                {
                    new SL_EffectTransform
                    {
                        TransformName = "Normal",
                        Effects = new SL_Effect[]
                        {
                            spFireProjectile,
                        }
                    }
                }
            };
            Utility.ApplyEffect(fireball, S_FIREBALL_FOLDERNAME, true);
        }

        private static SL_ShootProjectile FireProjectile()
        {
            SL_ShootProjectile fireProjectile = new SL_ShootProjectile
            {
                Delay = 0,
                SyncType = Effect.SyncTypes.OwnerSync,
                CastPosition = Shooter.CastPositionType.Local,
                LocalPositionAdd = new Vector3(0, 0.5f, 0),
                NoAim = false,
                TargetType = Shooter.TargetTypes.Enemies,
                TransformName = "ShooterTransform",
                BaseProjectile = SL_ShootProjectile.ProjectilePrefabs.ElementalProjectileFire,
                InstantiatedAmount = 1,
                Lifespan = 3,
                LateShootTime = 0.1f,
                Unblockable = false,
                EffectsOnlyIfHitCharacter = false,
                EndMode = Projectile.EndLifeMode.Normal,
                DisableOnHit = false,
                IgnoreShooterCollision = true,
                TargetingMode = ShootProjectile.TargetMode.OwnerTarget,
                TargetCountPerProjectile = 1,
                TargetRange = S_FIREBALL_RANGE,
                AutoTargetMaxAngle = 360,
                AutoTarget = false,
                AutoTargetRange = 10,
                ProjectileForce = S_FIREBALL_FORCE,
                AddDirection = new Vector3(0, 0, 0),
                AddRotationForce = new Vector3(0, 0, 0),
                YMagnitudeAffect = 0,
                YMagnitudeForce = 0,
                DefenseLength = 3,
                DefenseRange = 3,
                ImpactSoundMaterial = EquipmentSoundMaterials.Metal_Sharp,
                LightIntensityFade = new Vector2(10f, 2f),
                PointOffset = new Vector3(0, 0, 0),
                TrailEnabled = false,
                TrailTime = 0.075f,
                EffectBehaviour = EditBehaviours.Destroy,
                ProjectileEffects = new SL_EffectTransform[]
                {
                     new SL_EffectTransform
                     {
                          TransformName = "HitEffects",
                          Effects = new SL_Effect[]
                          {
                               new SL_PunctualDamage
                               {
                                    Delay = 0,
                                    Damage = new List<SL_Damage> { new SL_Damage { Damage = S_FIREBALL_DAM, Type = DamageType.Types.Fire } },
                                    Knockback = S_FIREBALL_KNOCK,
                                    HitInventory = true,
                                    IgnoreHalfResistances = false
                               },
                               new SL_AddStatusEffect { StatusEffect = "Burning", ChanceToContract = 100 },
                               new SL_PlaySoundEffect { MinPitch = 1f, MaxPitch = 1f, Follow = false, Sounds = new List<GlobalAudioManager.Sounds> { GlobalAudioManager.Sounds.SFX_SKILL_ElemantalProjectileFire_Shot } }
                          }
                     }
                }
            };
            return (fireProjectile);
        }

        private static SL_ShootProjectile IceProjectile()
        {
            SL_ShootProjectile iceProjectile = new SL_ShootProjectile
            {
                Delay = 0,
                SyncType = Effect.SyncTypes.OwnerSync,
                CastPosition = Shooter.CastPositionType.Local,
                LocalPositionAdd = new Vector3(0, 0.5f, 0),
                NoAim = false,
                TargetType = Shooter.TargetTypes.Enemies,
                TransformName = "ShooterTransform",
                BaseProjectile = SL_ShootProjectile.ProjectilePrefabs.ElementalProjectileIce,
                InstantiatedAmount = 1,
                Lifespan = 2,
                LateShootTime = 0.1f,
                Unblockable = true,
                EffectsOnlyIfHitCharacter = false,
                EndMode = Projectile.EndLifeMode.Normal,
                DisableOnHit = false,
                IgnoreShooterCollision = true,
                TargetingMode = ShootProjectile.TargetMode.OwnerTarget,
                TargetCountPerProjectile = 1,
                TargetRange = S_FREEZINGSHARD_RANGE,
                AutoTargetMaxAngle = 360,
                AutoTarget = false,
                AutoTargetRange = 10,
                ProjectileForce = S_FREEZINGSHARD_FORCE,
                AddDirection = new Vector3(0, 0, 0),
                AddRotationForce = new Vector3(0, 0, 0),
                YMagnitudeAffect = 0,
                YMagnitudeForce = 0,
                DefenseLength = 3,
                DefenseRange = 3,
                ImpactSoundMaterial = EquipmentSoundMaterials.Metal_Sharp,
                LightIntensityFade = new Vector2(10f, 2f),
                PointOffset = new Vector3(0, 0, 0),
                TrailEnabled = false,
                TrailTime = 0.001f,
                EffectBehaviour = EditBehaviours.Destroy,
                ProjectileEffects = new SL_EffectTransform[]
                {
                    new SL_EffectTransform
                    {
                         TransformName = "HitEffects",
                         Effects = new SL_Effect[]
                         {
                             new SL_AddStatusEffect { StatusEffect = CRIPPLE_OVERRIDE_EFFECT_NAME, ChanceToContract = 100, Delay = HAMPERED_OVERRIDE_EFFECT_DUR },
                             new SL_AddStatusEffect { StatusEffect = CHILL_OVERRIDE_EFFECT_NAME, ChanceToContract = 100, Delay = HAMPERED_OVERRIDE_EFFECT_DUR },
                             new SL_AddStatusEffect { StatusEffect = HAMPERED_OVERRIDE_EFFECT_NAME, ChanceToContract = 100, },
                             new SL_PunctualDamage
                             {
                                  Delay = 0,
                                  Damage = new List<SL_Damage> { new SL_Damage { Damage = S_FREEZINGSHARD_DAM, Type = DamageType.Types.Frost } },
                                  Knockback = S_FREEZINGSHARD_KNOCK,
                                  HitInventory = true,
                                  IgnoreHalfResistances = false
                             },
                             new SL_PlaySoundEffect { MinPitch = 1f, MaxPitch = 1f, Follow = false, Sounds = new List<GlobalAudioManager.Sounds> { GlobalAudioManager.Sounds.SFX_SKILL_ElemantalProjectileIce_Shot } },
                         }
                    },

                }
            };
            return (iceProjectile);
        }
        private static SL_ShootProjectile LightningProjectile()
        {
            SL_ShootProjectile lightningProjectile = new SL_ShootProjectile
            {
                Delay = 0,
                SyncType = Effect.SyncTypes.OwnerSync,
                CastPosition = Shooter.CastPositionType.Local,
                LocalPositionAdd = new Vector3(0, 0.5f, 0),
                NoAim = false,
                TargetType = Shooter.TargetTypes.Enemies,
                TransformName = "ShooterTransform",
                BaseProjectile = SL_ShootProjectile.ProjectilePrefabs.LichGoldLightningBolt,
                InstantiatedAmount = 1,
                Lifespan = 2,
                LateShootTime = 0.1f,
                Unblockable = true,
                EffectsOnlyIfHitCharacter = false,
                EndMode = Projectile.EndLifeMode.Normal,
                DisableOnHit = false,
                IgnoreShooterCollision = true,
                TargetingMode = ShootProjectile.TargetMode.OwnerTarget,
                TargetCountPerProjectile = 1,
                TargetRange = S_LIGHTNINGBOLT_RANGE,
                AutoTargetMaxAngle = 360,
                AutoTarget = false,
                AutoTargetRange = 10,
                ProjectileForce = S_LIGHTNINGBOLT_FORCE,
                AddDirection = new Vector3(0, 0, 0),
                AddRotationForce = new Vector3(0, 0, 0),
                YMagnitudeAffect = 0,
                YMagnitudeForce = 0,
                DefenseLength = 3,
                DefenseRange = 3,
                ImpactSoundMaterial = EquipmentSoundMaterials.Metal_Sharp,
                LightIntensityFade = new Vector2(10f, 2f),
                PointOffset = new Vector3(0, 0, 0),
                TrailEnabled = true,
                TrailTime = 2f,
                EffectBehaviour = EditBehaviours.Destroy,
                ProjectileEffects = new SL_EffectTransform[]
                {
                    new SL_EffectTransform
                    {
                         TransformName = "HitEffects",
                         Effects = new SL_Effect[]
                         {
                              new SL_PunctualDamageAoE
                              {
                                     Delay = 0,
                                     Radius = S_LIGHTNINGBOLT_RAD,
                                     TargetType = Shooter.TargetTypes.Enemies,
                                     IgnoreShooter = true,
                                     Damage = new List<SL_Damage> { new SL_Damage { Damage = S_LIGHTNINGBOLT_DAM, Type = DamageType.Types.Electric } },
                                     Knockback = S_LIGHTNINGBOLT_KNOCK,
                                     HitInventory = true,
                                     IgnoreHalfResistances = false
                              },
                              new SL_PlaySoundEffect { MinPitch = 1f, MaxPitch = 1f, Follow = false, Sounds = new List<GlobalAudioManager.Sounds> { GlobalAudioManager.Sounds.SFX_SKILL_ElemantalProjectileElectric_Shot } }
                         }
                    },
                }
            };
            return (lightningProjectile);
        }
    }
} 
