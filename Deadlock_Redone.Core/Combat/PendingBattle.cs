using Deadlock_Redone.Core.Factions;
using Deadlock_Redone.Core.Units;
using System;
using System.Collections.Generic;
using System.Text;

namespace Deadlock_Redone.Core.Combat
{
    public sealed class PendingBattle
    {
        public Faction AttackerFaction { get; set; } = default!;
        public Faction DefenderFaction { get; set; } = default!;
        public List<Unit> AttackingUnits { get; set; } = new();
        public List<Unit> DefendingUnits { get; set; } = new();
        public string LocationName { get; set; } = string.Empty;
    }
}
