using System;
using System.Collections.Generic;
using System.Text;

namespace Deadlock_Redone.Core.Resources
{
    public static class ResourcePaymentRules
    {
        public static bool CanAfford(ResourceStockpile stockpile, ResourceCost cost)
        {
            ArgumentNullException.ThrowIfNull(stockpile);
            ArgumentNullException.ThrowIfNull(cost);

            if (!stockpile.CanAffordExactNonIronCosts(cost))
            {
                return false;
            }

            return MaterialSubstitutionRules.CanPayIronCost(stockpile, cost.Iron);
        }

        public static ResourcePaymentResult Pay(
            ResourceStockpile stockpile,
            ResourceCost cost,
            MaterialPaymentPriority priority = MaterialPaymentPriority.PreserveRareMaterials)
        {
            ArgumentNullException.ThrowIfNull(stockpile);
            ArgumentNullException.ThrowIfNull(cost);

            if (!CanAfford(stockpile, cost))
            {
                return ResourcePaymentResult.Failed();
            }

            stockpile.Credits -= cost.Credits;
            stockpile.Food -= cost.Food;
            stockpile.Wood -= cost.Wood;
            stockpile.Energy -= cost.Energy;
            stockpile.AntiMatter -= cost.AntiMatter;
            stockpile.Art -= cost.Art;
            stockpile.Electronics -= cost.Electronics;

            MaterialPaymentResult? ironPayment = null;

            if (cost.Iron > 0)
            {
                ironPayment = MaterialSubstitutionRules.PayIronCost(
                    stockpile,
                    cost.Iron,
                    priority);

                if (!ironPayment.Success)
                {
                    throw new InvalidOperationException(
                        "Iron payment failed after affordability check passed.");
                }
            }

            return ResourcePaymentResult.Succeeded(ironPayment);
        }
    }
}
