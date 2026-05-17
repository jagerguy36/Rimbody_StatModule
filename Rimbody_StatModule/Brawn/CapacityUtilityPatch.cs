using HarmonyLib;
using Maux36.Rimbody;
using Verse;

namespace Rimbody_StatModule
{
    [HarmonyPatch(typeof(PawnCapacityUtility), nameof(PawnCapacityUtility.CalculateCapacityLevel))]
    static class Patch_CalculateCapacityLevel
    {
        static bool Prefix(HediffSet diffSet, PawnCapacityDef capacity, ref float __result)
        {
            if (capacity == DefOfRimbodyStats.Rimbody_Brawn)
            {
                var compPhysique = diffSet.pawn.compPhysique();
                if (compPhysique != null)
                {
                    __result = compPhysique.brawn;
                }
                else
                {
                    __result = 1f;
                }
                return false;
            }

            return true;
        }
    }
}
