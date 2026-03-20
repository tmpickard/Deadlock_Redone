using Deadlock_Redone.Core.Buildings;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Deadlock_Redone.Core.Colonies
{
    public class Colony
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int FactionId { get; set; }
        public Point Location { get; set; }
        public int Population { get; set; }
        public int Morale { get; set; }
        public ColonyProduction Production { get; set; } = new();
        public List<BuildingInstance> Buildings { get; set; } = new();
        public BuildQueue BuildQueue { get; set; }
    }
}
