using System;
using System.Collections.Generic;
using System.Text;

namespace Deadlock_Redone.Core.Factions
{
    public static class RaceCatalog
    {
        public static IReadOnlyDictionary<string, RaceTemplate> All { get; } = new Dictionary<string, RaceTemplate>(StringComparer.OrdinalIgnoreCase)
        {
            ["human"] = new RaceTemplate
            {
                Id = "human",
                DisplayName = "Human",
                Description = "Economic specialists with strong tax and trade income, cheaper transort, and infantry that can go berserk in battle.",
                TaxIncomeMultiplier = 1.20,
                TradeIncomeMultiplier = 1.20,
                TransportCostMultiplier = 0.70,
                InfantryHasBerserkOrder = true,
                ScandalVulnerabilityMultiplier = 1.35
            },
            ["protogen"] = new RaceTemplate
            {
                Id = "protogen",
                DisplayName = "Protogen",
                Description = "Brilliant and eccentric scientists with fast research, sabotage-capable scouts, and strong counterintelligence.",
                ResearchMultiplier = 1.30,
                MoraleDecayMultiplier = 1.30,
                ScoutCanSabotage = true,
                UnitsCatchSpiesBetter = true
            },
            ["kitsune"] = new RaceTemplate
            {
                Id = "kitsune",
                DisplayName = "Kitsune",
                Description = "Ethereal tricksters and schemers who can see the entire planet, subvert enemy morale, and temporarily control enemy units in battle.",
                CanSeeEntirePlanet = true,
                ScoutCanSubvertMorale = true,
                CommandCanMindControl = true,
                ArtilleryWeaknessMultiplier = 0.80,
            },
            ["dragon"] = new RaceTemplate
            {
                Id = "dragon",
                DisplayName = "Dragon",
                Description = "Brutal military powerhouses with stronger infantry, artillery, and fortifications, plus highly productive farms.",
                InfantryAttackMultiplier = 1.20,
                InfantryDefenseMultiplier = 1.15,
                ArtilleryAttackMultiplier = 1.20,
                FortificationAttackMultiplier = 1.15,
                FortificationDefenseMultiplier = 1.20,
                FoodProductionMultiplier = 1.20,
                InfantryHasJuggernautOrder = true,
                ScoutsArePoorSpies = true,
                ShipAttackMultiplier = 0.80,
                ShipDefenseMultiplier = 0.75
            },
            ["avali"] = new RaceTemplate
            {
                Id = "avali",
                DisplayName = "Avali",
                Description = "Engineering based avian creatures with superior natural resource production, territory bonuses, infantry spying, and lower taxes.",
                NaturalResourceProductionMultiplier = 1.25,
                TaxRateMultiplier = 0.85,
                InfantryCanSpy = true,
                CommandCanShamanDance = true,
            }
        };
    }
}
