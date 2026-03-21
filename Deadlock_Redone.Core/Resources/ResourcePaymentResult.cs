using System;
using System.Collections.Generic;
using System.Text;

namespace Deadlock_Redone.Core.Resources
{
    public sealed class ResourcePaymentResult
    {
        public bool Success { get; init; }
        public MaterialPaymentResult? IronPayment { get; init; }

        public static ResourcePaymentResult Failed() => new()
        {
            Success = false
        };

        public static ResourcePaymentResult Succeeded(MaterialPaymentResult? ironPayment) => new()
        {
            Success = true,
            IronPayment = ironPayment
        };
    }
}
