using Maux36.Rimbody;
using RimWorld;
using System.Text;
using UnityEngine;
using Verse;

namespace Maux36.Rimbody_StatModule
{
    public class Rimbody_CarryBulk_StatWorker : StatWorker
    {
        public override float GetBaseValueFor(StatRequest req)
        {
            float result = base.GetBaseValueFor(req);
            Pawn pawn = req.Pawn ?? (req.Thing as Pawn);
            var compPhysique = pawn?.compPhysique();
            if (compPhysique?.HasPhysique == true)
            {
                result += (compPhysique.brawn - 1f)*10f;
                result = Mathf.Max(0f, result);
            }
            return result;
        }

        public override string GetExplanationUnfinalized(StatRequest req, ToStringNumberSense numberSense)
        {
            StringBuilder stringBuilder = new StringBuilder();
            float baseValueFor = base.GetBaseValueFor(req);
            if (baseValueFor != 0f || stat.showZeroBaseValue)
            {
                stringBuilder.AppendLine("StatsReport_BaseValue".Translate() + ": " + stat.ValueToString(baseValueFor, numberSense));

                Pawn pawn = req.Pawn ?? (req.Thing as Pawn);
                var compPhysique = pawn?.compPhysique();
                if (compPhysique?.HasPhysique == true)
                {
                    stringBuilder.AppendLine("RB_Stat_Composition".Translate());
                    stringBuilder.AppendLine("    " + "RB_Stat_Brawn_Offset".Translate() + stat.ValueToString((compPhysique.brawn - 1f) * 10f, ToStringNumberSense.Offset));
                }

            }
            GetOffsetsAndFactorsExplanation(req, stringBuilder, baseValueFor);
            return stringBuilder.ToString();
        }
    }
}