using Deadlock_Redone.Core.Colonies;
using Deadlock_Redone.Core.Research;
using Deadlock_Redone.Core.Units;
using System;
using System.Collections.Generic;
using System.Text;

namespace Deadlock_Redone.Core.Factions
{
    public sealed class Faction
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public RaceTemplate Race { get; set; } = default!;
        public ResearchState Research { get; set; } = new();

        public int Credits { get; set; }
        public int Food { get; set; }
        public int Ore { get; set; }
        public int Energy { get; set; }

        public List<Colony> Colonies { get; set; } = new();
        public List<Unit> Units { get; set; } = new();
    }
}
