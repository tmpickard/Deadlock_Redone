using Deadlock_Redone.Core.Buildings;
using Deadlock_Redone.Core.Units;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Text;

namespace Deadlock_Redone.Core.Colonies
{
    public sealed class Colony
    {
        public string Name { get; set; } = string.Empty;

        public int Population { get; set; }
        public int PopulationCapacity { get; set; }
        public int Morale { get; set; }

        public int TaxRate { get; set; }
        public int TradeValue { get; set; }

        public int FoodOutput { get; set; }
        public int OreOutput { get; set; }
        public int EnergyOutput { get; set; }
        public int ResearchOutput { get; set; }
        public int ProductionOutput { get; set; }

        public int BasePopulationGrowthRate { get; set; }

        public List<BuildingInstance> Buildings { get; set; } = new();
        public List<Unit> StationedUnits { get; set; } = new();
        public List<BuildQueueItem> BuildQueue { get; set; } = new();
    }
}
