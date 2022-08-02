using System;
using System.Collections.Generic;
using SideLoader;

namespace GMP
{
    public class MiscRecipes
    {
        // Dice
        public const string BLANK_DICE_REC = "gmp.blankdice";
        public const string LUCKY_DICE_REC = "gmp.luckydice";

        public const int BLANK_DICE_REC_ID = -31096;
        public const int LUCKY_DICE_REC_ID = -31097;

        // Misc
        public const string VIAL_FIREFLIES_REC = "gmp.vialfireflies";
        public const int VIAL_FIREFLIES_REC_ID = -31691;
        private const int VIAL_FIREFLIES_REC_VAL = 50;

        // Ingredients
        private const int GOLD_INGOT = 6300030;

        private const string ING_OIL = "6600070";
        private const string ING_IRONSCRAP = "6400140";
        private const string ING_FIREFLYPOWDER = "6000010";

        public static void Init()
        {
            CreateMiscRecipes();
            CreateMiscRecipeScrolls();
        }

        private static void CreateMiscRecipes()
        {
            SL_Recipe vialFireflies = new SL_Recipe()
            {
                UID = VIAL_FIREFLIES_REC,
                StationType = Recipe.CraftingType.Survival,
                Ingredients = new List<SL_Recipe.Ingredient>()
                {
                    new SL_Recipe.Ingredient(){ Type = RecipeIngredient.ActionTypes.AddGenericIngredient, SelectorValue = "Water" },
                    new SL_Recipe.Ingredient(){ Type = RecipeIngredient.ActionTypes.AddSpecificIngredient, SelectorValue = ING_OIL },
                    new SL_Recipe.Ingredient(){ Type = RecipeIngredient.ActionTypes.AddSpecificIngredient, SelectorValue = ING_IRONSCRAP },
                    new SL_Recipe.Ingredient(){ Type = RecipeIngredient.ActionTypes.AddSpecificIngredient, SelectorValue = ING_FIREFLYPOWDER }
                },
                Results = new List<SL_Recipe.ItemQty>()
                {
                    new SL_Recipe.ItemQty(){ ItemID = GMPItems.FIREFLY_PUREE, Quantity = 3 },
                }
            };
            vialFireflies.ApplyTemplate();
        }

        private static void CreateMiscRecipeScrolls()
        {
            SL_RecipeItem fireflyPureeScroll = new SL_RecipeItem()
            {
                RecipeUID = VIAL_FIREFLIES_REC,
                Target_ItemID = 5700187, // Old lantern recipe, for visual
                New_ItemID = VIAL_FIREFLIES_REC_ID,
                Name = "Crafting: Vial of Firefly Puree",
                Description = "Teaches the user how to make Vials of Firefly Puree",
                StatsHolder = new SL_ItemStats { BaseValue = VIAL_FIREFLIES_REC_VAL }
            };
            fireflyPureeScroll.ApplyTemplate();
        }
    }
}
