using System;
using System.Collections.Generic;
using System.Text;

namespace Deadlock_Redone.Core.Resources
{
    public sealed class ResourceFlowReport
    {
        public ResourceYield Produced { get; init; } = new();
        public ResourceCost Consumed { get; init; } = new();
        public ResourceSet NetChange { get; init; } = new();

        public List<string> Notes { get; init; } = new();
    }
}
