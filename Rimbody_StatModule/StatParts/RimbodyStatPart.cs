using Maux36.Rimbody;
using RimWorld;
using Verse;

namespace Maux36.Rimbody_StatModule
{
    public class PhysiqueCorpulentStatPart: StatPart // M,F 0.5 ~ 1.375
    {
        public override void TransformValue(StatRequest req, ref float val)
        {
            if (req.HasThing && req.Thing is Pawn pawn)
            {
                var compPhysique = pawn.compPhysique();
                if (compPhysique?.HasPhysique == true)
                {
                    val *= CorpulentMultiplier(compPhysique);
                }
            }
        }

        public override string ExplanationPart(StatRequest req)
        {
            if (req.HasThing && req.Thing is Pawn pawn)
            {
                var compPhysique = pawn.compPhysique();
                if (compPhysique?.HasPhysique == true)
                {
                    return "RB_Stat_MuscleFatMult".Translate() + CorpulentMultiplier(compPhysique).ToStringPercent();
                }
            }
            return null;
        }

        private static float CorpulentMultiplier(CompPhysique compPhysique)
        {
            return ((0.7f * (compPhysique.MuscleMass + compPhysique.BodyFat)) + 40f) * 0.0125f;
        }
    }
    public class PhysiqueBrawnWeightCapacityPart : StatPart // M 
    {
        public override void TransformValue(StatRequest req, ref float val)
        {
            if (req.HasThing && req.Thing is Pawn pawn)
            {
                var compPhysique = pawn.compPhysique();
                if (compPhysique?.HasPhysique == true)
                {
                    val += 30f * (compPhysique.brawn - 1f);
                }
            }
        }

        public override string ExplanationPart(StatRequest req)
        {
            if (req.HasThing && req.Thing is Pawn pawn)
            {
                var compPhysique = pawn.compPhysique();
                if (compPhysique?.HasPhysique == true)
                {
                    return "RB_Stat_CapacityOffset".Translate() + (30f * (compPhysique.brawn - 1f)).ToStringWithSign();
                }
            }
            return null;
        }
    }

    public class PhysiqueBrawnBulkCapacityPart : StatPart // M 
    {
        public override void TransformValue(StatRequest req, ref float val)
        {
            if (req.HasThing && req.Thing is Pawn pawn)
            {
                var compPhysique = pawn.compPhysique();
                if (compPhysique?.HasPhysique == true)
                {
                    val += 10f * (compPhysique.brawn - 1f);
                }
            }
        }

        public override string ExplanationPart(StatRequest req)
        {
            if (req.HasThing && req.Thing is Pawn pawn)
            {
                var compPhysique = pawn.compPhysique();
                if (compPhysique?.HasPhysique == true)
                {
                    return "RB_Stat_CapacityOffset".Translate() + (10f * (compPhysique.brawn - 1f)).ToStringWithSign();
                }
            }
            return null;
        }
    }

    public class PhysiqueMuscleStrengthPart : StatPart// M 0.85 ~ 1.15
    {
        public override void TransformValue(StatRequest req, ref float val)
        {
            if (req.HasThing && req.Thing is Pawn pawn)
            {
                var compPhysique = pawn.compPhysique();
                if (compPhysique?.HasPhysique == true)
                {
                    val *= MuscleStrengthMultiplier(compPhysique);
                }
            }
        }

        public override string ExplanationPart(StatRequest req)
        {
            if (req.HasThing && req.Thing is Pawn pawn)
            {
                var compPhysique = pawn.compPhysique();
                if (compPhysique?.HasPhysique == true)
                {
                    return "RB_Stat_CapacityMult".Translate() + MuscleStrengthMultiplier(compPhysique).ToStringPercent();
                }
            }
            return null;
        }

        private float MuscleStrengthMultiplier(CompPhysique compPhysique)
        {
            return 1.0f + ((compPhysique.MuscleMass - 25f) * 0.006f);
        }
    }
    public class PhysiqueMassResistancePart : StatPart// -M 0.85 ~ 1.15
    {
        public override void TransformValue(StatRequest req, ref float val)
        {
            if (req.HasThing && req.Thing is Pawn pawn)
            {
                var compPhysique = pawn.compPhysique();
                if (compPhysique?.HasPhysique == true)
                {
                    val *= MuscleStrengthMultiplier(compPhysique);
                }
            }
        }

        public override string ExplanationPart(StatRequest req)
        {
            if (req.HasThing && req.Thing is Pawn pawn)
            {
                var compPhysique = pawn.compPhysique();
                if (compPhysique?.HasPhysique == true)
                {
                    return "RB_Stat_MuscleFatMult".Translate() + MuscleStrengthMultiplier(compPhysique).ToStringPercent();
                }
            }
            return null;
        }

        private float MuscleStrengthMultiplier(CompPhysique compPhysique)
        {
            return 1f - (((2f * compPhysique.MuscleMass) + compPhysique.BodyFat - 75f) * 0.002f);
        }
    }

