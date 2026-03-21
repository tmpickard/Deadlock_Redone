using System;
using System.Collections.Generic;
using System.Text;

namespace Deadlock_Redone.Core.Resources
{
    public sealed class MaterialPaymentResult
    {
        public bool Success { get; init; }

        public int IronPaid { get; init; }
        public int SteelPaid { get; init; }
        public int EnduriumPaid { get; init; }
        public int TriitiumPaid { get; init; }

        public int RequestedIronEquivalent { get; init; }
        public int PaidIronEquivalent { get; init; }
        public int OverpaymentIronEquivalent { get; init; }

        public static MaterialPaymentResult Failed(int requestedIronEquivalent) => new()
        {
            Success = false,
            RequestedIronEquivalent = requestedIronEquivalent
        };
    }
}
