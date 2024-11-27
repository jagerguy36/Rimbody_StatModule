using HarmonyLib;
using System;
using System.Reflection;
using Verse;

namespace Rimbody_StatModule
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
                if (!ModsConfig.IsActive("ceteam.combatextended"))
                {
                    Log.Message($"Rimbody StatModule detected CE");
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
