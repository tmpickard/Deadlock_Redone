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
                PrerequisiteTechnologyIds = new[] { "synthetic_fertilizer" },
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
            },
            ["advanced_cloaking"] = new TechnologyDefinition
            {
                Id = "advanced_cloaking",
                DisplayName = "Advanced Cloaking",
                Description = "Grants the Cloak Mission for colonizers, infantry, and sea units.",
                PrerequisiteTechnologyIds = new[] { "cloaking" },
                ResearchCost = 2000,
                UnlockedBuildingsIds = new[] { "cloaking_generator" },
                Tags = new[] { "unit enhancement", "stealth" }
            },
            ["anti-matter_beam"] = new TechnologyDefinition
            {
                Id = "anti-matter_beam",
                DisplayName = "Anti-Matter Beam",
                Description = "Grants access to holodomor cannon and supernova warheads.",
                PrerequisiteTechnologyIds = new[] { "disruptor_beam" },
                ResearchCost = 2000,
                UnlockedUnitIds = new[] { "holodomor_cannon", "supernova_warhead" },
                Tags = new[] { "military", "artillery" }
            },
            ["anti-matter_containment"] = new TechnologyDefinition
            {
                Id = "anti-matter_containment",
                DisplayName = "Anti-Matter Containment",
                Description = "This research is required for the construction of anti-matter plants and the development of anti-matter pods.",
                PrerequisiteTechnologyIds = new[] { "fusion_cannon", "molecular_bonding" },
                ResearchCost = 250,
                UnlockedBuildingsIds = new[] { "anti_matter_plant" },
                Tags = new[] { "energy", "anti-matter", "resources" }
            },
            ["anti-matter_deflectors"] = new TechnologyDefinition
            {
                Id = "anti-matter_deflectors",
                DisplayName = "Anti-Matter Deflectors",
                Description = "This research is required for the construction of Anti-Matter Defense fortifications.",
                PrerequisiteTechnologyIds = new[] { "orbital_surveillance" },
                ResearchCost = 1000,
                UnlockedUnitIds = new[] { "anti_matter_pod" },
                Tags = new[] { "military", "anti-matter", "fortification" }
            },
            ["anti-matter_rifles"] = new TechnologyDefinition
            {
                Id = "anti-matter_rifles",
                DisplayName = "Anti-Matter Rifles",
                Description = "This research is required for the development of anti-matter rifles for infantry units.",
                PrerequisiteTechnologyIds = new[] { "anti-matter_containment" },
                ResearchCost = 500,
                UnlockedUnitIds = new[] { "battle_trooper" },
                Tags = new[] { "military", "anti-matter", "infantry" }
            },
            ["artificial_intelligence"] = new TechnologyDefinition
            {
                Id = "artificial_intelligence",
                DisplayName = "Artificial Intelligence",
                Description = "This research is required for the construction of robotics factories.",
                ResearchCost = 250,
                UnlockedBuildingsIds = new[] { "robotics_factory" },
                Tags = new[] { "factory", "resources", "production" }
            },
            ["assault_armor"] = new TechnologyDefinition
            {
                Id = "assault_armor",
                DisplayName = "Assault Armor",
                Description = "This research is required for the production of assault trooper units.",
                PrerequisiteTechnologyIds = new[] { "cortex_scanner" },
                ResearchCost = 1000,
                UnlockedUnitIds = new[] { "assault_trooper" },
                Tags = new[] { "military", "infantry", }
            },
            ["automation"] = new TechnologyDefinition
            {
                Id = "automation",
                DisplayName = "Automation",
                Description = "This research is required for the construction of automated factories.",
                PrerequisiteTechnologyIds = new[] { "metallurgy" },
                ResearchCost = 100,
                UnlockedBuildingsIds = new[] { "automated_factory" },
                Tags = new[] { "factory", "production" }
            },
            ["chaos_computers"] = new TechnologyDefinition
            {
                Id = "chaos_computers",
                DisplayName = "Chaos Computers",
                Description = "This research is required for the construction of tech labs.",
                PrerequisiteTechnologyIds = new[] { "artificial_intelligence" },
                ResearchCost = 1000,
                UnlockedBuildingsIds = new[] { "chaos_computer" },
                Tags = new[] { "factory", "production", "research" }
            },
            ["cloaking"] = new TechnologyDefinition
            {
                Id = "cloaking",
                DisplayName = "Cloaking",
                Description = "Grants the Cloak Mission for colonizers, infantry, and sea units.",
                PrerequisiteTechnologyIds = new[] { "cortex_scanner" },
                ResearchCost = 1000,
                UnlockedUnitIds = new[] { "supernova_spyjet" },
                Tags = new[] { "air craft" }
            },
            ["cortex_scanner"] = new TechnologyDefinition
            {
                Id = "cortex_scanner",
                DisplayName = "Cortex Scanner",
                Description = "This research is required for the construction of collective tech labs.",
                ResearchCost = 500,
                UnlockedBuildingsIds = new[] { "collective_tech_lab" },
                Tags = new[] { "electronics", "production", "research" }
            },
            ["disruptor_beam"] = new TechnologyDefinition
            {
                Id = "disruptor_beam",
                DisplayName = "Disruptor Beam",
                Description = "Grants access to disruptor beam artillery units.",
                PrerequisiteTechnologyIds = new[] { "anti-matter_rifles" },
                ResearchCost = 1000,
                UnlockedUnitIds = new[] { "disruptor_cannon" },
                Tags = new[] { "military", "artillery" }
            },
            ["electronics"] = new TechnologyDefinition
            {
                Id = "electronics",
                DisplayName = "Electronics",
                Description = "This research is required for the production of electronics components at universities and tech labs.",
                ResearchCost = 50,
                Tags = new[] { "resources", "production", "research" }
            },
            ["fusion_cannon"] = new TechnologyDefinition
            {
                Id = "fusion_cannon",
                DisplayName = "Fusion Cannon",
                Description = "Grants access to fusion cannon artillery units.",
                PrerequisiteTechnologyIds = new[] { "nuclear_fusion" },
                ResearchCost = 100,
                UnlockedUnitIds = new[] { "fusion_cannon" },
                Tags = new[] { "military", "artillery" }
            },
            ["endurium_mining"] = new TechnologyDefinition
            {
                Id = "endurium_mining",
                DisplayName = "Endurium Mining",
                Description = "This research is required for surface mines, mantle drills, and sub-space magnets to mine endurium",
                PrerequisiteTechnologyIds = new[] { "molecular_bonding", "fusion_cannon" },
                ResearchCost = 250,
                Tags = new[] { "resources" }
            },
            ["energy_deflectors"] = new TechnologyDefinition
            {
                Id = "energy_deflectors",
                DisplayName = "Energy Deflectors",
                Description = "This research is required for the construction of energy defense fortifications.",
                PrerequisiteTechnologyIds = new[] { "fusion_cannon" },
                ResearchCost = 1000,
                UnlockedUnitIds = new[] { "energy_deflector" },
                Tags = new[] { "military", "fortification" }
            },
            ["food_replication"] = new TechnologyDefinition
            {
                Id = "food_replication",
                DisplayName = "Food Replication",
                Description = "This research is required for the construction of food replicators.",
                PrerequisiteTechnologyIds = new[] { "triidium_processing" },
                ResearchCost = 250,
                UnlockedBuildingsIds = new[] { "food_replicator" },
                Tags = new[] { "food", "production" }
            },
            ["hoverway"] = new TechnologyDefinition
            {
                Id = "hoverway",
                DisplayName = "Hoverway",
                Description = "This research grants a discount on transportation costs.",
                PrerequisiteTechnologyIds = new[] { "metallurgy" },
                ResearchCost = 100,
                Tags = new[] { "infrastructure" }
            },
            ["ion_weapons"] = new TechnologyDefinition
            {
                Id = "ion_weapons",
                DisplayName = "Ion Weapons",
                Description = "Grants access to shockwave varrier battleships and groundbreaker warheads.",
                PrerequisiteTechnologyIds = new[] { "anti-matter_containment" },
                ResearchCost = 500,
                UnlockedUnitIds = new[] { "ion_cannon" },
                Tags = new[] { "military", "missiles", "navy" }
            },
            ["metal_replication"] = new TechnologyDefinition
            {
                Id = "metal_replication",
                DisplayName = "Metal Replication",
                Description = "This research is required for the construction of replication stations.",
                PrerequisiteTechnologyIds = new[] { "chaos_computers", "automation" },
                ResearchCost = 500,
                UnlockedBuildingsIds = new[] { "replication_station" },
                Tags = new[] { "resources", "production", "factory" }
            },
            ["neutrionic_fuel"] = new TechnologyDefinition
            {
                Id = "neutrionic_fuel",
                DisplayName = "Neutrionic Fuel",
                Description = "This research is required for the construction of military airbases, and fuel depots.",
                PrerequisiteTechnologyIds = new[] { "rocketry" },
                ResearchCost = 250,
                UnlockedBuildingsIds = new[] { "military_airbase" },
                Tags = new[] { "infrastructure", "military", "aircraft" }
            },
            ["orbital_surveillance"] = new TechnologyDefinition
            {
                Id = "orbital_surveillance",
                DisplayName = "Orbital Surveillance",
                Description = "This research is required for the construction of orbital surveillance centers.",
                PrerequisiteTechnologyIds = new[] { "cortex_scanner" },
                ResearchCost = 500,
                UnlockedBuildingsIds = new[] { "anti-colony_assault_silo" },
                Tags = new[] { "infrastructure" }
            },
            ["rocketry"] = new TechnologyDefinition
            {
                Id = "rocketry",
                DisplayName = "Rocketry",
                Description = "This research is required for the construction of missile bases and scatterpack warheads.",
                PrerequisiteTechnologyIds = new[] { "electronics" },
                ResearchCost = 100,
                UnlockedBuildingsIds = new[] { "missile_base" },
                Tags = new[] { "infrastructure", "military", "missiles" }
            },
            ["shockwave_projector"] = new TechnologyDefinition
            {
                Id = "shockwave_projector",
                DisplayName = "Shockwave Projector",
                Description = "Grants access to shockwave dreadnoughts, and hydroports.",
                PrerequisiteTechnologyIds = new[] { "nuclear_fusion" },
                ResearchCost = 100,
                UnlockedBuildingsIds = new[] { "hydroport" },
                UnlockedUnitIds = new[] { "shockwave_dreadnought" },
                Tags = new[] { "military", "navy" }
            },
            ["starflare_bombs"] = new TechnologyDefinition
            {
                Id = "starflare_bombs",
                DisplayName = "Starflare Bombs",
                Description = "Grants access to starflare bombers.",
                PrerequisiteTechnologyIds = new[] { "rocketry" },
                ResearchCost = 250,
                UnlockedUnitIds = new[] { "starflare_bomb" },
                Tags = new[] { "military", "air craft" }
            },
            ["sub-space_scanner"] = new TechnologyDefinition
            {
                Id = "sub-space_scanner",
                DisplayName = "Sub-Space Scanner",
                Description = "This research is required for the construction of sub-space magnets.",
                PrerequisiteTechnologyIds = new[] { "cortex_scanner" },
                ResearchCost = 1000,
                UnlockedBuildingsIds = new[] { "sub_space_magnet" },
                Tags = new[] { "resources" }
            },
            ["time_dilation"] = new TechnologyDefinition
            {
                Id = "time_dilation",
                DisplayName = "Time Dilation",
                Description = "This research grants a massive boost to resource production for every settlement controlled.",
                PrerequisiteTechnologyIds = new[] { "transporters", "metal_replication", "food_replication" },
                ResearchCost = 5000,
                Tags = new[] { "resources" }
            },
            ["transporter"] = new TechnologyDefinition
            {
                Id = "transporter",
                DisplayName = "Transporter",
                Description = "This research allows for the transportation of resources between settlements at no cost.  Also increases unit movement per turn.",
                PrerequisiteTechnologyIds = new[] { "anti-matter_beam", "advanced_cloaking" },
                ResearchCost = 5000,
                Tags = new[] { "infrastructure", "unit enhancement" }
            },
            ["triidium_processing"] = new TechnologyDefinition
            {
                Id = "triidium_processing",
                DisplayName = "Triidium Processing",
                Description = "This research is required for the refinement of endurium to triidium in factories.",
                PrerequisiteTechnologyIds = new[] { "endurium_mining" },
                ResearchCost = 500,
                Tags = new[] { "resources", "production" }
            },
            ["uncloaking"] = new TechnologyDefinition
            {
                Id = "uncloaking",
                DisplayName = "Uncloaking",
                Description = "Grants the Uncloak Mission for command corps.",
                PrerequisiteTechnologyIds = new[] { "cloaking" },
                ResearchCost = 2000,
                UnlockedUnitIds = new[] { "uncloak_trooper" },
                Tags = new[] { "unit enhancement", "stealth" }
            }
        };
    }
}
