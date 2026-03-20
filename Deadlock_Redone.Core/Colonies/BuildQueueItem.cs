using System;
using System.Collections.Generic;
using System.Text;

namespace Deadlock_Redone.Core.Colonies
{
    public sealed class BuildQueueItem
    {
        public string DefinitionId { get; set; } = string.Empty;
        public string DisplayName { get; set; } = string.Empty;

        public BuildQueueItemType ItemType { get; set; }

        public int Cost { get; set; }
        public int Progress { get; set; }
        public int MaintenanceCost { get; set; }

        public int Attack { get; set; }
        public int Defense { get; set; }
        public int MaxHitPoints { get; set; }
    }
}
