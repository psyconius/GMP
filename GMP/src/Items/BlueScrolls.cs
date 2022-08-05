using System.Collections.Generic;
using SideLoader;
using SideLoader_ExtendedEffects;
using UnityEngine;

namespace GMP
{
    // Blue Scrolls (self targeted, use from inventory) and the generic scroll, paper, ink, and quill.
    public class BlueScrolls
    {
        // Tags
        public const string TAG_QUILL = "Quill";
        public const string TAG_SCROLL = "Scroll";
        public const string TAG_INK = "Ink";
        public const string TAG_PAPER = "Paper";
        public const string TAG_BLUE_SCROLL = "Blue Scroll";
        public const string TAG_RED_SCROLL = "Red Scroll";

        // Scroll Tools
        public const int QUILL = -31140;
        public const int QUILL_VAL = 150;
        public const float QUILL_WEIGHT = 0.1f;

        public const int BLUE_INK = -31141;
        public const int RED_INK = -31142;
        public const int INK_VAL = 6;
        public const float INK_WEIGHT = 0.1f;

        // Scroll Defaults
        public const int BLANK_SCROLL = -31143;
        public const int BLANK_SCROLL_VAL = 9;
        public const float SCROLL_WEIGHT = 0.2f;
        public const int SCROLL_T1_VAL = 27;
        public const int SCROLL_T2_VAL = 54;

        // Blue Ink Scrolls
        public const int SCROLL_WARRIOR = -31150;
        public const int SCROLL_MAGE = -31151;
        public const int SCROLL_STOUTNESS = -31152;
        public const int SCROLL_ELEMRES = -31153;
        public const int SCROLL_CHEETAH = -31154;
        public const int SCROLL_SHIMMER = -31155;
        public const int SCROLL_LES_REG = -31156;
        public const int SCROLL_LES_REI = -31157;
        public const int SCROLL_LES_ACU = -31158;
        public const int SCROLL_MAJ_REG = -31159;
        public const int SCROLL_MAJ_REI = -31160;
        public const int SCROLL_MAJ_ACU = -31161;
        public const int SCROLL_MAJ_REJ = -31162;
        public const int SCROLL_MAJ_REF = -31163;
        public const int SCROLL_MAJ_MR = -31164;
        public const int SCROLL_MAJ_ETHEREALRES = -31165;
        public const int SCROLL_MAJ_DECAYRES = -31166;
        public const int SCROLL_MAJ_LIGHTNINGRES = -31167;
        public const int SCROLL_MAJ_FROSTRES = -31168;
        public const int SCROLL_MAJ_FIRERES = -31169;
        public const int SCROLL_FIREFLIES = -31170;
        public const int SCROLL_CHAOTIC = -31171;
        public const int SCROLL_ELEMENTALPACT = -31172;
        public const int SCROLL_SUMMONSUPPLIES = -31173;

        public const float REJREFMEN_HEAL = 50f;

        public static void Init()
        {
            SetUpTags();
            CreateScrollSupport(); // Base items for crafting
            CreateBlueScrolls();
            ScrollRecipes.Init(); // Create Recipes
        }

        private static void SetUpTags()
        {
            var scrollTags = new SL_TagManifest
            {
                Tags = new List<SL_TagDefinition>
                {
                    new SL_TagDefinition { TagName = TAG_QUILL },
                    new SL_TagDefinition { TagName = TAG_SCROLL },
                    new SL_TagDefinition { TagName = TAG_INK },
                    new SL_TagDefinition { TagName = TAG_PAPER },
                    new SL_TagDefinition { TagName = TAG_BLUE_SCROLL },
                    new SL_TagDefinition { TagName = TAG_RED_SCROLL }
                }
            };
            scrollTags.ApplyTemplate();
        }

        private static void CreateScrollSupport()
        {
            SL_Item quill = new SL_Item() 
            {
                Target_ItemID = 6400070, //palladium
                New_ItemID = QUILL,
                Name = "Mysterious Quill",
                Description = "A highly magical quill used to ink scrolls.",
                StatsHolder = new SL_ItemStats { BaseValue = QUILL_VAL, RawWeight = QUILL_WEIGHT },
                GroupItemInDisplay = false,
                IsUsable = false,
                Tags = new string[] { "Item", "Quill", "Ingredient" },
                ItemExtensions = new SL_ItemExtension[]
                {
                    new SL_MultipleUsage { AutoStack = false, MaxStackAmount = 1 },
                },
                EffectBehaviour = EditBehaviours.Destroy,
                ItemVisuals = new SL_ItemVisual
                {
                    Prefab_SLPack = Plugin.PACKID,
                    Prefab_AssetBundle = "scrolls",
                    Prefab_Name = "quill"
                },
            };
            Utility.ApplyItem(quill, "Quill");

            SL_Item blueInk = new SL_Item()
            {
                Target_ItemID = 6400070, //palladium
                New_ItemID = BLUE_INK,
                Name = "Blue Ink",
                Description = "A vial of magical blue ink for creating scrolls.",
                StatsHolder = new SL_ItemStats { BaseValue = INK_VAL, RawWeight = INK_WEIGHT },
                IsUsable = false,
                Tags = new string[] { "Item", "Ink", "Ingredient" },
                EffectBehaviour = EditBehaviours.Destroy,
                ItemVisuals = new SL_ItemVisual
                {
                    Prefab_SLPack = Plugin.PACKID,
                    Prefab_AssetBundle = "scrolls",
                    Prefab_Name = "blueink"
                },
            };
            Utility.ApplyItem(blueInk, "BlueInk");

            SL_Item redInk = new SL_Item()
            {
                Target_ItemID = BLUE_INK,
                New_ItemID = RED_INK,
                Name = "Red Ink",
                Description = "A vial of magical red ink for creating scrolls.",
                StatsHolder = new SL_ItemStats { BaseValue = INK_VAL, RawWeight = INK_WEIGHT },
                IsUsable = false,
                Tags = new string[] { "Item", TAG_INK, "Ingredient" },
                EffectBehaviour = EditBehaviours.Destroy,
                ItemVisuals = new SL_ItemVisual
                {
                    Prefab_SLPack = Plugin.PACKID,
                    Prefab_AssetBundle = "scrolls",
                    Prefab_Name = "redink"
                },
            };
            Utility.ApplyItem(redInk, "RedInk");

            SL_Item blankScroll = new SL_Item()
            {
                Target_ItemID = 6500090, //linen
                New_ItemID = BLANK_SCROLL,
                Name = "Blank Parchment Scroll",
                Description = "A blank scroll made of imbued parchment for use in magical scroll creation.",
                StatsHolder = new SL_ItemStats { BaseValue = BLANK_SCROLL_VAL, RawWeight = SCROLL_WEIGHT },
                IsUsable = false,
                Tags = new string[] { "Item", "Paper", "Ingredient" },
                EffectBehaviour = EditBehaviours.Override,
                ItemVisuals = new SL_ItemVisual
                {
                    Prefab_SLPack = Plugin.PACKID,
                    Prefab_AssetBundle = "scrolls",
                    Prefab_Name = "blankscroll"
                },
            };
            Utility.ApplyItem(blankScroll, "BlankScroll");
        }

