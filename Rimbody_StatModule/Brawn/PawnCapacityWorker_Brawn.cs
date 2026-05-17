using RimWorld;
using System.Collections.Generic;
using Verse;

namespace Rimbody_StatModule
{
    public class PawnCapacityWorker_Brawn : PawnCapacityWorker
    {
        public override float CalculateCapacityLevel(HediffSet diffSet, List<PawnCapacityUtility.CapacityImpactor> impactors = null)
        {
            return 1f;
        }

        public override bool CanHaveCapacity(BodyDef body)
        {
            return true;
        }
    }
}
