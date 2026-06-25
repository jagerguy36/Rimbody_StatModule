using HarmonyLib;
using Maux36.Rimbody;
using Verse;

namespace Rimbody_StatModule
{
    public class Rimbody_CarryBulk_StatWorker : StatWorker
    {
        public float Offset = 0f;
        public override bool ShouldShowFor(StatRequest req)
        {
            Pawn pawn = req.Pawn ?? (req.Thing as Pawn);
            if (pawn?.compPhysique()?.HasPhysique == true)
            {
                return true;
            }
            return false;
        }

        public override float GetBaseValueFor(StatRequest req)
        {
            Pawn pawn = req.Pawn ?? (req.Thing as Pawn);
            float result = base.GetBaseValueFor(req);
            var compPhysique = pawn?.compPhysique;
            if (compPhysique?.HasPhysique == true)
            {
                result += += (compPhysique.brawn - 1f)*10f;
            }
            return result;
        }
    }
}