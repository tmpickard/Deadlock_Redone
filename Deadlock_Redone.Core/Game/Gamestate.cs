using Deadlock_Redone.Core.Factions;
using Deadlock_Redone.Core.Map;
using System;
using System.Collections.Generic;
using System.Text;

namespace Deadlock_Redone.Core.Game
{
    public class GameState
    {
        public int TurnNumber { get; set; }
        public PlanetMap Map { get; set; } = new();
        public List<Faction> Factions { get; set; } = new();
        public List<Technology> Technologies { get; set; } = new();
        public List<GameEvent> PendingEvents { get; set; } = new();
    }
}
