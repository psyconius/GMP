using System;
using System.Collections.Generic;
using SideLoader;

namespace GMP
{
    public class BandageRecipes
    {
        // Recipe IDs
        public const string HQ_BANDAGE_REC = "gmp.hqBandage";
        public const string CUR_BANDAGE_REC = "gmp.curBandage";
        public const string HW_BANDAGE_REC = "gmp.hwBandage";
        public const string COOL_BANDAGE_REC = "gmp.coolBandage";
        public const string RESTO_BANDAGE_REC = "gmp.restoBandage";

        // Recipe Scroll IDs
        public const int HQ_BANDAGE_REC_ID = -31600;
        public const int CUR_BANDAGE_REC_ID = -31601;
        public const int HW_BANDAGE_REC_ID = -31602;
        public const int COOL_BANDAGE_REC_ID = -31603;
        public const int RESTO_BANDAGE_REC_ID = -31604;

        // Schematic costs
        public const int TIER1_COST = 75;
        public const int TIER2_COST = 150;

        // Ingredients
        public const string ING_BANDAGES = "4400010";
        public const string ING_LINEN = "6500090";
        public const string ING_HIDE = "6600020";
        public const string ING_LIFEPOTION = "4300010";
        public const string ING_GREATLIFEPOTION = "4300240";
        public const string ING_ANTIDOTE = "4300110";
        public const string ING_WARMPOTION = "4300070";
        public const string ING_COOLPOTION = "4300080";

        // Drop table UIDs
        const string HQ_BANDAGE_DTID = "gothiska.hqbandage_dt";
        const string CURHWCOOL_BANDAGE_DTID = "gothiska.curhwcoolbandage_dt";
        const string RESTO_BANDAGE_DTID = "gothiska.restobandage_dt";

        public static void Init()
        {
            CreateRecipes();
            CreateRecipeScrolls();
            CreateDropTables();
        }

        private static void CreateRecipes()
        {
            SL_Recipe hqBandageRecipe = new SL_Recipe()
            {
                UID = HQ_BANDAGE_REC,
                StationType = Recipe.CraftingType.Survival,
                Ingredients = new List<SL_Recipe.Ingredient>()
                {
                    new SL_Recipe.Ingredient(){ Type = RecipeIngredient.ActionTypes.AddSpecificIngredient, SelectorValue = ING_BANDAGES },
                    new SL_Recipe.Ingredient(){ Type = RecipeIngredient.ActionTypes.AddSpecificIngredient, SelectorValue = ING_BANDAGES },
                    new SL_Recipe.Ingredient(){ Type = RecipeIngredient.ActionTypes.AddSpecificIngredient, SelectorValue = ING_LIFEPOTION },
                    new SL_Recipe.Ingredient(){ Type = RecipeIngredient.ActionTypes.AddSpecificIngredient, SelectorValue = ING_LIFEPOTION }
                },
                Results = new List<SL_Recipe.ItemQty>()
                {
                    new SL_Recipe.ItemQty(){ ItemID = GMPItems.HQ_BANDAGE, Quantity = 1 },
                }
            };
            hqBandageRecipe.ApplyTemplate();

            SL_Recipe curativeBandageRecipe = new SL_Recipe()
            {
                UID = CUR_BANDAGE_REC,
                StationType = Recipe.CraftingType.Survival,
                Ingredients = new List<SL_Recipe.Ingredient>()
                {
                    new SL_Recipe.Ingredient(){ Type = RecipeIngredient.ActionTypes.AddSpecificIngredient, SelectorValue = ING_BANDAGES },
                    new SL_Recipe.Ingredient(){ Type = RecipeIngredient.ActionTypes.AddSpecificIngredient, SelectorValue = ING_BANDAGES },
                    new SL_Recipe.Ingredient(){ Type = RecipeIngredient.ActionTypes.AddSpecificIngredient, SelectorValue = ING_ANTIDOTE }
                },
                Results = new List<SL_Recipe.ItemQty>()
                {
                    new SL_Recipe.ItemQty(){ ItemID = GMPItems.CUR_BANDAGE, Quantity = 1 },
                }
            };
            curativeBandageRecipe.ApplyTemplate();

            SL_Recipe hwBandageRecipe = new SL_Recipe()
            {
                UID = HW_BANDAGE_REC,
                StationType = Recipe.CraftingType.Survival,
                Ingredients = new List<SL_Recipe.Ingredient>()
                {
                    new SL_Recipe.Ingredient(){ Type = RecipeIngredient.ActionTypes.AddSpecificIngredient, SelectorValue = ING_BANDAGES },
                    new SL_Recipe.Ingredient(){ Type = RecipeIngredient.ActionTypes.AddSpecificIngredient, SelectorValue = ING_BANDAGES },
                    new SL_Recipe.Ingredient(){ Type = RecipeIngredient.ActionTypes.AddSpecificIngredient, SelectorValue = ING_WARMPOTION },
                    new SL_Recipe.Ingredient(){ Type = RecipeIngredient.ActionTypes.AddSpecificIngredient, SelectorValue = ING_HIDE }
                },
                Results = new List<SL_Recipe.ItemQty>()
                {
                    new SL_Recipe.ItemQty(){ ItemID = GMPItems.HW_BANDAGE, Quantity = 1 },
                }
            };
            hwBandageRecipe.ApplyTemplate();

            SL_Recipe coolBandageRecipe = new SL_Recipe()
            {
                UID = COOL_BANDAGE_REC,
                StationType = Recipe.CraftingType.Survival,
                Ingredients = new List<SL_Recipe.Ingredient>()
                {
                    new SL_Recipe.Ingredient(){ Type = RecipeIngredient.ActionTypes.AddSpecificIngredient, SelectorValue = ING_BANDAGES },
                    new SL_Recipe.Ingredient(){ Type = RecipeIngredient.ActionTypes.AddSpecificIngredient, SelectorValue = ING_BANDAGES },
                    new SL_Recipe.Ingredient(){ Type = RecipeIngredient.ActionTypes.AddSpecificIngredient, SelectorValue = ING_COOLPOTION },
                    new SL_Recipe.Ingredient(){ Type = RecipeIngredient.ActionTypes.AddSpecificIngredient, SelectorValue = ING_LINEN }
                },
                Results = new List<SL_Recipe.ItemQty>()
                {
                    new SL_Recipe.ItemQty(){ ItemID = GMPItems.COOL_BANDAGE, Quantity = 1 },
                }
            };
            coolBandageRecipe.ApplyTemplate();

            SL_Recipe restoBandageRecipe = new SL_Recipe()
            {
                UID = RESTO_BANDAGE_REC,
                StationType = Recipe.CraftingType.Survival,
                Ingredients = new List<SL_Recipe.Ingredient>()
                {
                    new SL_Recipe.Ingredient(){ Type = RecipeIngredient.ActionTypes.AddSpecificIngredient, SelectorValue = ING_BANDAGES },
                    new SL_Recipe.Ingredient(){ Type = RecipeIngredient.ActionTypes.AddSpecificIngredient, SelectorValue = ING_BANDAGES },
                    new SL_Recipe.Ingredient(){ Type = RecipeIngredient.ActionTypes.AddSpecificIngredient, SelectorValue = ING_GREATLIFEPOTION },
                    new SL_Recipe.Ingredient(){ Type = RecipeIngredient.ActionTypes.AddSpecificIngredient, SelectorValue = ING_GREATLIFEPOTION }
                },
                Results = new List<SL_Recipe.ItemQty>()
                {
                    new SL_Recipe.ItemQty(){ ItemID = GMPItems.RESTO_BANDAGE, Quantity = 1 },
                }
            };
            restoBandageRecipe.ApplyTemplate();
        }

