using System;
using System.Collections.Generic;
using System.Text;

namespace Deadlock_Redone.Core.Resources
{
    public sealed class ResourceDefinition
    {
        public ResourceType Type { get; init; }

        public string Id { get; init; } = string.Empty;
        public string DisplayName { get; init; } = string.Empty;
        public string Description { get; init; } = string.Empty;

        public bool IsStockpilable { get; init; } = true;
        public bool IsTradable { get; init; } = true;
        public bool IsManufactured { get; init; }
        public bool IsRawMaterial { get; init; }
        public bool IsSpecial { get; init; }
    }
}
