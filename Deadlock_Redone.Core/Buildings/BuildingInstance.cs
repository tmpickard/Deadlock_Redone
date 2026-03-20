using System;
using System.Collections.Generic;
using System.Text;

namespace Deadlock_Redone.Core.Buildings
{
    public sealed class BuildingInstance
    {
        public string BuildingId { get; set; } = string.Empty;
        public int MaintenanceCost { get; set; }
        public bool IsOnline { get; set; }
    }
}
