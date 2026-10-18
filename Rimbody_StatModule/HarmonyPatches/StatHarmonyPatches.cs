using HarmonyLib;
using Maux36.Rimbody;
using RimWorld;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using UnityEngine;
using Verse;

namespace Maux36.Rimbody_StatModule
{
    [HarmonyPatchCategory("NonCE")] //Only needed for Non-CE because CE overtakes this with its own CE_StatDefOf.CarryWeight which gets patched via patchoperation
    [HarmonyPatch(typeof(MassUtility), "Capacity")]
    public static class Rimbody_NonCE_MassUtility_Patch
    {
        private static readonly MethodInfo CustomMultMethod = AccessTools.Method( typeof(Rimbody_NonCE_MassUtility_Patch), nameof(Rimbody_NonCE_MassUtility_Patch.BrawnBasedCapacityMult));
        public static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            var codes = new List<CodeInstruction>(instructions);
            int swapped = 0;
            for (int i = 0; i < codes.Count; i++)
            {
                if (i > 0
                    && codes[i].opcode == OpCodes.Ldc_R4
                    && codes[i].operand is float value
                    && value == 35f
                    && i + 1 < codes.Count
                    && codes[i + 1].opcode == OpCodes.Mul)
                {
                    yield return new CodeInstruction(OpCodes.Ldarg_0);
                    yield return new CodeInstruction(OpCodes.Call, CustomMultMethod);
                    swapped++;
                    continue;
                }
                yield return codes[i];

            }
            if (swapped == 0)
                Log.Error("[Rimbody - Stat Module] Could not replace mass multiplier 35f.");
        }
        public static float BrawnBasedCapacityMult(Pawn p) // 17.5 ~ 70
        {
            float result = 35f;
            var compPhysique = p.compPhysique();
            if (compPhysique?.HasPhysique == true)
                result *= compPhysique.brawn;
            return result;
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
                if (compPhysique?.HasPhysique == true)
                {
                    __result = 0.0011325f * (1.2f - (0.7f * Mathf.Pow(compPhysique.BodyFat / 50, 2)));
                    return false;
                }
            }
            return true;
        }
    }

    [HarmonyPatch(typeof(Need_Food), "FoodFallPerTickAssumingCategory")]
    static class BaseHungerRatePatch
    {
        static void Postfix(ref float __result, Pawn ___pawn)
        {
            var compPhysique = ___pawn.compPhysique();
            if (compPhysique?.HasPhysique == true)
            {
                __result = __result * (1f + ((compPhysique.MuscleMass + compPhysique.BodyFat - 50f) * 0.004f));
            }
        }
    }
}
