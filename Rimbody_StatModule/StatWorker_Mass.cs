using Maux36.Rimbody;
using RimWorld;
using UnityEngine;
using System.Text;
using Verse;

namespace Maux36.Rimbody_StatModule
{
    public class StatWorker_Mass : StatWorker
    {
        public override float GetValueUnfinalized(StatRequest req, bool applyPostProcess = true)
        {
            Pawn pawn = req.Pawn ?? (req.Thing as Pawn);
            if (req.Thing is Corpse corpse)
            {
                pawn = corpse.InnerPawn;
            }
            var compPhysique = pawn?.compPhysique();
            if (compPhysique?.HasPhysique == true)
            {
                float value = Mathf.RoundToInt((0.7f * (compPhysique.BodyFat + compPhysique.MuscleMass)) - 20f);
                return base.GetValueUnfinalized(req, applyPostProcess) + value;
            }
            return base.GetValueUnfinalized(req, applyPostProcess);
        }

        public override string GetExplanationUnfinalized(StatRequest req, ToStringNumberSense numberSense)
        {
            string baseExpl = base.GetExplanationUnfinalized(req, numberSense);
            Pawn pawn = req.Pawn ?? (req.Thing as Pawn);
            if (req.Thing is Corpse corpse)
            {
                pawn = corpse.InnerPawn;
            }
            var compPhysique = pawn?.compPhysique();
            if (compPhysique?.HasPhysique == true)
            {
                float value = Mathf.RoundToInt((0.7f * (compPhysique.BodyFat + compPhysique.MuscleMass)) - 20f);
                string valueLine = "RB_Stat_BodyWeightOffset".Translate() + ": " + stat.ValueToString(value);
                return $"{baseExpl}\n{valueLine}";
            }
            return baseExpl;
        }
    }
}
