using Verse;

namespace Rimbody_StatModule
{
    public class Rimbody_StatModule : Mod
    {
        public Rimbody_StatModule(ModContentPack content) : base(content)
        {
            if (!ModsConfig.IsActive("Maux36.Rimbody"))
            {
                Log.Error("[Rimbody] Stats module could not find its required dependency: Rimbody. This is a critical component, and your game will not work without it.");
            }
        }
    }
}
