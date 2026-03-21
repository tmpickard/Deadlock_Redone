using System;
using System.Collections.Generic;
using System.Text;

namespace Deadlock_Redone.Core.Resources
{
    public sealed class ResourceCost
    {
        public int Credits { get; init; }
        public int Food { get; init; }
        public int Wood { get; init; }

        // Costs ask for iron, but payment may use iron substitutes.
        public int Iron { get; init; }

        public int Energy { get; init; }
        public int AntiMatter { get; init; }
        public int Art { get; init; }
        public int Electronics { get; init; }
        public int Research { get; init; }
    }
}
