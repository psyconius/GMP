using System.Collections.Generic;
using SideLoader;
using HarmonyLib;
using UnityEngine;
using GMP.Network;
using System;

namespace GMP
{
    public class Harmonize
    {
        // To allow access from patches
        public static Harmonize Instance { get; private set; }

        internal void Awake()
        {
            Instance = this;
        }

        [HarmonyPrefix, HarmonyPatch(typeof(Item), nameof(Item.OnUse))]
        private static void UsePatch(Character _targetChar, Item __instance)
        {
            if (!_targetChar.IsLocalPlayer)
                return;
            if (__instance.ItemID == GMPItems.LUCKY_DICE) // Check for Lucky Dice
            {
                LuckyDiceEffect(_targetChar);
            }
            else if (__instance.ItemID == GMPItems.DICE || __instance.ItemID == GMPItems.FANCY_DICE) // Check for normal dice
            {
                DoDiceRoll(_targetChar);
            }
            else if (__instance.ItemID == BlueScrolls.SCROLL_CHAOTIC) // Check for Scroll of Chaotic Blessing
            {
                ChaoticBlessingEffect();
            }
        }


        private static void LuckyDiceEffect(Character _targetChar)
        {
            Character character = CharacterManager.Instance.GetFirstLocalCharacter();

            // Make sure that we are outside the 10 minute window via check for base effect
            if (!_targetChar.StatusEffectMngr.HasStatusEffect(GMPEffects.LUCKY_DICE_EFFECT_NAME))
            {
                // Add Lucky Dice effect
                character.StatusEffectMngr.AddStatusEffect(GMPEffects.LUCKY_DICE_EFFECT_NAME);

                // Build effect list
                List<string> effectList = new List<string> { "Rage", "Discipline", "Warm", "Cool", "Elemental Resistance", "Speed Up", "Confusion", "Pain", "Chill", "Burn", "Elemental Vulnerability", "Slow Down" };

                // Add random status
                int rng = UnityEngine.Random.Range(0, 11);
                character.StatusEffectMngr.AddStatusEffect(effectList[rng]);
            }
            else
            {
                string loc = LocalizationManager.Instance.GetLoc("Rolling the dice has no effect.");
                character.CharacterUI.ShowInfoNotification(loc);
            }
        }

        private static void DoDiceRoll(Character _targetChar)
        {
            // Dice roll for multiplayer (and solo) message
            int rng = UnityEngine.Random.Range(2, 12);
            GMPNetwork.Instance.SendNotificationRequest(_targetChar.Name + " has rolled a " + rng);
        }

        private static void ChaoticBlessingEffect()
        {
            // Add random effects for Scroll of Chaotic Blessing
            Character character = CharacterManager.Instance.GetFirstLocalCharacter();

            List<string> posEffects = new List<string> { "Warm", "Cool", "Mist", "Bless", "Possessed", "Rage", "Discipline", "Speed Up" };
            List<string> negEffects = new List<string> { "Confusion", "Pain", "Burn", "Chill", "Haunted", "Doom", "Curse", "Slow Down" };
            int rngPos = UnityEngine.Random.Range(0, 7);
            int rngNeg = UnityEngine.Random.Range(0, 7);

            character.StatusEffectMngr.AddStatusEffect(posEffects[rngPos]);
            character.StatusEffectMngr.AddStatusEffect(negEffects[rngNeg]);
        }

        [HarmonyPrefix, HarmonyPatch(typeof(CraftingMenu), nameof(CraftingMenu.TryCraft))]
        private static bool OnTryCraft(CraftingMenu __instance)
        {
            return (true);
        }
    }

}
