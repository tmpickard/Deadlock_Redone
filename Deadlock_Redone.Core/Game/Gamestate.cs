using Deadlock_Redone.Core.Combat;
using Deadlock_Redone.Core.Factions;
using Deadlock_Redone.Core.Map;
using System;
using System.Collections.Generic;
using System.Text;

namespace Deadlock_Redone.Core.Game
{
    public sealed class GameState
    {
        public int TurnNumber { get; set; }

        public List<Faction> Factions { get; set; } = new();

        public List<GameEvent> PendingEvents { get; set; } = new();
        public List<GameEvent> EventLog { get; set; } = new();

        public List<PendingBattle> PendingBattles { get; set; } = new();
    }
}