        private static void CreateRecipeScrolls()
        {
            SL_RecipeItem hqRecipeScroll = new SL_RecipeItem()
            {
                RecipeUID = HQ_BANDAGE_REC,
                Target_ItemID = 5700187, // Old lantern recipe, for visual
                New_ItemID = HQ_BANDAGE_REC_ID,
                Name = "Crafting: High Quality Bandage",
                Description = "Recipe for crafting bandages with enhanced healing properties.",
                StatsHolder = new SL_ItemStats { BaseValue = TIER1_COST }
            };
            hqRecipeScroll.ApplyTemplate();

            SL_RecipeItem curativeRecipeScroll = new SL_RecipeItem()
            {
                RecipeUID = CUR_BANDAGE_REC,
                Target_ItemID = 5700187, // Old lantern recipe, for visual
                New_ItemID = CUR_BANDAGE_REC_ID,
                Name = "Crafting: Curative Bandage",
                Description = "Recipe for crafting bandages with enhanced healing and curative properties.",
                StatsHolder = new SL_ItemStats { BaseValue = TIER1_COST }
            };
            curativeRecipeScroll.ApplyTemplate();

            SL_RecipeItem hwRecipeScroll = new SL_RecipeItem()
            {
                RecipeUID = HW_BANDAGE_REC,
                Target_ItemID = 5700187, // Old lantern recipe, for visual
                New_ItemID = HW_BANDAGE_REC_ID,
                Name = "Crafting: Heavy Wool Bandage",
                Description = "Recipe for crafting bandages with enhanced healing and frost protection properties.",
                StatsHolder = new SL_ItemStats { BaseValue = TIER1_COST }
            };
            hwRecipeScroll.ApplyTemplate();

            SL_RecipeItem coolRecipeScroll = new SL_RecipeItem()
            {
                RecipeUID = COOL_BANDAGE_REC,
                Target_ItemID = 5700187, // Old lantern recipe, for visual
                New_ItemID = COOL_BANDAGE_REC_ID,
                Name = "Crafting: Cooling Bandage",
                Description = "Recipe for crafting bandages with enhanced healing and heat protection properties.",
                StatsHolder = new SL_ItemStats { BaseValue = TIER1_COST }
            };
            coolRecipeScroll.ApplyTemplate();

            SL_RecipeItem restoRecipeScroll = new SL_RecipeItem()
            {
                RecipeUID = RESTO_BANDAGE_REC,
                Target_ItemID = 5700187, // Old lantern recipe, for visual
                New_ItemID = RESTO_BANDAGE_REC_ID,
                Name = "Crafting: Restorative Bandage",
                Description = "Recipe for crafting bandages with greatly enhanced healing properties.",
                StatsHolder = new SL_ItemStats { BaseValue = TIER2_COST }
            };
            restoRecipeScroll.ApplyTemplate();
        }

