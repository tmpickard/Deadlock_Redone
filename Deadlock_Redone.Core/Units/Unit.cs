using System;
using System.Collections.Generic;
using System.Text;

namespace Deadlock_Redone.Core.Units
{
    public sealed class Unit
    {
        public string UnitId { get; set; } = string.Empty;
        public string DisplayName { get; set; } = string.Empty;

        public int Attack { get; set; }
        public int Defense { get; set; }

        public int CurrentHitPoints { get; set; }
        public int MaxHitPoints { get; set; }

        public int MaintenanceCost { get; set; }

        public int Readiness { get; set; } = 50;
        public int MaxReadiness { get; set; } = 100;
    }
}
