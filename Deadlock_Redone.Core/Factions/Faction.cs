using Deadlock_Redone.Core.Research;
using System;
using System.Collections.Generic;
using System.Text;

namespace Deadlock_Redone.Core.Factions
{
    public class Faction
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public RaceTemplate Race { get; set; } = default!;
        public ResourceStockpile Stockpile { get; set; } = new();
        public ResearchState Research { get; set; } = new();
        public DiplomacyState Diplomacy { get; set; } = new();
        public List<int> ColonyIds { get; set; } = new();
    }
}
