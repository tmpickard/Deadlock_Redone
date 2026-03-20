using Deadlock_Redone.Core.Factions;
using Deadlock_Redone.Core.Game;
using Deadlock_Redone.Core.Units;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetaryConquest.Core.Turns;

public sealed class MilitaryPhaseProcessor
{
    public void ProcessFaction(GameState gameState, Faction faction)
    {
        if (faction is null)
        {
            throw new ArgumentNullException(nameof(faction));
        }

        foreach (var unit in faction.Units)
        {
            RestoreReadiness(unit);
            ApplySupplyChecks(unit, faction);
        }
    }

    private void RestoreReadiness(Unit unit)
    {
        unit.Readiness = Math.Min(unit.MaxReadiness, unit.Readiness + 10);
    }

    private void ApplySupplyChecks(Unit unit, Faction faction)
    {
        if (faction.Energy <= 0)
        {
            unit.Readiness = Math.Max(0, unit.Readiness - 15);
        }
    }
}
