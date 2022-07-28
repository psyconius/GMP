using System.Collections.Generic;
using SideLoader;
using UnityEngine;

namespace GMP
{
    public class Scrolls
    {
        public const int DEF_CAMPFIRE = 5000101;

        // Tags
        public const string TAG_QUILL = "Quill";
        public const string TAG_SCROLL = "Scroll";
        public const string TAG_INK = "Ink";
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
        public const int SCROLL_FIREFLIES = -31170;
        public const int SCROLL_CHAOTIC = -31171;
        public const int SCROLL_ELEMENTALPACT = -31172;

        // Red Ink Scrolls
        public const int SCROLL_FIREBALL = -31180;
        public const int SCROLL_FREEZE = -31181;
        public const int SCROLL_POISONDART = -31182;
        

        public static void Init()
        {
            SetUpTags();
            ScrollEffects.Init(); // Setup Effects
            CreateScrollSupport(); // Base items for crafting
            CreateScrolls(); // Actual cast scrolls
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
            quill.SLPackName = Plugin.PACKID;
            quill.SubfolderName = "Quill";
            quill.ApplyTemplate();

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
            blueInk.SLPackName = Plugin.PACKID;
            blueInk.SubfolderName = "BlueInk";
            blueInk.ApplyTemplate();

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
            redInk.SLPackName = Plugin.PACKID;
            redInk.SubfolderName = "RedInk";
            redInk.ApplyTemplate();

            SL_Item blankScroll = new SL_Item()
            {
                Target_ItemID = 6500090, //linen
                New_ItemID = BLANK_SCROLL,
                Name = "Blank Parchment Scroll",
                Description = "A blank scroll made of imbued parchment for use in magical scroll creation.",
                StatsHolder = new SL_ItemStats { BaseValue = BLANK_SCROLL_VAL, RawWeight = SCROLL_WEIGHT },
                IsUsable = false,
                Tags = new string[] { "Item", "Paper", "Book", "Ingredient" },
                EffectBehaviour = EditBehaviours.Override,
                ItemVisuals = new SL_ItemVisual
                {
                    Prefab_SLPack = Plugin.PACKID,
                    Prefab_AssetBundle = "scrolls",
                    Prefab_Name = "blankscroll"
                },
            };
            blankScroll.SLPackName = Plugin.PACKID;
            blankScroll.SubfolderName = "BlankScroll";
            blankScroll.ApplyTemplate();
        }

