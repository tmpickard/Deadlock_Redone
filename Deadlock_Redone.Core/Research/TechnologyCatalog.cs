using System;
using System.Collections.Generic;
using System.Text;

namespace Deadlock_Redone.Core.Research
{
    public static class TechnologyCatalog
    {
        public static IReadOnlyDictionary<string, TechnologyDefinition> All { get; } = new Dictionary<string, TechnologyDefinition>(StringComparer.OrdinalIgnoreCase)
        {
            ["nuclear_fusion"] = new TechnologyDefinition
            {
                Id = "nuclear_fusion",
                DisplayName = "Nuclear Fusion",
                Description = "Unlocks the ability to build fusion plants.  Nuclear Reactors can now be upgraded to fusion plants",
                ResearchCost = 50,
                UnlockedBuildingsIds = new[] { "fusion_plant" },
                Tags = new[] { "energy" }
            },
            ["synthetic_fertilizer"] = new TechnologyDefinition
            {
                Id = "synthetic_fertilizer",
                DisplayName = "Synthetic Fertilizer",
                Description = "Unlocks the ability to build hydroponic farms.  Farms can now be upgraded to Hydroponic farms.",
                ResearchCost = 50,
                UnlockedBuildingsIds = new[] { "hydroponic_farm" },
                Tags = new[] { "food", "wood" }
            },
            ["electronics"] = new TechnologyDefinition
            {
                Id = "electronics",
                DisplayName = "Electronics",
                Description = "Electronics",
                ResearchCost = 50,
                Tags = new[] { "electronics" }
            },
            ["metallurgy"] = new TechnologyDefinition
            {
                Id = "metallurgy",
                DisplayName = "Metallurgy",
                Description = "Unlocks the ability to convert iron into steel at factories.",
                ResearchCost = 50,
                Tags = new[] { "metallurgy", "factory", "iron" },
            },
            ["molecular_bonding"] = new TechnologyDefinition
            {
                Id = "molecular_bonding",
                DisplayName = "Molecular Bonding",
                Description = "Unlocks the ability to mantle drills.  Surface mines can now be upgraded to mantle drills.",
                PrerequisiteTechnologyIds = new[] { "synthetic_fertilizer"},
                ResearchCost = 100,
                UnlockedBuildingsIds = new[] { "mantle_drill" },
                Tags = new[] { "iron", "endurium" }
            },
            ["surface-air_missiles"] = new TechnologyDefinition
            {
                Id = "surface-air_missiles",
                DisplayName = "Surface-Air Missiles",
                Description = "Unlocks the ability to mantle drills.  Surface mines can now be upgraded to mantle drills.",
                PrerequisiteTechnologyIds = new[] { "electronics" },
                ResearchCost = 100,
                UnlockedUnitIds = new[] { "sam_trooper" },
                Tags = new[] { "infantry", "military", "anti_air" }
            }
        };
    }
}
