using System;
using System.Collections.Generic;
using System.Text;

namespace Deadlock_Redone.Core.Resources
{
    public static class ResourceRules
    {
        public static ResourceSet CalculateNet(ResourceYield produced, ResourceCost consumed)
        {
            ArgumentNullException.ThrowIfNull(produced);
            ArgumentNullException.ThrowIfNull(consumed);

            return new ResourceSet
            {
                Credits = produced.Credits - consumed.Credits,
                Food = produced.Food - consumed.Food,
                Wood = produced.Wood - consumed.Wood,
                Iron = produced.Iron - consumed.Iron,
                Steel = produced.Steel - consumed.Steel,
                Endurium = produced.Endurium - consumed.Endurium,
                Triitium = produced.Triitium - consumed.Triitium,
                Energy = produced.Energy - consumed.Energy,
                AntiMatter = produced.AntiMatter - consumed.AntiMatter,
                Art = produced.Art - consumed.Art,
                Electronics = produced.Electronics - consumed.Electronics,
                Research = produced.Research
            };
        }

        public static void ClampNonStockpilableValues(ResourceSet resources)
        {
            ArgumentNullException.ThrowIfNull(resources);

            if (resources.Research < 0)
            {
                resources.Research = 0;
            }
        }

        public static bool HasAnyNegativeStockpile(ResourceStockpile stockpile)
        {
            ArgumentNullException.ThrowIfNull(stockpile);

            return stockpile.Credits < 0
                || stockpile.Food < 0
                || stockpile.Wood < 0
                || stockpile.Iron < 0
                || stockpile.Steel < 0
                || stockpile.Endurium < 0
                || stockpile.Triitium < 0
                || stockpile.Energy < 0
                || stockpile.AntiMatter < 0
                || stockpile.Art < 0
                || stockpile.Electronics < 0;
        }
    }
}
