using HarmonyLib;
using System;
using System.Reflection;
using Maux36.Rimbody;
using Verse;

namespace Maux36.Rimbody_StatModule
{
    [StaticConstructorOnStartup]
    public static class HarmonyInit
    {
        static HarmonyInit()
        {
            var harmony = new Harmony("Harmony_RimbodyStatModule");
            try
            {
                Log.Message($"Rimbody StatModule Loaded");
                harmony.PatchAllUncategorized(Assembly.GetExecutingAssembly());
                if (Rimbody_Utility.IsModActive("ceteam.combatextended"))
                {
                    Log.Message($"Rimbody StatModule detected CE.");
                }
                else
                {
                    Log.Message($"Rimbody StatModule didn't detect CE.");
                    harmony.PatchCategory("NonCE");
                }
                Log.Message("Rimbody patched Stats");
            }
            catch (Exception e)
            {
                Log.Error($"Rimbody Failed to apply StatModule {e}");
            }
        }
    }
}
