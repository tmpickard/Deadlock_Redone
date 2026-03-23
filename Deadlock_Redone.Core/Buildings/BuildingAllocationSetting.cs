using System;
using System.Collections.Generic;
using System.Text;

namespace Deadlock_Redone.Core.Buildings
{

    public sealed class BuildingAllocationSetting
    {
        public string OutputId { get; set; } = string.Empty;

        // Slider weight (not actual workers)
        public decimal Weight { get; set; }
    }
}
