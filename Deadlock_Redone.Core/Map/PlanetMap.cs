using System;
using System.Collections.Generic;
using System.Text;

namespace Deadlock_Redone.Core.Map
{
    public class PlanetMap
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public Tile[,] Tiles { get; set; } = default!;
    }
}