        private static void CreateDropTables()
        {

            SL_DropTable hqBandageDT = new SL_DropTable()
            {
                UID = HQ_BANDAGE_DTID,
                GuaranteedDrops = new List<SL_ItemDrop>()
                {
                    new SL_ItemDrop { DroppedItemID = HQ_BANDAGE_REC_ID, MinQty = 1, MaxQty = 1 }
                },
            };
            hqBandageDT.ApplyTemplate();

            SL_DropTable curhwcoolDT = new SL_DropTable
            {
                UID = CURHWCOOL_BANDAGE_DTID,
                RandomTables = new List<SL_RandomDropGenerator>
                {
                    new SL_RandomDropGenerator
                    {
                        MinNumberOfDrops = 0,
                        MaxNumberOfDrops = 1,
                        NoDrop_DiceValue = 3,
                        Drops = new List<SL_ItemDropChance>
                        {
                            new SL_ItemDropChance { DroppedItemID = CUR_BANDAGE_REC_ID, DiceValue = 3 },
                            new SL_ItemDropChance { DroppedItemID = HW_BANDAGE_REC_ID, DiceValue = 3 },
                            new SL_ItemDropChance { DroppedItemID = COOL_BANDAGE_REC_ID, DiceValue = 3 },
                        }
                    }
                }
            };
            curhwcoolDT.ApplyTemplate();

            SL_DropTable restoDT = new SL_DropTable
            {
                UID = RESTO_BANDAGE_DTID,
                RandomTables = new List<SL_RandomDropGenerator>
                {
                    new SL_RandomDropGenerator
                    {
                        MinNumberOfDrops = 0,
                        MaxNumberOfDrops = 1,
                        NoDrop_DiceValue = 9,
                        Drops = new List<SL_ItemDropChance>
                        {
                            new SL_ItemDropChance { DroppedItemID = RESTO_BANDAGE_REC_ID, DiceValue = 3 },
                        }
                    }
                }
            };
            restoDT.ApplyTemplate();

            SL_DropTableAddition hqRecipeVendor = new SL_DropTableAddition
            {
                SelectorTargets =
                {
                    "jFw7BReLDkW6NT5msHloig", //Shopkeeper Doran (Cierzo)
                    "FU5328pcz025ME9tVRYP7g", //Shopkeeper Pleel (Berg)
                    "EMqw2ZGAo02dGNcdj-YGqg", //Shopkeeper Suul (Abrassar)
                    "6fSS8CIi70WgslppPjI54w", //Shopkeeper Suul (Levant)
                    "FU5328pcz025ME9tVRYP7g", //Shopkeeper Lyda (Monsoon)
                    "L6BrQy5mF0uaMWE0FEpiVg", //Felix Jimson (Harmattan)
                    "-MSrkT502k63y3CV2j98TQ", //Caravanner
                    "tS6RgzmRcE-X2jmErKrFfw", //Apprentice Ritualist (Ritualist's Hut)
                },
                DropTableUIDsToAdd = { hqBandageDT.UID }
            };
            hqRecipeVendor.ApplyTemplate();

            SL_DropTableAddition curhwcoolrestoRecipeVendor = new SL_DropTableAddition
            {
                SelectorTargets =
                {
                    "FU5328pcz025ME9tVRYP7g", //Shopkeeper Pleel (Berg)
                    "EMqw2ZGAo02dGNcdj-YGqg", //Shopkeeper Suul (Abrassar)
                    "6fSS8CIi70WgslppPjI54w", //Shopkeeper Suul (Levant)
                    "FU5328pcz025ME9tVRYP7g", //Shopkeeper Lyda (Monsoon)
                    "L6BrQy5mF0uaMWE0FEpiVg", //Felix Jimson (Harmattan)
                    "-MSrkT502k63y3CV2j98TQ", //Caravanner
                    "tS6RgzmRcE-X2jmErKrFfw", //Apprentice Ritualist (Ritualist's Hut)
                },
                DropTableUIDsToAdd = { curhwcoolDT.UID, restoDT.UID }
            };
            curhwcoolrestoRecipeVendor.ApplyTemplate();
        }
    }
}
