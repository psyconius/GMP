using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;
using SideLoader;
using UnityEngine;
using GMP.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GMP
{
    [BepInPlugin(GUID, NAME, VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        // To be able to fucking log from other file
        public static Plugin Instance { get; private set; }

        // Choose a GUID for your project. Change "myname" and "mymod".
        public const string GUID = "gothiska.GMP";
        // Choose a NAME for your project, generally the same as your Assembly Name.
        public const string NAME = "GMP - Gothiska Mod Pack";
        // Increment the VERSION when you release a new version of your mod.
        public const string VERSION = "0.3.2";

        // For accessing your BepInEx Logger from outside of this class (eg Plugin.Log.LogMessage("");)
        public static ManualLogSource Log;

        // If you need settings, define them like so:
        // public static ConfigEntry<bool> ExampleConfig;

        public const string PACKID = "gothiska-GMP";

        GameObject rpcgo;
        GMPNetwork Rpcs;


        // Awake is called when your plugin is created. Use this to set up your mod.
        internal void Awake()
        {
            Instance = this;

            Log = this.Logger;
            Log.LogMessage($"Successfully loaded {NAME} {VERSION}!");

            // Add extra network functions to a gameObject
            rpcgo = new GameObject(nameof(GMPNetwork));
            Rpcs = rpcgo.AddComponent<GMPNetwork>();
            DontDestroyOnLoad(rpcgo);

            // Any config settings you define should be set up like this:
            // ExampleConfig = Config.Bind("ExampleCategory", "ExampleSetting", false, "This is an example setting.");

            // Harmony is for patching methods. If you're not patching anything, you can comment-out or delete this line.
            Harmony.CreateAndPatchAll(typeof(Harmonize));

            SL.OnPacksLoaded += SL_OnPacksLoaded;
        }

        private void Update()
        {
            // hurt self to test
            if (Input.GetKeyUp(KeyCode.KeypadMinus))
            {
                Character myChar = CharacterManager.Instance.GetFirstLocalCharacter();
                //EnvironmentConditions.Instance.SetTimeOfDay(22f);

                myChar.Stats.AffectHealth(-50f);
                myChar.Stats.AffectStamina(-50f);
                myChar.Stats.m_mana -= 50f;

                myChar.Stats.m_burntMana = 95f;
                myChar.Stats.m_burntStamina = 95f;
                myChar.Stats.m_burntMana = 95f;

            }

            if (Input.GetKeyUp(KeyCode.KeypadPlus))
            {
                Character myChar = CharacterManager.Instance.GetFirstLocalCharacter();
                myChar.StatusEffectMngr.RemoveShortStatuses();

                if (myChar.GetComponent<Light>().name == "testlight")
                {
                    Destroy(myChar.GetComponent<Light>());
                }
            }

            if (Input.GetKeyUp(KeyCode.KeypadPeriod))
            {
                Character myCharacter = CharacterManager.Instance.GetFirstLocalCharacter();
                Log.LogMessage("Time of Day: " + EnvironmentConditions.Instance.TimeOfDay);
                Log.LogMessage("Is it night? " + EnvironmentConditions.Instance.GetIsNight(EnvironmentConditions.Instance.TimeOfDay));
            };

     



            //Log.LogMessage("Physical Resist" + myChar.Stats.m_totalDamageResistance[0]);
            //Log.LogMessage("Ethereal Resist" + myChar.Stats.m_totalDamageResistance[1]);
            //Log.LogMessage("Decay resist: " + myChar.Stats.m_totalDamageResistance[2]);
            //Log.LogMessage("Electric Resist" + myChar.Stats.m_totalDamageResistance[3]);
            //Log.LogMessage("Frost resist: " + myChar.Stats.m_totalDamageResistance[4]);
            //Log.LogMessage("Fire resist: " + myChar.Stats.m_totalDamageResistance[5]);
            //Log.LogMessage("Cold Weather Defense: " + myChar.Stats.m_coldProtection.m_currentValue);
            //Log.LogMessage("Hot Weather Defense: " + myChar.Stats.m_heatProtection.m_currentValue);
            //Log.LogMessage("Physical Damage: " + myChar.Stats.m_damageTypesModifier[0].CurrentValue);
            //Log.LogMessage("Ethereal Damage: " + myChar.Stats.m_damageTypesModifier[1].CurrentValue);
            //Log.LogMessage("Decay Damage: " + myChar.Stats.m_damageTypesModifier[2].CurrentValue);
            //Log.LogMessage("Electric Damage: " + myChar.Stats.m_damageTypesModifier[3].CurrentValue);
            //Log.LogMessage("Frost Damage: " + myChar.Stats.m_damageTypesModifier[4].CurrentValue);
            //Log.LogMessage("Fire Damage: " + myChar.Stats.m_damageTypesModifier[5].CurrentValue);
            //Log.LogMessage("Mana Use 'current value': " + myChar.Stats.m_manaUseModifiers.CurrentValue);
            //Log.LogMessage("Mana Use 'm current value': " + myChar.Stats.m_manaUseModifiers.m_currentValue);
            //Log.LogMessage("Mana Use mana aug raw: " + myChar.Stats.m_manaAugmentation.RawValue);
            //Log.LogMessage("Mana Use mana aug perm: " + myChar.Stats.m_manaAugmentation.m_permanent);
            //Log.LogMessage(".......");

            /*
            Log.LogMessage("Burnt Health: " + myChar.Stats.BurntHealth);
            Log.LogMessage("Burnt Health Ratio: " + myChar.Stats.BurntHealthRatio);
            Log.LogMessage("Base Max Health: " + myChar.Stats.BaseMaxHealth);
            Log.LogMessage("Max Health: " + myChar.Stats.MaxHealth);
            Log.LogMessage("Base Max Health: " + myChar.Stats.StartingHealth);
            */

        }

        private void SL_OnPacksLoaded()
        {

            //Effects 
            GMPEffects.Init();
            VolatilePotionEffects.Init();
            ScrollEffects.Init();

            // Bandages, Dice, + Misc
            GMPItems.Init();

            // Scrolls
            Scrolls.Init();

            // Volatile Potions
            VolatilePotions.Init();
        }
    }
}
