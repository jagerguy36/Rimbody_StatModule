using HarmonyLib;
using Maux36.Rimbody;
using Verse;

namespace Rimbody_StatModule
{
    public class Rimbody_CarryBulk_StatWorker : StatWorker
    {
        public float Offset = 0f;
        public override float GetBaseValueFor(StatRequest req)
        {
            Pawn pawn = req.Pawn ?? (req.Thing as Pawn);
            float result = base.GetBaseValueFor(req);
            var compPhysique = pawn?.compPhysique;
            if (compPhysique?.HasPhysique == true)
            {
                result += (compPhysique.brawn - 1f)*10f;
                result = Mathf.Max(0f, result)
            }
            return result;
        }
    }
}