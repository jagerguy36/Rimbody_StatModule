using Verse;

namespace Rimbody_StatModule
{
    public class Rimbody_StatModule : Mod
    {
        public Rimbody_StatModule(ModContentPack content) : base(content)
        {
            if (!ModsConfig.IsActive("Maux36.Rimbody"))
            {
                Log.Error("Rimbody_stats module could not find its required dependency: Rimbody. This is a critical component, and your game will not work without it.");
            }
            if (!ModsConfig.IsActive("zetrith.prepatcher"))
            {
                Log.Error("Rimbody_stats module could not find Prepatcher. This means your Rimbody is not relying on prepatcher. This is a critical component, and your game will not work without it. If you are using Rimbody version 1.0.x, you should downgrade your stats module to 1.0.x by going to the mod's github page.");
            }
        }
    }
}
