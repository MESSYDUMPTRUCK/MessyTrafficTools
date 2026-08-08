using Game;
using MessyCore;

namespace MessyTrafficTools.Systems
{
    public partial class TrafficOpsSystem : GameSystemBase
    {
        protected override void OnCreate()
        {
            base.OnCreate();
            global::MessyCore.Mod.Log.Info("TrafficOpsSystem ready");
            global::MessyCore.Mod.Capabilities.Set("traffic.module", "ready");
            global::MessyCore.Mod.Capabilities.Set("traffic.warnings", global::MessyCore.Mod.Settings.UseTrafficWarnings ? "enabled" : "disabled");
        }

        protected override void OnUpdate()
        {
            if (!global::MessyCore.Mod.Settings.TrafficModuleEnabled) return;
            global::MessyCore.Mod.Capabilities.Set("traffic.runtime", "active");
        }
    }
}

