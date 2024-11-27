using HarmonyLib;
using Maux36.Rimbody;
using Maux36.Rimbody_CE;
using Maux36.Rimbody_StatModule;
using RimWorld;
using System.Reflection;
using UnityEngine;
using Verse;

namespace Rimbody_StatModule
{
    [HarmonyPatchCategory("NonCE")]
    [HarmonyPatch(typeof(MassUtility), "Capacity")]
    static class Rimbody_NonCE_MassUtility_Patch
    {
        static void Postfix(ref float __result, Pawn p)
        {
            if (__result != 0)
            {
                var compPhysique = p?.TryGetComp<CompPhysique>();
                if (compPhysique != null)
                {
                    var multiplier = 0.75f + (compPhysique.MuscleMass / 100f);
                    __result = __result * multiplier;
                }
            }
        }
    }

    [HarmonyPatch(typeof(Need_Food), "get_MalnutritionSeverityPerInterval")]
    static class MalnutritionPatch
    {
        static bool Prefix(ref float __result, Need_Food __instance)
        {
            var pawnField = typeof(Need).GetField("pawn", BindingFlags.NonPublic | BindingFlags.Instance);
            var pawn = (Pawn)pawnField.GetValue(__instance);
            if (pawn?.needs?.food.Starving == true)
            {
                var compPhysique = pawn.TryGetComp<CompPhysique>();
                if (compPhysique != null)
                {
                    __result = 0.0011325f * (1.2f - (0.7f * Mathf.Pow(compPhysique.BodyFat / 50, 2)));
                    return false;
                }
            }
            return true;
        }
    }
}
