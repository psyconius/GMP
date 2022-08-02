using HarmonyLib;
using NodeCanvas.DialogueTrees;
using System.Collections.Generic;

namespace Gunblade
{
    public class Harmonize
    {
        // To allow access from patches
        public static Harmonize Instance { get; private set; }

        internal void Awake()
        {
            Instance = this;
        }

        [HarmonyPrefix, HarmonyPatch(typeof(Gatherable), nameof(Gatherable.OnGatherInteraction))]
        private static void GatherPatch(Character _gatherer, Gatherable __instance)
        {

        }
    }
}


