using System;
using System.Collections.Generic;
using System.Text;

namespace Deadlock_Redone.Core.Resources
{
    public class ResourceSet
    {
        public int Credits { get; set; }
        public int Food { get; set; }
        public int Wood { get; set; }
        public int Iron { get; set; }
        public int Steel { get; set; }
        public int Endurium { get; set; }
        public int Triitium { get; set; }
        public int Energy { get; set; }
        public int AntiMatter { get; set; }
        public int Art { get; set; }
        public int Electronics { get; set; }
        public int Research { get; set; }

        public int Get(ResourceType type)
        {
            return type switch
            {
                ResourceType.Credits => Credits,
                ResourceType.Food => Food,
                ResourceType.Wood => Wood,
                ResourceType.Iron => Iron,
                ResourceType.Steel => Steel,
                ResourceType.Endurium => Endurium,
                ResourceType.Triitium => Triitium,
                ResourceType.Energy => Energy,
                ResourceType.AntiMatter => AntiMatter,
                ResourceType.Art => Art,
                ResourceType.Electronics => Electronics,
                ResourceType.Research => Research,
                _ => 0
            };
        }

        public void Set(ResourceType type, int amount)
        {
            switch (type)
            {
                case ResourceType.Credits: Credits = amount; break;
                case ResourceType.Food: Food = amount; break;
                case ResourceType.Wood: Wood = amount; break;
                case ResourceType.Iron: Iron = amount; break;
                case ResourceType.Steel: Steel = amount; break;
                case ResourceType.Endurium: Endurium = amount; break;
                case ResourceType.Triitium: Triitium = amount; break;
                case ResourceType.Energy: Energy = amount; break;
                case ResourceType.AntiMatter: AntiMatter = amount; break;
                case ResourceType.Art: Art = amount; break;
                case ResourceType.Electronics: Electronics = amount; break;
                case ResourceType.Research: Research = amount; break;
            }
        }

        public void Add(ResourceSet other)
        {
            Credits += other.Credits;
            Food += other.Food;
            Wood += other.Wood;
            Iron += other.Iron;
            Steel += other.Steel;
            Endurium += other.Endurium;
            Triitium += other.Triitium;
            Energy += other.Energy;
            AntiMatter += other.AntiMatter;
            Art += other.Art;
            Electronics += other.Electronics;
            Research += other.Research;
        }

        public void Subtract(ResourceSet other)
        {
            Credits -= other.Credits;
            Food -= other.Food;
            Wood -= other.Wood;
            Iron -= other.Iron;
            Steel -= other.Steel;
            Endurium -= other.Endurium;
            Triitium -= other.Triitium;
            Energy -= other.Energy;
            AntiMatter -= other.AntiMatter;
            Art -= other.Art;
            Electronics -= other.Electronics;
            Research -= other.Research;
        }

        public ResourceSet Clone()
        {
            return new ResourceSet
            {
                Credits = Credits,
                Food = Food,
                Wood = Wood,
                Iron = Iron,
                Steel = Steel,
                Endurium = Endurium,
                Triitium = Triitium,
                Energy = Energy,
                AntiMatter = AntiMatter,
                Art = Art,
                Electronics = Electronics,
                Research = Research
            };
        }
    }
}
