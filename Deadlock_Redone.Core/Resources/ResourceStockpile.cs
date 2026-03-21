using System;
using System.Collections.Generic;
using System.Text;

namespace Deadlock_Redone.Core.Resources
{
    public sealed class ResourceStockpile : ResourceSet
    {
        public bool CanAffordExactNonIronCosts(ResourceCost cost)
        {
            ArgumentNullException.ThrowIfNull(cost);

            return Credits >= cost.Credits
                && Food >= cost.Food
                && Wood >= cost.Wood
                && Energy >= cost.Energy
                && AntiMatter >= cost.AntiMatter
                && Art >= cost.Art
                && Electronics >= cost.Electronics;
        }
    }
}
