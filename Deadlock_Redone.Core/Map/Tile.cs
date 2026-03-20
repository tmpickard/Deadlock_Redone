using Deadlock_Redone.Core.Colonies;
using System;
using System.Collections.Generic;
using System.Text;

namespace Deadlock_Redone.Core.Map
{
    public class Tile
    {
        public TerrainType Terrain { get; set; }
        public int? OwnerFactionId { get; set; }
        public Colony? Colony { get; set; }
        public List<MapImprovement> Improvements { get; set; } = new();
        public ResourceYield BaseYield { get; set; } = new();
    }
}
