using HarmonyLib;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;
using Maux36.Rimbody;
using Verse;

namespace Rimbody_StatModule
{
    [HarmonyPatch(typeof(RaceProperties), "NutritionEatenPerDayExplanation")]
    public static class NutritionExplanation_Transpiler
    {
        static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            List<CodeInstruction> codes = new List<CodeInstruction>(instructions);
            int insertionIndex = -1;
            for (int i = 0; i < codes.Count; i++)
            {
                if (codes[i].opcode == OpCodes.Ldstr && codes[i].operand.ToString() == "StatsReport_FinalValue")
                {
                    insertionIndex = i;
                    break;
                }
            }

            if (insertionIndex != -1)
            {
                codes.Insert(insertionIndex++, new CodeInstruction(OpCodes.Ldloc_0));
                codes.Insert(insertionIndex++, new CodeInstruction(OpCodes.Ldarg_0));
                codes.Insert(insertionIndex++, CodeInstruction.Call(typeof(NutritionExplanationUtil), nameof(NutritionExplanationUtil.Stringmaker), new[] { typeof(StringBuilder), typeof(Pawn) }));
            }
            else
            {
                Log.Error("RimWorld C# Modding: Harmony Transpiler could not find target instruction in NutritionEatenPerDayExplanation.");
            }

            return codes;
        }
    }

    public static class NutritionExplanationUtil
    {
        public static void Stringmaker(StringBuilder sb, Pawn p)
        {
            var compPhysique = p.compPhysique();
            if (compPhysique != null && compPhysique.MuscleMass >= 0 && compPhysique.BodyFat >= 0)
            {
                sb.AppendLine("Body Composition: x " + (1f + ((compPhysique.MuscleMass + compPhysique.BodyFat - 50f) * 0.004f)).ToStringPercent());
                 sb.AppendLine();
            }
        }
    }
}
