using RimWorld;
using System;
using Verse;

namespace Rimbody_StatModule
{
    public class Rimbody_StatModule : Mod
    {
        public const string CoreRequirement = "1.2.8";
        public static string currentVersion;
        public Rimbody_StatModule(ModContentPack content) : base(content)
        {
            currentVersion = content.ModMetaData.ModVersion;
            var RimbodyModData = ModLister.GetActiveModWithIdentifier("Maux36.Rimbody", ignorePostfix: true);
            if (RimbodyModData == null)
            {
                Log.Error("[Rimbody - Stat Module] Stats module could not find its required dependency: Rimbody. This is a critical component, and your game will not work without it.");
            }
            else
            {
                var RimbodyVersion = new Version(RimbodyModData.ModVersion);
                if (RimbodyVersion < new Version(CoreRequirement))
                    Log.Error($"[Rimbody - Stat Module] Stat Module version {currentVersion} requires Rimbody version {CoreRequirement} or above. Your Rimbody ({RimbodyVersion}) needs to be updated or you will experience errors. If Steam does not automatically updates your mod, you can try un-subbing and re-subbing to force the update.");
            }
        }
    }
}
