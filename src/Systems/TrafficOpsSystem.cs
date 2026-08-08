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
            global::MessyCore.Mod.Capabilities.Set("traffic.directional-lights", global::MessyCore.Mod.Settings.EnableDirectionalLightManagement ? "enabled" : "disabled");
            global::MessyCore.Mod.Diagnostics.SetState("traffic.module", "ready");
            global::MessyCore.Mod.Diagnostics.SetState("traffic.directional-lights", global::MessyCore.Mod.Settings.EnableDirectionalLightManagement ? "ready" : "disabled");
        }

        protected override void OnUpdate()
        {
            if (!global::MessyCore.Mod.Settings.TrafficModuleEnabled)
            {
                global::MessyCore.Mod.Diagnostics.SetState("traffic.runtime", "disabled");
                return;
            }
            global::MessyCore.Mod.Capabilities.Set("traffic.runtime", "active");
            var state = global::MessyCore.Mod.Settings.EnableTrafficSignals ? "signals-active" : "active";
            if (global::MessyCore.Mod.Settings.EnableDirectionalLightManagement)
                state += "+directional";
            global::MessyCore.Mod.Diagnostics.SetState("traffic.runtime", state);
        }
    }
}
