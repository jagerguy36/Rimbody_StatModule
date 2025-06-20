using HarmonyLib;
using Maux36.Rimbody;
using RimWorld;
using UnityEngine;
using Verse;

namespace Rimbody_StatModule
{
    [HarmonyPatchCategory("NonCE")] //Only needed for Non-CE because CE overtakes this with its own CE_StatDefOf.CarryWeight which gets patched via patchoperation
    [HarmonyPatch(typeof(MassUtility), "Capacity")]
    static class Rimbody_NonCE_MassUtility_Patch
    {
        static void Postfix(ref float __result, Pawn p)
        {
            if (__result != 0)
            {
                var compPhysique = p.compPhysique();
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
        static bool Prefix(ref float __result, Need_Food __instance, Pawn ___pawn)
        {
            if (__instance.Starving == true)
            {
                var compPhysique = ___pawn.compPhysique();
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
