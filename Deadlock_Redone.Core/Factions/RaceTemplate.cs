using System;
using System.Collections.Generic;
using System.Text;

namespace Deadlock_Redone.Core.Factions
{
    public sealed class RaceTemplate
    {
        public string Id { get; init; } = string.Empty;
        public string DisplayName { get; init; } = string.Empty;
        public string Description { get; init; } = string.Empty;

        // Economy / colony simulation
        public double PopulationGrowthMultiplier { get; init; } = 1.0;
        public double MoraleStabilityMultiplier { get; init; } = 1.0;
        public double MoraleDecayMultiplier { get; init; } = 1.0;
        public double TaxIncomeMultiplier { get; init; } = 1.0;
        public double TaxSensitivityMultiplier { get; init; } = 1.0;
        public double TaxRateMultiplier { get; init; } = 1.0;
        public double TradeIncomeMultiplier { get; init; } = 1.0;
        public double TransportCostMultiplier { get; init; } = 1.0;
        public double NaturalResourceProductionMultiplier { get; init; } = 1.0;
        public double FoodProductionMultiplier { get; init; } = 1.0;
        public double ResearchMultiplier { get; init; } = 1.0;

        // Production / military
        public double UnitProductionMultiplier { get; init; } = 1.0;
        public double UnitAttackMultiplier { get; init; } = 1.0;
        public double UnitDefenseMultiplier { get; init; } = 1.0;
        public double InfantryAttackMultiplier { get; init; } = 1.0;
        public double InfantryDefenseMultiplier { get; init; } = 1.0;
        public double ArtilleryAttackMultiplier { get; init; } = 1.0;
        public double ArtilleryDefenseMultiplier { get; init; } = 1.0;
        public double FortificationAttackMultiplier { get; init; } = 1.0;
        public double FortificationDefenseMultiplier { get; init; } = 1.0;
        public double ShipAttackMultiplier { get; init; } = 1.0;
        public double ShipDefenseMultiplier { get; init; } = 1.0;
        public double ArtilleryWeaknessMultiplier { get; init; } = 1.0;
        public double CombatMoveSpeedMultiplier { get; init; } = 1.0;

        // Colony caps / penalties
        public int MaxPopulationPerTerritory { get; init; } = 10_000;
        public double OverpopulationToleranceMultiplier { get; init; } = 1.0;
        public double ScandalVulnerabilityMultiplier { get; init; } = 1.0;

        // Special abilities
        public bool CanSeeEntirePlanet { get; init; }
        public bool InfantryCanSpy { get; init; }
        public bool InfantryHasBerserkOrder { get; init; }
        public bool InfantryHasJuggernautOrder { get; init; }
        public bool CommandCanMindBlast { get; init; }
        public bool CommandCanMindControl { get; init; }
        public bool CommandCanShamanDance { get; init; }
        public bool ScoutCanStealResources { get; init; }
        public bool ScoutCanPoisonLand { get; init; }
        public bool ScoutCanSabotage { get; init; }
        public bool ScoutCanSubvertMorale { get; init; }
        public bool UnitsCatchSpiesBetter { get; init; }
        public bool ScoutsArePoorSpies { get; init; }
    }
}
