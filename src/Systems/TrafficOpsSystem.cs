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
            global::MessyCore.Mod.Capabilities.Set("traffic.signals", global::MessyCore.Mod.Settings.EnableTrafficSignals ? "enabled" : "disabled");
            global::MessyCore.Mod.Diagnostics.SetState("traffic.module", "ready");
        }

        protected override void OnUpdate()
        {
            if (!global::MessyCore.Mod.Settings.TrafficModuleEnabled)
            {
                global::MessyCore.Mod.Diagnostics.SetState("traffic.runtime", "disabled");
                return;
            }
            global::MessyCore.Mod.Capabilities.Set("traffic.runtime", "active");
            global::MessyCore.Mod.Diagnostics.SetState("traffic.runtime", global::MessyCore.Mod.Settings.EnableTrafficSignals ? "signals-active" : "active");
        }
    }
}
