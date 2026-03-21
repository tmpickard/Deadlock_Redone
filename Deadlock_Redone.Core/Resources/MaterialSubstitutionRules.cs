using System;
using System.Collections.Generic;
using System.Text;

namespace Deadlock_Redone.Core.Resources
{
    public static class MaterialSubstitutionRules
    {
        public static int GetIronValue(ResourceType resourceType)
        {
            return resourceType switch
            {
                ResourceType.Iron => 1,
                ResourceType.Steel => 5,
                ResourceType.Endurium => 5,
                ResourceType.Triitium => 10,
                _ => 0
            };
        }

        public static bool CanSubstituteForIron(ResourceType resourceType)
        {
            return resourceType is ResourceType.Iron
                or ResourceType.Steel
                or ResourceType.Endurium
                or ResourceType.Triitium;
        }

        public static int GetTotalAvailableIronValue(ResourceStockpile stockpile)
        {
            ArgumentNullException.ThrowIfNull(stockpile);

            return stockpile.Iron
                 + (stockpile.Steel * 5)
                 + (stockpile.Endurium * 5)
                 + (stockpile.Triitium * 10);
        }

        public static bool CanPayIronCost(ResourceStockpile stockpile, int ironCost)
        {
            ArgumentNullException.ThrowIfNull(stockpile);

            if (ironCost < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(ironCost));
            }

            return GetTotalAvailableIronValue(stockpile) >= ironCost;
        }

        public static MaterialPaymentResult PayIronCost(
            ResourceStockpile stockpile,
            int ironCost,
            MaterialPaymentPriority priority = MaterialPaymentPriority.PreserveRareMaterials)
        {
            ArgumentNullException.ThrowIfNull(stockpile);

            if (ironCost < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(ironCost));
            }

            if (!CanPayIronCost(stockpile, ironCost))
            {
                return MaterialPaymentResult.Failed(ironCost);
            }

            int remaining = ironCost;

            int ironPaid = 0;
            int steelPaid = 0;
            int enduriumPaid = 0;
            int triitiumPaid = 0;

            foreach (ResourceType resourceType in GetPaymentOrder(priority))
            {
                if (remaining <= 0)
                {
                    break;
                }

                int availableUnits = stockpile.Get(resourceType);
                int valuePerUnit = GetIronValue(resourceType);

                if (availableUnits <= 0)
                {
                    continue;
                }

                int unitsNeeded = (int)Math.Ceiling(remaining / (double)valuePerUnit);
                int unitsToUse = Math.Min(availableUnits, unitsNeeded);

                if (unitsToUse <= 0)
                {
                    continue;
                }

                stockpile.Set(resourceType, availableUnits - unitsToUse);

                int valuePaid = unitsToUse * valuePerUnit;
                remaining -= valuePaid;

                switch (resourceType)
                {
                    case ResourceType.Iron:
                        ironPaid += unitsToUse;
                        break;
                    case ResourceType.Steel:
                        steelPaid += unitsToUse;
                        break;
                    case ResourceType.Endurium:
                        enduriumPaid += unitsToUse;
                        break;
                    case ResourceType.Triitium:
                        triitiumPaid += unitsToUse;
                        break;
                }
            }

            int totalPaid = ironPaid + (steelPaid * 5) + (enduriumPaid * 5) + (triitiumPaid * 10);

            return new MaterialPaymentResult
            {
                Success = true,
                IronPaid = ironPaid,
                SteelPaid = steelPaid,
                EnduriumPaid = enduriumPaid,
                TriitiumPaid = triitiumPaid,
                RequestedIronEquivalent = ironCost,
                PaidIronEquivalent = totalPaid,
                OverpaymentIronEquivalent = Math.Max(0, totalPaid - ironCost)
            };
        }

        private static IReadOnlyList<ResourceType> GetPaymentOrder(MaterialPaymentPriority priority)
        {
            return priority switch
            {
                MaterialPaymentPriority.UseMostEfficientFirst => new[]
                {
                ResourceType.Triitium,
                ResourceType.Steel,
                ResourceType.Endurium,
                ResourceType.Iron
            },
                _ => new[]
                {
                ResourceType.Iron,
                ResourceType.Steel,
                ResourceType.Endurium,
                ResourceType.Triitium
            }
            };
        }
    }
}
