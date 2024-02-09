using LogicAPI.Server;

namespace YOUR_NAME_OR_ALIAS_WITHOUT_SPACES_LwExampleMod.Server
{
    public class Loader : ServerMod
    {
        protected override void Initialize()
        {
            this.Logger.Info("Example mod initialized!");
            // useful for extra, per-mod setup stuff (this is called right after the mod was loaded)
        }
    }
}