    public class PhysiqueFatHinderancePart : StatPart // -F 0.85~1.15
    {
        public override void TransformValue(StatRequest req, ref float val)
        {
            if (req.HasThing && req.Thing is Pawn pawn)
            {
                var compPhysique = pawn.compPhysique();
                if (compPhysique?.HasPhysique == true)
                {
                    val *= FatHinderanceMultiplier(compPhysique);
                }
            }
        }

        public override string ExplanationPart(StatRequest req)
        {
            if (req.HasThing && req.Thing is Pawn pawn)
            {
                var compPhysique = pawn.compPhysique();
                if (compPhysique?.HasPhysique == true)
                {
                    return "RB_Stat_FatHinderanceMult".Translate() + FatHinderanceMultiplier(compPhysique).ToStringPercent();
                }
            }
            return null;
        }

        private float FatHinderanceMultiplier(CompPhysique compPhysique)
        {
            return 1.0f + ((25f-compPhysique.BodyFat)*0.006f);
        }
    }

    public class Physique2M1FPart : StatPart // 2M,F 0.7~1.3
    {
        public override void TransformValue(StatRequest req, ref float val)
        {
            if (req.HasThing && req.Thing is Pawn pawn)
            {
                var compPhysique = pawn.compPhysique();
                if (compPhysique?.HasPhysique == true)
                {
                    val *= ArrestChanceMultiplier(compPhysique);
                }
            }
        }

        public override string ExplanationPart(StatRequest req)
        {
            if (req.HasThing && req.Thing is Pawn pawn)
            {
                var compPhysique = pawn.compPhysique();
                if (compPhysique?.HasPhysique == true)
                {
                    return "RB_Stat_MuscleFatMult".Translate() + ArrestChanceMultiplier(compPhysique).ToStringPercent();
                }
            }
            return null;
        }

        private float ArrestChanceMultiplier(CompPhysique compPhysique)
        {
            return 1f + (((2f * compPhysique.MuscleMass) + compPhysique.BodyFat - 75f) * 0.004f);
        }
    }
    public class Physique1M1FPart : StatPart// M,F 0.8 ~ 1.2
    {
        public override void TransformValue(StatRequest req, ref float val)
        {
            if (req.HasThing && req.Thing is Pawn pawn)
            {
                var compPhysique = pawn.compPhysique();
                if (compPhysique?.HasPhysique == true)
                {
                    val *= ConsumptionMultiplier(compPhysique);
                }
            }
        }

        public override string ExplanationPart(StatRequest req)
        {
            if (req.HasThing && req.Thing is Pawn pawn)
            {
                var compPhysique = pawn.compPhysique();
                if (compPhysique?.HasPhysique == true)
                {
                    return "RB_Stat_MuscleFatMult".Translate() + ConsumptionMultiplier(compPhysique).ToStringPercent();
                }
            }
            return null;
        }

        private float ConsumptionMultiplier(CompPhysique compPhysique)
        {
            return 1f + ((compPhysique.MuscleMass + compPhysique.BodyFat - 50f) * 0.004f);
        }
    }
    public class PhysiqueTemperatureMinPart : StatPart // M,2F 6 ~ -6
    {
        public override void TransformValue(StatRequest req, ref float val)
        {
            if (req.HasThing && req.Thing is Pawn pawn)
            {
                var compPhysique = pawn.compPhysique();
                if (compPhysique?.HasPhysique == true)
                {
                    val += TemperatureOffset(compPhysique);
                }
            }
        }

        public override string ExplanationPart(StatRequest req)
        {
            if (req.HasThing && req.Thing is Pawn pawn)
            {
                var compPhysique = pawn.compPhysique();
                if (compPhysique?.HasPhysique == true)
                {
                    return "RB_Stat_MuscleFatTempOffset".Translate() + TemperatureOffset(compPhysique).ToStringTemperatureOffset();
                }
            }
            return null;
        }

        private float TemperatureOffset(CompPhysique compPhysique)
        {
            return -(compPhysique.MuscleMass + (2f * compPhysique.BodyFat) - 75f) * 0.08f;
        }
    }
    public class PhysiqueTemperatureMaxPart : StatPart // M,2F 3 ~ -3
    {
        public override void TransformValue(StatRequest req, ref float val)
        {
            if (req.HasThing && req.Thing is Pawn pawn)
            {
                var compPhysique = pawn.compPhysique();
                if (compPhysique?.HasPhysique == true)
                {
                    val += TemperatureOffset(compPhysique);
                }

            }
        }

        public override string ExplanationPart(StatRequest req)
        {
            if (req.HasThing && req.Thing is Pawn pawn)
            {
                var compPhysique = pawn.compPhysique();
                if (compPhysique?.HasPhysique == true)
                {
                    return "RB_Stat_MuscleFatTempOffset".Translate() + TemperatureOffset(compPhysique).ToStringTemperatureOffset();
                }
            }
            return null;
        }

        private float TemperatureOffset(CompPhysique compPhysique)
        {
            return -(compPhysique.MuscleMass + (2f * compPhysique.BodyFat) - 75f) * 0.04f;
        }
    }
}
