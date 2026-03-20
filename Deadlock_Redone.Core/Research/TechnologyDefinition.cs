using System;
using System.Collections.Generic;
using System.Text;

namespace Deadlock_Redone.Core.Research
{
    public class TechnologyDefinition
    {
        public string Id { get; init; } = string.Empty;
        public string DisplayName { get; init; } = string.Empty;
        public string Description { get; init; } = string.Empty;
        public int ResearchCost { get; init; }
        public IReadOnlyList<string> PrerequisiteTechnologyIds { get; init; } = Array.Empty<string>();
        public IReadOnlyList<string> UnlockedBuildingsIds { get; init; } = Array.Empty<string>();
        public IReadOnlyList<string> UnlockedUnitIds { get; init; } = Array.Empty<string>();
        public IReadOnlyList<string> UnlockedImprovementIds { get; init; } = Array.Empty<string>();
        public IReadOnlyList<string> Tags { get; init; } = Array.Empty<string>();
    }
}
