using System;
using System.Collections.Generic;
using System.Text;

namespace Deadlock_Redone.Core.Resources
{
    public static class ResourceCatalog
    {
        public static IReadOnlyDictionary<ResourceType, ResourceDefinition> All { get; } =
            new Dictionary<ResourceType, ResourceDefinition>
            {
                [ResourceType.Credits] = new ResourceDefinition
                {
                    Type = ResourceType.Credits,
                    Id = "credits",
                    DisplayName = "Credits",
                    Description = "Empire-wide currency used for trade, maintenance, and administration.",
                    IsSpecial = true
                },
                [ResourceType.Food] = new ResourceDefinition
                {
                    Type = ResourceType.Food,
                    Id = "food",
                    DisplayName = "Food",
                    Description = "Consumed by colonists each turn.",
                    IsRawMaterial = true
                },
                [ResourceType.Wood] = new ResourceDefinition
                {
                    Type = ResourceType.Wood,
                    Id = "wood",
                    DisplayName = "Wood",
                    Description = "Basic raw material used in construction and industry.",
                    IsRawMaterial = true
                },
                [ResourceType.Iron] = new ResourceDefinition
                {
                    Type = ResourceType.Iron,
                    Id = "iron",
                    DisplayName = "Iron",
                    Description = "Raw metal used in manufacturing.",
                    IsRawMaterial = true
                },
                [ResourceType.Steel] = new ResourceDefinition
                {
                    Type = ResourceType.Steel,
                    Id = "steel",
                    DisplayName = "Steel",
                    Description = "Refined metal used in heavy industry and military production.",
                    IsManufactured = true
                },
                [ResourceType.Endurium] = new ResourceDefinition
                {
                    Type = ResourceType.Endurium,
                    Id = "endurium",
                    DisplayName = "Endurium",
                    Description = "Advanced metal found in small deposits.  One ton of endurium has the same production value of 5 tons of iron.",
                    IsRawMaterial = true
                },
                [ResourceType.Triitium] = new ResourceDefinition
                {
                    Type = ResourceType.Triitium,
                    Id = "triitium",
                    DisplayName = "Triitium",
                    Description = "Refined metal created from endurium processing.  One ton of Triitium has the same yield as ten tons of iron.",
                    IsManufactured = true
                },
                [ResourceType.Energy] = new ResourceDefinition
                {
                    Type = ResourceType.Energy,
                    Id = "energy",
                    DisplayName = "Energy",
                    Description = "Power required to operate buildings and advanced systems.",
                    IsSpecial = true
                },
                [ResourceType.AntiMatter] = new ResourceDefinition
                {
                    Type = ResourceType.AntiMatter,
                    Id = "anti_matter",
                    DisplayName = "Anti-Matter",
                    Description = "Extremely advanced energy resource for elite technology and weapons.",
                    IsManufactured = true
                },
                [ResourceType.Art] = new ResourceDefinition
                {
                    Type = ResourceType.Art,
                    Id = "art",
                    DisplayName = "Art",
                    Description = "Luxury and cultural output that can improve morale and trade value.",
                    IsManufactured = true
                },
                [ResourceType.Electronics] = new ResourceDefinition
                {
                    Type = ResourceType.Electronics,
                    Id = "electronics",
                    DisplayName = "Electronics",
                    Description = "Advanced manufactured goods used in research, infrastructure, and military systems.",
                    IsManufactured = true
                },
                [ResourceType.Research] = new ResourceDefinition
                {
                    Type = ResourceType.Research,
                    Id = "research",
                    DisplayName = "Research",
                    Description = "Scientific progress used to unlock new technologies.",
                    IsSpecial = true,
                    IsStockpilable = false,
                    IsTradable = false
                }
            };

        public static ResourceDefinition Get(ResourceType type)
        {
            if (!All.TryGetValue(type, out var definition))
            {
                throw new KeyNotFoundException($"Resource definition for '{type}' was not found.");
            }

            return definition;
        }
    }
}
