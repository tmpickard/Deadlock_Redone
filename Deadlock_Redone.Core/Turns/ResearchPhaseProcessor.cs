using Deadlock_Redone.Core.Game;
using Deadlock_Redone.Core.Factions;
using Deadlock_Redone.Core.Research;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetaryConquest.Core.Turns;

public sealed class ResearchPhaseProcessor
{
    private readonly IReadOnlyDictionary<string, TechnologyDefinition> _technologyCatalog;

    public ResearchPhaseProcessor(
        IReadOnlyDictionary<string, TechnologyDefinition> technologyCatalog)
    {
        _technologyCatalog = technologyCatalog
            ?? throw new ArgumentNullException(nameof(technologyCatalog));
    }

    public void ProcessFaction(GameState gameState, Faction faction)
    {
        if (gameState is null)
        {
            throw new ArgumentNullException(nameof(gameState));
        }

        if (faction is null)
        {
            throw new ArgumentNullException(nameof(faction));
        }

        int totalResearchOutput = CalculateFactionResearchOutput(faction);

        ResearchTurnResult result = ResearchRules.ProcessResearchTurn(
            faction.Research,
            faction,
            _technologyCatalog,
            totalResearchOutput);

        if (result.CompletedTechnology)
        {
            gameState.PendingEvents.Add(new GameEvent
            {
                Title = "Research Completed",
                Description = $"{faction.Name} completed research: {result.TechnologyName}."
            });
        }
    }

    private static int CalculateFactionResearchOutput(Faction faction)
    {
        int total = 0;

        foreach (var colony in faction.Colonies)
        {
            total += colony.ResearchOutput;
        }

        return total;
    }
}
