using System.Collections.Generic;
using SideLoader;
using HarmonyLib;
using UnityEngine;

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
            if (__instance.ItemID == GMPItems.LUCKY_DICE) // Check for Lucky Dice
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
            else if (__instance.ItemID == GMPItems.DICE || __instance.ItemID == GMPItems.FANCY_DICE)
            {
                var dice = ResourcesPrefabManager.Instance.GetItemPrefab(GMPItems.DICE);
                int rng = Random.Range(2, 12);
                _targetChar.CharacterUI.ShowInfoNotification(_targetChar.Name + " has rolled a " + rng, dice);

                CharacterUI[] characterUIs = CharacterManager.FindObjectsOfType<CharacterUI>();
                Plugin.Log.LogMessage("UIs: " + characterUIs.Length);
                //TODO Fix multiplayer dice
                //foreach (PlayerSystem player in Global.Lobby.PlayersInLobby)
                //{
                //    Character otherchar = player.ControlledCharacter;
                //    Plugin.Log.LogMessage("Connected Player " + otherchar.Name);
                //    Plugin.Log.LogMessage("Connected Player is world host: " + otherchar.IsWorldHost);
                //    Plugin.Log.LogMessage("Connected Player open inventory? " + otherchar.CharacterUI.IsInventoryPanelDisplayed);
                //    CharacterUI cui = otherchar.GetComponent<CharacterUI>();
                //    cui.ShowInfoNotification(_targetChar.Name + " has rolled a " + rng, dice);
                //}
            }
        }

        [HarmonyPrefix, HarmonyPatch(typeof(CraftingMenu), nameof(CraftingMenu.TryCraft))]
        private static bool OnTryCraft(CraftingMenu __instance)
        {
            return (true);
        }
    }

}
