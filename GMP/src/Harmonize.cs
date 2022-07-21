using System;
using SideLoader;
using HarmonyLib;

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
          
            
        }

    }
}
