using HarmonyLib;
using Maux36.Rimbody;
using Verse;

namespace Rimbody_StatModule
{
    public class Rimbody_CarryWeight_StatWorker : StatWorker
    {
        public override float GetBaseValueFor(StatRequest req)
        {
            float result = base.GetBaseValueFor(req);
            Pawn pawn = req.Pawn ?? (req.Thing as Pawn);
            var compPhysique = pawn?.compPhysique();
            if (compPhysique?.HasPhysique == true)
            {
                result += (compPhysique.brawn - 1f)*30f;
                result = Mathf.Max(0f, result)
            }
            return result;
        }
    }
}