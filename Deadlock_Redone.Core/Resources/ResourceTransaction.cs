using System;
using System.Collections.Generic;
using System.Text;

namespace Deadlock_Redone.Core.Resources
{
    public sealed class ResourceTransaction
    {
        public string Source { get; init; } = string.Empty;
        public string Target { get; init; } = string.Empty;
        public ResourceSet Resources { get; init; } = new();
        public string Reason { get; init; } = string.Empty;
    }
}