        private static void CreateBlueScrolls()
        {
            // Set up Item visual for all Blue Scrolls
            SL_ItemVisual ivBlueScroll = new SL_ItemVisual
            {
                Prefab_SLPack = Plugin.PACKID,
                Prefab_AssetBundle = "scrolls",
                Prefab_Name = "bluescroll"
            };

            SL_Item warriorScroll = new SL_Item()
            {
                Target_ItemID = BLANK_SCROLL,
                New_ItemID = SCROLL_WARRIOR,
                Name = "Scroll of the Warrior",
                Description = "Grants great strength in battle.",
                StatsHolder = new SL_ItemStats { BaseValue = SCROLL_T1_VAL, RawWeight = SCROLL_WEIGHT },
                IsUsable = true,
                CastType = Character.SpellCastType.Rage,
                CastModifier = Character.SpellCastModifier.Immobilized,
                CastSheatheRequired = 1,
                Tags = new string[] { "Item", TAG_SCROLL, TAG_BLUE_SCROLL },
                EffectBehaviour = EditBehaviours.Override,
                EffectTransforms = new SL_EffectTransform[]
                {
                    new SL_EffectTransform
                    {
                        TransformName = "Normal",
                        Effects = new SL_Effect[]
                        {
                            new SL_PlaySoundEffect { MinPitch = 1f, MaxPitch = 1f, Follow = false, Sounds = new List<GlobalAudioManager.Sounds> { GlobalAudioManager.Sounds.CS_TRex_Roar } },
                            new SL_PlayTimedVFX { VFXPrefab = SL_PlayVFX.VFXPrefabs.VFXDiscipline, AutoStopTime = 3f },
                            new SL_AddStatusEffect { StatusEffect = ScrollEffects.S_WARRIOR_EFFECT_NAME, ChanceToContract = 100 },
                        }
                    }
                },
                ItemVisuals = ivBlueScroll
            };
            Utility.ApplyBlueScroll(warriorScroll);

            SL_Item mageScroll = new SL_Item()
            {
                Target_ItemID = BLANK_SCROLL,
                New_ItemID = SCROLL_MAGE,
                Name = "Scroll of the Mage",
                Description = "Grants increased magical prowess.",
                StatsHolder = new SL_ItemStats { BaseValue = SCROLL_T1_VAL, RawWeight = SCROLL_WEIGHT },
                IsUsable = true,
                CastType = Character.SpellCastType.CallElements,
                CastModifier = Character.SpellCastModifier.Immobilized,
                CastSheatheRequired = 1,
                Tags = new string[] { "Item", TAG_SCROLL, TAG_BLUE_SCROLL },
                EffectBehaviour = EditBehaviours.Destroy,
                EffectTransforms = new SL_EffectTransform[]
                {
                    new SL_EffectTransform
                    {
                        TransformName = "Normal",
                        Effects = new SL_Effect[]
                        {
                            new SL_PlaySoundEffect { MinPitch = 1f, MaxPitch = 1f, Follow = false, Sounds = new List<GlobalAudioManager.Sounds> { GlobalAudioManager.Sounds.SFX_SKILL_RuneSpell } },
                            new SL_PlayTimedVFX { VFXPrefab = SL_PlayVFX.VFXPrefabs.VFXCallToElements, AutoStopTime = 3f },
                            new SL_AddStatusEffect { StatusEffect = ScrollEffects.S_MAGE_EFFECT_NAME, ChanceToContract = 100 },
                        }
                    }
                },
                ItemVisuals = ivBlueScroll
            };
            Utility.ApplyBlueScroll(mageScroll);

            SL_Item stoutnessScroll = new SL_Item()
            {
                Target_ItemID = BLANK_SCROLL,
                New_ItemID = SCROLL_STOUTNESS,
                Name = "Scroll of Stoutness",
                Description = "Greatly increases physical and impact resistances.",
                StatsHolder = new SL_ItemStats { BaseValue = SCROLL_T1_VAL, RawWeight = SCROLL_WEIGHT },
                IsUsable = true,
                CastType = Character.SpellCastType.Brace,
                CastModifier = Character.SpellCastModifier.Immobilized,
                CastSheatheRequired = 1,
                Tags = new string[] { "Item", TAG_SCROLL, TAG_BLUE_SCROLL },
                EffectBehaviour = EditBehaviours.Destroy,
                EffectTransforms = new SL_EffectTransform[]
                {
                    new SL_EffectTransform
                    {
                        TransformName = "Normal",
                        Effects = new SL_Effect[]
                        {
                            new SL_PlaySoundEffect { MinPitch = 1f, MaxPitch = 1f, Follow = false, Sounds = new List<GlobalAudioManager.Sounds> { GlobalAudioManager.Sounds.SFX_SKILL_Brace } },
                            new SL_PlayTimedVFX { VFXPrefab = SL_PlayVFX.VFXPrefabs.VFXShieldBrace, AutoStopTime = 3f },
                            new SL_AddStatusEffect { StatusEffect = ScrollEffects.S_STOUTNESS_EFFECT_NAME, ChanceToContract = 100 },
                        }
                    }
                },
                ItemVisuals = ivBlueScroll
            };
            Utility.ApplyBlueScroll(stoutnessScroll);

            SL_Item elemresScroll = new SL_Item()
            {
                Target_ItemID = BLANK_SCROLL,
                New_ItemID = SCROLL_ELEMRES,
                Name = "Scroll of Elemental Resistance",
                Description = "Greatly increases elemental and weather resistances.",
                StatsHolder = new SL_ItemStats { BaseValue = SCROLL_T1_VAL, RawWeight = SCROLL_WEIGHT },
                IsUsable = true,
                CastType = Character.SpellCastType.CallElements,
                CastModifier = Character.SpellCastModifier.Immobilized,
                CastSheatheRequired = 1,
                Tags = new string[] { "Item", TAG_SCROLL, TAG_BLUE_SCROLL },
                EffectBehaviour = EditBehaviours.Destroy,
                EffectTransforms = new SL_EffectTransform[]
                {
                    new SL_EffectTransform
                    {
                        TransformName = "Normal",
                        Effects = new SL_Effect[]
                        {
                            new SL_PlaySoundEffect { MinPitch = 1f, MaxPitch = 1f, Follow = false, Sounds = new List<GlobalAudioManager.Sounds> { GlobalAudioManager.Sounds.SFX_SKILL_CallToElement } },
                            new SL_PlayTimedVFX { VFXPrefab = SL_PlayVFX.VFXPrefabs.VFXCallToElements, AutoStopTime = 3f },
                            new SL_AddStatusEffect { StatusEffect = ScrollEffects.S_ELEMRES_EFFECT_NAME, ChanceToContract = 100 },
                        }
                    }
                },
                ItemVisuals = ivBlueScroll
            };
            Utility.ApplyBlueScroll(elemresScroll);

            SL_Item cheetahScroll = new SL_Item()
            {
                Target_ItemID = BLANK_SCROLL,
                New_ItemID = SCROLL_CHEETAH,
                Name = "Scroll of the Cheetah",
                Description = "Greatly increases movement speed.",
                StatsHolder = new SL_ItemStats { BaseValue = SCROLL_T1_VAL, RawWeight = SCROLL_WEIGHT },
                IsUsable = true,
                CastType = Character.SpellCastType.Fast,
                CastModifier = Character.SpellCastModifier.Immobilized,
                CastSheatheRequired = 1,
                Tags = new string[] { "Item", TAG_SCROLL, TAG_BLUE_SCROLL },
                EffectBehaviour = EditBehaviours.Destroy,
                EffectTransforms = new SL_EffectTransform[]
                {
                    new SL_EffectTransform
                    {
                        TransformName = "Normal",
                        Effects = new SL_Effect[]
                        {
                            new SL_PlaySoundEffect { MinPitch = 1f, MaxPitch = 1f, Follow = false, Sounds = new List<GlobalAudioManager.Sounds> { GlobalAudioManager.Sounds.SFX_SKILL_BoonSpell } },
                            new SL_AddStatusEffect { StatusEffect = ScrollEffects.S_CHEETAH_EFFECT_NAME, ChanceToContract = 100 },
                        }
                    }
                },
                ItemVisuals = ivBlueScroll
            };
            Utility.ApplyBlueScroll(cheetahScroll);

            SL_Item shimmerScroll = new SL_Item()
            {
                Target_ItemID = BLANK_SCROLL,
                New_ItemID = SCROLL_SHIMMER,
                Name = "Scroll of Shimmering Barrier",
                Description = "Grants a physical barrier and resistance to elements.",
                StatsHolder = new SL_ItemStats { BaseValue = SCROLL_T1_VAL, RawWeight = SCROLL_WEIGHT },
                IsUsable = true,
                CastType = Character.SpellCastType.Brace,
                CastModifier = Character.SpellCastModifier.Immobilized,
                CastSheatheRequired = 1,
                Tags = new string[] { "Item", TAG_SCROLL, TAG_BLUE_SCROLL },
                EffectBehaviour = EditBehaviours.Destroy,
                EffectTransforms = new SL_EffectTransform[]
                {
                    new SL_EffectTransform
                    {
                        TransformName = "Normal",
                        Effects = new SL_Effect[]
                        {
                            new SL_PlaySoundEffect { MinPitch = 1f, MaxPitch = 1f, Follow = false, Sounds = new List<GlobalAudioManager.Sounds> { GlobalAudioManager.Sounds.SFX_SKILL_Mist } },
                            new SL_AddStatusEffect { StatusEffect = ScrollEffects.S_SHIMMER_EFFECT_NAME, ChanceToContract = 100 },
                        }
                    }
                },
                ItemVisuals = ivBlueScroll
            };
            Utility.ApplyBlueScroll(shimmerScroll);

            SL_Item lesregScroll = new SL_Item()
            {
                Target_ItemID = BLANK_SCROLL,
                New_ItemID = SCROLL_LES_REG,
                Name = "Scroll of Lesser Regeneration",
                Description = "Grants a small amount of health regeneration.",
                StatsHolder = new SL_ItemStats { BaseValue = SCROLL_T1_VAL, RawWeight = SCROLL_WEIGHT },
                IsUsable = true,
                CastType = Character.SpellCastType.Cleanse,
                CastModifier = Character.SpellCastModifier.Immobilized,
                CastSheatheRequired = 1,
                Tags = new string[] { "Item", TAG_SCROLL, TAG_BLUE_SCROLL },
                EffectBehaviour = EditBehaviours.Destroy,
                EffectTransforms = new SL_EffectTransform[]
                {
                    new SL_EffectTransform
                    {
                        TransformName = "Normal",
                        Effects = new SL_Effect[]
                        {
                            new SL_PlaySoundEffect { MinPitch = 1f, MaxPitch = 1f, Follow = false, Sounds = new List<GlobalAudioManager.Sounds> { GlobalAudioManager.Sounds.SFX_SKILL_Warm } },
                            new SL_PlayTimedVFX { VFXPrefab = SL_PlayVFX.VFXPrefabs.VFXGiftOfBlood, AutoStopTime = 3f },
                            new SL_AddStatusEffect { StatusEffect = ScrollEffects.S_LES_REGENERATION_EFFECT_NAME, ChanceToContract = 100 },
                        }
                    }
                },
                ItemVisuals = ivBlueScroll
            };
            Utility.ApplyBlueScroll(lesregScroll);

            SL_Item lesreiScroll = new SL_Item()
            {
                Target_ItemID = BLANK_SCROLL,
                New_ItemID = SCROLL_LES_REI,
                Name = "Scroll of Lesser Reinvigoration",
                Description = "Grants a small amount of stamina regeneration.",
                StatsHolder = new SL_ItemStats { BaseValue = SCROLL_T1_VAL, RawWeight = SCROLL_WEIGHT },
                IsUsable = true,
                CastType = Character.SpellCastType.Cleanse,
                CastModifier = Character.SpellCastModifier.Immobilized,
                CastSheatheRequired = 1,
                Tags = new string[] { "Item", TAG_SCROLL, TAG_BLUE_SCROLL },
                EffectBehaviour = EditBehaviours.Destroy,
                EffectTransforms = new SL_EffectTransform[]
                {
                    new SL_EffectTransform
                    {
                        TransformName = "Normal",
                        Effects = new SL_Effect[]
                        {
                            new SL_PlaySoundEffect { MinPitch = 1f, MaxPitch = 1f, Follow = false, Sounds = new List<GlobalAudioManager.Sounds> { GlobalAudioManager.Sounds.SFX_SKILL_BoonSpell } },
                            new SL_PlayTimedVFX { VFXPrefab = SL_PlayVFX.VFXPrefabs.VFXDiscipline, AutoStopTime = 3f },
                            new SL_AddStatusEffect { StatusEffect = ScrollEffects.S_LES_REINVIGORATION_EFFECT_NAME, ChanceToContract = 100 },
                        }
                    }
                },
                ItemVisuals = ivBlueScroll
            };
            Utility.ApplyBlueScroll(lesreiScroll);

            SL_Item lesacuScroll = new SL_Item()
            {
                Target_ItemID = BLANK_SCROLL,
                New_ItemID = SCROLL_LES_ACU,
                Name = "Scroll of Lesser Acuity",
                Description = "Grants a small amount of mana regeneration.",
                StatsHolder = new SL_ItemStats { BaseValue = SCROLL_T1_VAL, RawWeight = SCROLL_WEIGHT },
                IsUsable = true,
                CastType = Character.SpellCastType.Cleanse,
                CastModifier = Character.SpellCastModifier.Immobilized,
                CastSheatheRequired = 1,
                Tags = new string[] { "Item", TAG_SCROLL, TAG_BLUE_SCROLL },
                EffectBehaviour = EditBehaviours.Destroy,
                EffectTransforms = new SL_EffectTransform[]
                {
                    new SL_EffectTransform
                    {
                        TransformName = "Normal",
                        Effects = new SL_Effect[]
                        {
                            new SL_PlaySoundEffect { MinPitch = 1f, MaxPitch = 1f, Follow = false, Sounds = new List<GlobalAudioManager.Sounds> { GlobalAudioManager.Sounds.SFX_SKILL_CallToElement } },
                            new SL_PlayTimedVFX { VFXPrefab = SL_PlayVFX.VFXPrefabs.VFXBoonEthereal, AutoStopTime = 3f },
                            new SL_AddStatusEffect { StatusEffect = ScrollEffects.S_LES_ACUITY_EFFECT_NAME, ChanceToContract = 100 },
                        }
                    }
                },
                ItemVisuals = ivBlueScroll
            };
            Utility.ApplyBlueScroll(lesacuScroll);

            SL_Item majregScroll = new SL_Item()
            {
                Target_ItemID = BLANK_SCROLL,
                New_ItemID = SCROLL_LES_REG,
                Name = "Scroll of Major Regeneration",
                Description = "Grants a large amount of health regeneration.",
                StatsHolder = new SL_ItemStats { BaseValue = SCROLL_T2_VAL, RawWeight = SCROLL_WEIGHT },
                IsUsable = true,
                CastType = Character.SpellCastType.Cleanse,
                CastModifier = Character.SpellCastModifier.Immobilized,
                CastSheatheRequired = 1,
                Tags = new string[] { "Item", TAG_SCROLL, TAG_BLUE_SCROLL },
                EffectBehaviour = EditBehaviours.Destroy,
                EffectTransforms = new SL_EffectTransform[]
                {
                    new SL_EffectTransform
                    {
                        TransformName = "Normal",
                        Effects = new SL_Effect[]
                        {
                            new SL_PlaySoundEffect { MinPitch = 1f, MaxPitch = 1f, Follow = false, Sounds = new List<GlobalAudioManager.Sounds> { GlobalAudioManager.Sounds.SFX_SKILL_Warm } },
                            new SL_PlayTimedVFX { VFXPrefab = SL_PlayVFX.VFXPrefabs.VFXGiftOfBlood, AutoStopTime = 3f },
                            new SL_AddStatusEffect { StatusEffect = ScrollEffects.S_MAJ_REGENERATION_EFFECT_NAME, ChanceToContract = 100 },
                        }
                    }
                },
                ItemVisuals = ivBlueScroll
            };
            Utility.ApplyBlueScroll(majregScroll);

            SL_Item majreiScroll = new SL_Item()
            {
                Target_ItemID = BLANK_SCROLL,
                New_ItemID = SCROLL_MAJ_REI,
                Name = "Scroll of Major Reinvigoration",
                Description = "Grants a large amount of stamina regeneration.",
                StatsHolder = new SL_ItemStats { BaseValue = SCROLL_T2_VAL, RawWeight = SCROLL_WEIGHT },
                IsUsable = true,
                CastType = Character.SpellCastType.Cleanse,
                CastModifier = Character.SpellCastModifier.Immobilized,
                CastSheatheRequired = 1,
                Tags = new string[] { "Item", TAG_SCROLL, TAG_BLUE_SCROLL },
                EffectBehaviour = EditBehaviours.Destroy,
                EffectTransforms = new SL_EffectTransform[]
                {
                    new SL_EffectTransform
                    {
                        TransformName = "Normal",
                        Effects = new SL_Effect[]
                        {
                            new SL_PlaySoundEffect { MinPitch = 1f, MaxPitch = 1f, Follow = false, Sounds = new List<GlobalAudioManager.Sounds> { GlobalAudioManager.Sounds.SFX_SKILL_BoonSpell } },
                            new SL_PlayTimedVFX { VFXPrefab = SL_PlayVFX.VFXPrefabs.VFXDiscipline, AutoStopTime = 3f },
                            new SL_AddStatusEffect { StatusEffect = ScrollEffects.S_MAJ_REINVIGORATION_EFFECT_NAME, ChanceToContract = 100 },
                        }
                    }
                },
                ItemVisuals = ivBlueScroll
            };
            Utility.ApplyBlueScroll(majreiScroll);

            SL_Item majacuScroll = new SL_Item()
            {
                Target_ItemID = BLANK_SCROLL,
                New_ItemID = SCROLL_MAJ_ACU,
                Name = "Scroll of Major Acuity",
                Description = "Grants a large amount of mana regeneration.",
                StatsHolder = new SL_ItemStats { BaseValue = SCROLL_T2_VAL, RawWeight = SCROLL_WEIGHT },
                IsUsable = true,
                CastType = Character.SpellCastType.Cleanse,
                CastModifier = Character.SpellCastModifier.Immobilized,
                CastSheatheRequired = 1,
                Tags = new string[] { "Item", TAG_SCROLL, TAG_BLUE_SCROLL },
                EffectBehaviour = EditBehaviours.Destroy,
                EffectTransforms = new SL_EffectTransform[]
                {
                    new SL_EffectTransform
                    {
                        TransformName = "Normal",
                        Effects = new SL_Effect[]
                        {
                            new SL_PlaySoundEffect { MinPitch = 1f, MaxPitch = 1f, Follow = false, Sounds = new List<GlobalAudioManager.Sounds> { GlobalAudioManager.Sounds.SFX_SKILL_CallToElement } },
                            new SL_PlayTimedVFX { VFXPrefab = SL_PlayVFX.VFXPrefabs.VFXBoonEthereal, AutoStopTime = 3f },
                            new SL_AddStatusEffect { StatusEffect = ScrollEffects.S_MAJ_ACUITY_EFFECT_NAME, ChanceToContract = 100 },
                        }
                    }
                },
                ItemVisuals = ivBlueScroll
            };
            Utility.ApplyBlueScroll(majacuScroll);

            SL_Item majrejScroll = new SL_Item()
            {
                Target_ItemID = BLANK_SCROLL,
                New_ItemID = SCROLL_MAJ_REJ,
                Name = "Scroll of Major Rejuvenation",
                Description = "Rejuvenates health.",
                StatsHolder = new SL_ItemStats { BaseValue = SCROLL_T2_VAL, RawWeight = SCROLL_WEIGHT },
                IsUsable = true,
                CastType = Character.SpellCastType.Cleanse,
                CastModifier = Character.SpellCastModifier.Immobilized,
                CastSheatheRequired = 1,
                Tags = new string[] { "Item", TAG_SCROLL, TAG_BLUE_SCROLL },
                EffectBehaviour = EditBehaviours.Destroy,
                EffectTransforms = new SL_EffectTransform[]
                {
                    new SL_EffectTransform
                    {
                        TransformName = "Normal",
                        Effects = new SL_Effect[]
                        {
                            new SL_PlaySoundEffect { MinPitch = 1f, MaxPitch = 1f, Follow = false, Sounds = new List<GlobalAudioManager.Sounds> { GlobalAudioManager.Sounds.SFX_SKILL_Warm } },
                            new SL_PlayTimedVFX { VFXPrefab = SL_PlayVFX.VFXPrefabs.VFXGiftOfBlood, AutoStopTime = 3f },
                            new SL_AffectBurntHealth { AffectQuantity = 100f, IsModifier = true },
                            new SL_AffectHealth { AffectQuantity = REJREFMEN_HEAL, IsModifier = false }
                        }
                    }
                },
                ItemVisuals = ivBlueScroll
            };
            Utility.ApplyBlueScroll(majrejScroll);

            SL_Item majrefScroll = new SL_Item()
            {
                Target_ItemID = BLANK_SCROLL,
                New_ItemID = SCROLL_MAJ_REF,
                Name = "Scroll of Major Refresh",
                Description = "Refreshes stamina.",
                StatsHolder = new SL_ItemStats { BaseValue = SCROLL_T2_VAL, RawWeight = SCROLL_WEIGHT },
                IsUsable = true,
                CastType = Character.SpellCastType.Cleanse,
                CastModifier = Character.SpellCastModifier.Immobilized,
                CastSheatheRequired = 1,
                Tags = new string[] { "Item", TAG_SCROLL, TAG_BLUE_SCROLL },
                EffectBehaviour = EditBehaviours.Destroy,
                EffectTransforms = new SL_EffectTransform[]
                {
                    new SL_EffectTransform
                    {
                        TransformName = "Normal",
                        Effects = new SL_Effect[]
                        {
                            new SL_PlaySoundEffect { MinPitch = 1f, MaxPitch = 1f, Follow = false, Sounds = new List<GlobalAudioManager.Sounds> { GlobalAudioManager.Sounds.SFX_SKILL_BoonSpell } },
                            new SL_PlayTimedVFX { VFXPrefab = SL_PlayVFX.VFXPrefabs.VFXDiscipline, AutoStopTime = 3f },
                            new SL_AffectBurntStamina { AffectQuantity = 100f, IsModifier = true },
                            new SL_AffectStamina { AffectQuantity = REJREFMEN_HEAL }
                        }
                    }
                },
                ItemVisuals = ivBlueScroll
            };
            Utility.ApplyBlueScroll(majrefScroll);

            SL_Item majmrScroll = new SL_Item()
            {
                Target_ItemID = BLANK_SCROLL,
                New_ItemID = SCROLL_MAJ_MR,
                Name = "Scroll of Major Mental Respite",
                Description = "Restores mana and peace of mind.",
                StatsHolder = new SL_ItemStats { BaseValue = SCROLL_T2_VAL, RawWeight = SCROLL_WEIGHT },
                IsUsable = true,
                CastType = Character.SpellCastType.Cleanse,
                CastModifier = Character.SpellCastModifier.Immobilized,
                CastSheatheRequired = 1,
                Tags = new string[] { "Item", TAG_SCROLL, TAG_BLUE_SCROLL },
                EffectBehaviour = EditBehaviours.Destroy,
                EffectTransforms = new SL_EffectTransform[]
                {
                    new SL_EffectTransform
                    {
                        TransformName = "Normal",
                        Effects = new SL_Effect[]
                        {
                            new SL_PlaySoundEffect { MinPitch = 1f, MaxPitch = 1f, Follow = false, Sounds = new List<GlobalAudioManager.Sounds> { GlobalAudioManager.Sounds.SFX_SKILL_CallToElement } },
                            new SL_PlayTimedVFX { VFXPrefab = SL_PlayVFX.VFXPrefabs.VFXBoonEthereal, AutoStopTime = 3f },
                            new SL_AffectBurntMana { AffectQuantity = 100f, IsModifier = true },
                            new SL_AffectMana { AffectQuantity = REJREFMEN_HEAL, AffectType = AffectMana.AffectTypes.Restaure }
                        }
                    }
                },
                ItemVisuals = ivBlueScroll
            };
            Utility.ApplyBlueScroll(majmrScroll);

            SL_Item majEthRes = new SL_Item()
            {
                Target_ItemID = BLANK_SCROLL,
                New_ItemID = SCROLL_MAJ_ETHEREALRES,
                Name = "Scroll of Major Ethereal Resistance",
                Description = "Grants major resistance to ethereal damage.",
                StatsHolder = new SL_ItemStats { BaseValue = SCROLL_T2_VAL, RawWeight = SCROLL_WEIGHT },
                IsUsable = true,
                CastType = Character.SpellCastType.CallElements,
                CastModifier = Character.SpellCastModifier.Immobilized,
                CastSheatheRequired = 1,
                Tags = new string[] { "Item", TAG_SCROLL, TAG_BLUE_SCROLL },
                EffectBehaviour = EditBehaviours.Destroy,
                EffectTransforms = new SL_EffectTransform[]
                {
                    new SL_EffectTransform
                    {
                        TransformName = "Normal",
                        Effects = new SL_Effect[]
                        {
                            new SL_PlaySoundEffect { MinPitch = 1f, MaxPitch = 1f, Follow = false, Sounds = new List<GlobalAudioManager.Sounds> { GlobalAudioManager.Sounds.SFX_SKILL_CallToElement } },
                            new SL_AddStatusEffect { StatusEffect = VolatilePotionEffects.EP_ETHEREALRESIST_EFFECT_NAME, ChanceToContract = 100 }
                        }
                    }
                },
                ItemVisuals = ivBlueScroll
            };
            Utility.ApplyBlueScroll(majEthRes);

            SL_Item majDecRes = new SL_Item()
            {
                Target_ItemID = BLANK_SCROLL,
                New_ItemID = SCROLL_MAJ_DECAYRES,
                Name = "Scroll of Major Decay Resistance",
                Description = "Grants major resistance to decay damage.",
                StatsHolder = new SL_ItemStats { BaseValue = SCROLL_T2_VAL, RawWeight = SCROLL_WEIGHT },
                IsUsable = true,
                CastType = Character.SpellCastType.CallElements,
                CastModifier = Character.SpellCastModifier.Immobilized,
                CastSheatheRequired = 1,
                Tags = new string[] { "Item", TAG_SCROLL, TAG_BLUE_SCROLL },
                EffectBehaviour = EditBehaviours.Destroy,
                EffectTransforms = new SL_EffectTransform[]
                {
                    new SL_EffectTransform
                    {
                        TransformName = "Normal",
                        Effects = new SL_Effect[]
                        {
                            new SL_PlaySoundEffect { MinPitch = 1f, MaxPitch = 1f, Follow = false, Sounds = new List<GlobalAudioManager.Sounds> { GlobalAudioManager.Sounds.SFX_SKILL_CallToElement } },
                            new SL_AddStatusEffect { StatusEffect = VolatilePotionEffects.EP_DECAYRESIST_EFFECT_NAME, ChanceToContract = 100 }
                        }
                    }
                },
                ItemVisuals = ivBlueScroll
            };
            Utility.ApplyBlueScroll(majDecRes);

            SL_Item majLigRes = new SL_Item()
            {
                Target_ItemID = BLANK_SCROLL,
                New_ItemID = SCROLL_MAJ_LIGHTNINGRES,
                Name = "Scroll of Major Lightning Resistance",
                Description = "Grants major resistance to lightning damage.",
                StatsHolder = new SL_ItemStats { BaseValue = SCROLL_T2_VAL, RawWeight = SCROLL_WEIGHT },
                IsUsable = true,
                CastType = Character.SpellCastType.CallElements,
                CastModifier = Character.SpellCastModifier.Immobilized,
                CastSheatheRequired = 1,
                Tags = new string[] { "Item", TAG_SCROLL, TAG_BLUE_SCROLL },
                EffectBehaviour = EditBehaviours.Destroy,
                EffectTransforms = new SL_EffectTransform[]
                {
                    new SL_EffectTransform
                    {
                        TransformName = "Normal",
                        Effects = new SL_Effect[]
                        {
                            new SL_PlaySoundEffect { MinPitch = 1f, MaxPitch = 1f, Follow = false, Sounds = new List<GlobalAudioManager.Sounds> { GlobalAudioManager.Sounds.SFX_SKILL_CallToElement } },
                            new SL_AddStatusEffect { StatusEffect = VolatilePotionEffects.EP_LIGHTNINGRESIST_EFFECT_NAME, ChanceToContract = 100 }
                        }
                    }
                },
                ItemVisuals = ivBlueScroll
            };
            Utility.ApplyBlueScroll(majLigRes);

            SL_Item majFroRes = new SL_Item()
            {
                Target_ItemID = BLANK_SCROLL,
                New_ItemID = SCROLL_MAJ_FROSTRES,
                Name = "Scroll of Major Frost Resistance",
                Description = "Grants major resistance to frost damage.",
                StatsHolder = new SL_ItemStats { BaseValue = SCROLL_T2_VAL, RawWeight = SCROLL_WEIGHT },
                IsUsable = true,
                CastType = Character.SpellCastType.CallElements,
                CastModifier = Character.SpellCastModifier.Immobilized,
                CastSheatheRequired = 1,
                Tags = new string[] { "Item", TAG_SCROLL, TAG_BLUE_SCROLL },
                EffectBehaviour = EditBehaviours.Destroy,
                EffectTransforms = new SL_EffectTransform[]
                {
                    new SL_EffectTransform
                    {
                        TransformName = "Normal",
                        Effects = new SL_Effect[]
                        {
                            new SL_PlaySoundEffect { MinPitch = 1f, MaxPitch = 1f, Follow = false, Sounds = new List<GlobalAudioManager.Sounds> { GlobalAudioManager.Sounds.SFX_SKILL_CallToElement } },
                            new SL_AddStatusEffect { StatusEffect = VolatilePotionEffects.EP_FROSTRESIST_EFFECT_NAME, ChanceToContract = 100 }
                        }
                    }
                },
                ItemVisuals = ivBlueScroll
            };
            Utility.ApplyBlueScroll(majFroRes);

            SL_Item majFireRes = new SL_Item()
            {
                Target_ItemID = BLANK_SCROLL,
                New_ItemID = SCROLL_MAJ_FIRERES,
                Name = "Scroll of Major Fire Resistance",
                Description = "Grants major resistance to fire damage.",
                StatsHolder = new SL_ItemStats { BaseValue = SCROLL_T2_VAL, RawWeight = SCROLL_WEIGHT },
                IsUsable = true,
                CastType = Character.SpellCastType.CallElements,
                CastModifier = Character.SpellCastModifier.Immobilized,
                CastSheatheRequired = 1,
                Tags = new string[] { "Item", TAG_SCROLL, TAG_BLUE_SCROLL },
                EffectBehaviour = EditBehaviours.Destroy,
                EffectTransforms = new SL_EffectTransform[]
                {
                    new SL_EffectTransform
                    {
                        TransformName = "Normal",
                        Effects = new SL_Effect[]
                        {
                            new SL_PlaySoundEffect { MinPitch = 1f, MaxPitch = 1f, Follow = false, Sounds = new List<GlobalAudioManager.Sounds> { GlobalAudioManager.Sounds.SFX_SKILL_CallToElement } },
                            new SL_AddStatusEffect { StatusEffect = VolatilePotionEffects.EP_FIRERESIST_EFFECT_NAME, ChanceToContract = 100 }
                        }
                    }
                },
                ItemVisuals = ivBlueScroll
            };
            Utility.ApplyBlueScroll(majFireRes);

            SL_Item fireflyScroll = new SL_Item()
            {
                Target_ItemID = BLANK_SCROLL,
                New_ItemID = SCROLL_FIREFLIES,
                Name = "Scroll of Fireflies",
                Description = "Grants a light source.",
                StatsHolder = new SL_ItemStats { BaseValue = SCROLL_T1_VAL, RawWeight = SCROLL_WEIGHT },
                IsUsable = true,
                CastType = Character.SpellCastType.CallElements,
                CastModifier = Character.SpellCastModifier.Immobilized,
                CastSheatheRequired = 1,
                Tags = new string[] { "Item", TAG_SCROLL, TAG_BLUE_SCROLL },
                EffectBehaviour = EditBehaviours.Destroy,
                EffectTransforms = new SL_EffectTransform[]
                {
                    new SL_EffectTransform
                    {
                        TransformName = "Normal",
                        Effects = new SL_Effect[]
                        {
                            new SL_PlaySoundEffect { MinPitch = 1f, MaxPitch = 1f, Follow = false, Sounds = new List<GlobalAudioManager.Sounds> { GlobalAudioManager.Sounds.SFX_SKILL_CallToElement } },
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
                ItemVisuals = ivBlueScroll
            };
            Utility.ApplyBlueScroll(fireflyScroll);

            SL_Item chaoticScroll = new SL_Item()
            {
                Target_ItemID = BLANK_SCROLL,
                New_ItemID = SCROLL_CHAOTIC,
                Name = "Scroll of Chaotic Blessing",
                Description = "Grants a positive and negative effect.",
                StatsHolder = new SL_ItemStats { BaseValue = SCROLL_T1_VAL, RawWeight = SCROLL_WEIGHT },
                IsUsable = true,
                CastType = Character.SpellCastType.CallElements,
                CastModifier = Character.SpellCastModifier.Immobilized,
                CastSheatheRequired = 1,
                Tags = new string[] { "Item", TAG_SCROLL, TAG_BLUE_SCROLL },
                EffectBehaviour = EditBehaviours.Destroy,
                EffectTransforms = new SL_EffectTransform[]
                {
                    new SL_EffectTransform
                    {
                        TransformName = "Normal",
                        Effects = new SL_Effect[]
                        {
                            new SL_PlaySoundEffect { MinPitch = 1f, MaxPitch = 1f, Follow = false, Sounds = new List<GlobalAudioManager.Sounds> { GlobalAudioManager.Sounds.SFX_SKILL_BoonSpell } },
                            new SL_PlayTimedVFX { VFXPrefab = SL_PlayVFX.VFXPrefabs.VFXDetectSoul, AutoStopTime = 3f },
                        }
                    }
                },
                ItemVisuals = ivBlueScroll
            };
            Utility.ApplyBlueScroll(chaoticScroll);

            SL_Item summonScroll = new SL_Item()
            {
                Target_ItemID = BLANK_SCROLL,
                New_ItemID = SCROLL_SUMMONSUPPLIES,
                Name = "Scroll of Summon Supplies",
                Description = "Summons bandages, a travel ration, clean water, and 3 wood.",
                StatsHolder = new SL_ItemStats { BaseValue = SCROLL_T1_VAL, RawWeight = SCROLL_WEIGHT },
                IsUsable = true,
                CastType = Character.SpellCastType.CallElements,
                CastModifier = Character.SpellCastModifier.Immobilized,
                CastSheatheRequired = 1,
                Tags = new string[] { "Item", TAG_SCROLL, TAG_BLUE_SCROLL },
                EffectBehaviour = EditBehaviours.Destroy,
                EffectTransforms = new SL_EffectTransform[]
                {
                    new SL_EffectTransform
                    {
                        TransformName = "Normal",
                        Effects = new SL_Effect[]
                        {
                            new SL_PlaySoundEffect { MinPitch = 1f, MaxPitch = 1f, Follow = false, Sounds = new List<GlobalAudioManager.Sounds> { GlobalAudioManager.Sounds.SFX_SKILL_AirSigil_Preparation } },
                            new SL_PlayTimedVFX { VFXPrefab = SL_PlayVFX.VFXPrefabs.VFXTeleport, AutoStopTime = 3f },
                            new SL_CreateItemEffect { ItemToCreate = 4400010, Quantity = 1}, //bandages
                            new SL_CreateItemEffect { ItemToCreate = 4100550, Quantity = 1}, //travel ration
                            new SL_CreateItemEffect { ItemToCreate = 5600000, Quantity = 1}, //clean water
                            new SL_CreateItemEffect { ItemToCreate = 6100010, Quantity = 3} //wood
                        }
                    }
                },
                ItemVisuals = ivBlueScroll
            };
            Utility.ApplyBlueScroll(summonScroll);
        }
    }
}