        private static void CreateScrolls()
        {
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
                            new SL_PlaySoundEffect { MinPitch = 1f, MaxPitch = 1f, Follow = true, Sounds = new List<GlobalAudioManager.Sounds> { GlobalAudioManager.Sounds.CS_TRex_Roar } },
                            new SL_PlayTimedVFX { VFXPrefab = SL_PlayVFX.VFXPrefabs.VFXDiscipline, AutoStopTime = 3f },
                            new SL_AddStatusEffect { StatusEffect = ScrollEffects.S_WARRIOR_EFFECT_NAME, ChanceToContract = 100 },
                        }
                    }
                },
                ItemVisuals = new SL_ItemVisual
                {
                    Prefab_SLPack = Plugin.PACKID,
                    Prefab_AssetBundle = "scrolls",
                    Prefab_Name = "bluescroll"
                },
            };
            warriorScroll.SLPackName = Plugin.PACKID;
            warriorScroll.SubfolderName = "BlueScroll";
            warriorScroll.ApplyTemplate();

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
                            new SL_PlaySoundEffect { MinPitch = 1f, MaxPitch = 1f, Follow = true, Sounds = new List<GlobalAudioManager.Sounds> { GlobalAudioManager.Sounds.SFX_SKILL_RuneSpell } },
                            new SL_PlayTimedVFX { VFXPrefab = SL_PlayVFX.VFXPrefabs.VFXCallToElements, AutoStopTime = 3f },
                            new SL_AddStatusEffect { StatusEffect = ScrollEffects.S_MAGE_EFFECT_NAME, ChanceToContract = 100 },
                        }
                    }
                },
                ItemVisuals = new SL_ItemVisual
                {
                    Prefab_SLPack = Plugin.PACKID,
                    Prefab_AssetBundle = "scrolls",
                    Prefab_Name = "bluescroll"
                },
            };
            mageScroll.SLPackName = Plugin.PACKID;
            mageScroll.SubfolderName = "BlueScroll";
            mageScroll.ApplyTemplate();

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
                            new SL_PlaySoundEffect { MinPitch = 1f, MaxPitch = 1f, Follow = true, Sounds = new List<GlobalAudioManager.Sounds> { GlobalAudioManager.Sounds.SFX_SKILL_Brace } },
                            new SL_PlayTimedVFX { VFXPrefab = SL_PlayVFX.VFXPrefabs.VFXShieldBrace, AutoStopTime = 3f },
                            new SL_AddStatusEffect { StatusEffect = ScrollEffects.S_STOUTNESS_EFFECT_NAME, ChanceToContract = 100 },
                        }
                    }
                },
                ItemVisuals = new SL_ItemVisual
                {
                    Prefab_SLPack = Plugin.PACKID,
                    Prefab_AssetBundle = "scrolls",
                    Prefab_Name = "bluescroll"
                },
            };
            stoutnessScroll.SLPackName = Plugin.PACKID;
            stoutnessScroll.SubfolderName = "BlueScroll";
            stoutnessScroll.ApplyTemplate();

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
                            new SL_PlaySoundEffect { MinPitch = 1f, MaxPitch = 1f, Follow = true, Sounds = new List<GlobalAudioManager.Sounds> { GlobalAudioManager.Sounds.SFX_SKILL_CallToElement } },
                            new SL_PlayTimedVFX { VFXPrefab = SL_PlayVFX.VFXPrefabs.VFXCallToElements, AutoStopTime = 3f },
                            new SL_AddStatusEffect { StatusEffect = ScrollEffects.S_ELEMRES_EFFECT_NAME, ChanceToContract = 100 },
                        }
                    }
                },
                ItemVisuals = new SL_ItemVisual
                {
                    Prefab_SLPack = Plugin.PACKID,
                    Prefab_AssetBundle = "scrolls",
                    Prefab_Name = "bluescroll"
                },
            };
            elemresScroll.SLPackName = Plugin.PACKID;
            elemresScroll.SubfolderName = "BlueScroll";
            elemresScroll.ApplyTemplate();

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
                            new SL_PlaySoundEffect { MinPitch = 1f, MaxPitch = 1f, Follow = true, Sounds = new List<GlobalAudioManager.Sounds> { GlobalAudioManager.Sounds.SFX_SKILL_BoonSpell } },
                            new SL_AddStatusEffect { StatusEffect = ScrollEffects.S_CHEETAH_EFFECT_NAME, ChanceToContract = 100 },
                        }
                    }
                },
                ItemVisuals = new SL_ItemVisual
                {
                    Prefab_SLPack = Plugin.PACKID,
                    Prefab_AssetBundle = "scrolls",
                    Prefab_Name = "bluescroll"
                },
            };
            cheetahScroll.SLPackName = Plugin.PACKID;
            cheetahScroll.SubfolderName = "BlueScroll";
            cheetahScroll.ApplyTemplate();

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
                            new SL_PlaySoundEffect { MinPitch = 1f, MaxPitch = 1f, Follow = true, Sounds = new List<GlobalAudioManager.Sounds> { GlobalAudioManager.Sounds.SFX_SKILL_Mist } },
                            new SL_AddStatusEffect { StatusEffect = ScrollEffects.S_SHIMMER_EFFECT_NAME, ChanceToContract = 100 },
                        }
                    }
                },
                ItemVisuals = new SL_ItemVisual
                {
                    Prefab_SLPack = Plugin.PACKID,
                    Prefab_AssetBundle = "scrolls",
                    Prefab_Name = "bluescroll"
                },
            };
            shimmerScroll.SLPackName = Plugin.PACKID;
            shimmerScroll.SubfolderName = "BlueScroll";
            shimmerScroll.ApplyTemplate();

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
                            new SL_PlaySoundEffect { MinPitch = 1f, MaxPitch = 1f, Follow = true, Sounds = new List<GlobalAudioManager.Sounds> { GlobalAudioManager.Sounds.SFX_SKILL_Warm } },
                            new SL_PlayTimedVFX { VFXPrefab = SL_PlayVFX.VFXPrefabs.VFXGiftOfBlood, AutoStopTime = 3f },
                            new SL_AddStatusEffect { StatusEffect = ScrollEffects.S_LES_REGENERATION_EFFECT_NAME, ChanceToContract = 100 },
                        }
                    }
                },
                ItemVisuals = new SL_ItemVisual
                {
                    Prefab_SLPack = Plugin.PACKID,
                    Prefab_AssetBundle = "scrolls",
                    Prefab_Name = "bluescroll"
                },
            };
            lesregScroll.SLPackName = Plugin.PACKID;
            lesregScroll.SubfolderName = "BlueScroll";
            lesregScroll.ApplyTemplate();

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
                            new SL_PlaySoundEffect { MinPitch = 1f, MaxPitch = 1f, Follow = true, Sounds = new List<GlobalAudioManager.Sounds> { GlobalAudioManager.Sounds.SFX_SKILL_BoonSpell } },
                            new SL_PlayTimedVFX { VFXPrefab = SL_PlayVFX.VFXPrefabs.VFXDiscipline, AutoStopTime = 3f },
                            new SL_AddStatusEffect { StatusEffect = ScrollEffects.S_LES_REINVIGORATION_EFFECT_NAME, ChanceToContract = 100 },
                        }
                    }
                },
                ItemVisuals = new SL_ItemVisual
                {
                    Prefab_SLPack = Plugin.PACKID,
                    Prefab_AssetBundle = "scrolls",
                    Prefab_Name = "bluescroll"
                },
            };
            lesreiScroll.SLPackName = Plugin.PACKID;
            lesreiScroll.SubfolderName = "BlueScroll";
            lesreiScroll.ApplyTemplate();

            SL_Item lesacuScroll = new SL_Item()
            {
                Target_ItemID = BLANK_SCROLL,
                New_ItemID = SCROLL_LES_REG,
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
                            new SL_PlaySoundEffect { MinPitch = 1f, MaxPitch = 1f, Follow = true, Sounds = new List<GlobalAudioManager.Sounds> { GlobalAudioManager.Sounds.SFX_SKILL_CallToElement } },
                            new SL_PlayTimedVFX { VFXPrefab = SL_PlayVFX.VFXPrefabs.VFXBoonEthereal, AutoStopTime = 3f },
                            new SL_AddStatusEffect { StatusEffect = ScrollEffects.S_LES_ACUITY_EFFECT_NAME, ChanceToContract = 100 },
                        }
                    }
                },
                ItemVisuals = new SL_ItemVisual
                {
                    Prefab_SLPack = Plugin.PACKID,
                    Prefab_AssetBundle = "scrolls",
                    Prefab_Name = "bluescroll"
                },
            };
            lesacuScroll.SLPackName = Plugin.PACKID;
            lesacuScroll.SubfolderName = "BlueScroll";
            lesacuScroll.ApplyTemplate();
        }
    }
}
