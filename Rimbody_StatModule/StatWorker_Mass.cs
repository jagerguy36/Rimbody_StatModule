using Maux36.Rimbody;
using RimWorld;
using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace Rimbody_StatModule
{
    public class StatWorker_Mass : StatWorker
    {
        public override float GetValueUnfinalized(StatRequest req, bool applyPostProcess = true)
        {
            var thing = req.Thing;
            if (thing == null)
            {
                return base.GetValueUnfinalized(req, applyPostProcess);
            }

            if (thing.def.IsCorpse)
            {
                thing = (thing as Corpse)?.InnerPawn;
            }

            var compPhysique = thing.TryGetComp<CompPhysique>();
            return compPhysique != null
                ? base.GetValueUnfinalized(req, applyPostProcess) + Mathf.RoundToInt((0.7f * (compPhysique.BodyFat + compPhysique.MuscleMass)) - 20f)
                : base.GetValueUnfinalized(req, applyPostProcess);
        }

        public override string GetExplanationUnfinalized(StatRequest req, ToStringNumberSense numberSense)
        {
            var stringBuilder = new StringBuilder();
            var thing = req.Thing;
            if (thing == null)
            {
                return base.GetExplanationUnfinalized(req, numberSense);
            }

            if (thing.def.IsCorpse)
            {
                thing = (thing as Corpse)?.InnerPawn;
            }

            var compPhysique = thing.TryGetComp<CompPhysique>();
            if (compPhysique == null)
            {
                return base.GetExplanationUnfinalized(req, numberSense);
            }

            stringBuilder.AppendLine("RB_Stat_BodyWeightOffset".Translate() + ": " +
                                     stat.ValueToString(Mathf.RoundToInt((0.7f * (compPhysique.BodyFat + compPhysique.MuscleMass)) - 20f)));
            return $"{base.GetExplanationUnfinalized(req, numberSense)}\n{stringBuilder.ToString().TrimEndNewlines()}";
        }
    }
}
