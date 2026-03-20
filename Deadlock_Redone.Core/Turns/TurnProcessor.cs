using Deadlock_Redone.Core.Game;
using System;
using System.Collections.Generic;
using System.Text;

namespace Deadlock_Redone.Core.Turns
{
    public class TurnProcessor
    {
        public void ProcessTurn(GameState state)
        {
            foreach (var faction in state.Factions)
            {
                ProcessFactionEconomy(state, faction);
                ProcessFactionResearch(state, faction);
                ProcessFactionColonies(state, faction);
                ProcessFactionMilitary(state, faction);
            }

            ResolveConflicts(state);
            TriggerEvents(state);
            state.TurnNumber++;
        }
    }
}
