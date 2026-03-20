using Deadlock_Redone.Core.Events;
using Deadlock_Redone.Core.Game;
using Deadlock_Redone.Core.Research;
using Deadlock_Redone.Core.Turns;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetaryConquest.Core.Turns;

public sealed class TurnProcessor
{
    private readonly EconomyPhaseProcessor _economyPhaseProcessor;
    private readonly ResearchPhaseProcessor _researchPhaseProcessor;
    private readonly ColonyPhaseProcessor _colonyPhaseProcessor;
    private readonly MilitaryPhaseProcessor _militaryPhaseProcessor;
    private readonly ConflictResolver _conflictResolver;
    private readonly EventPhaseProcessor _eventPhaseProcessor;

    public TurnProcessor(IReadOnlyDictionary<string, TechnologyDefinition> technologyCatalog)
    {
        if (technologyCatalog is null)
        {
            throw new ArgumentNullException(nameof(technologyCatalog));
        }

        _economyPhaseProcessor = new EconomyPhaseProcessor();
        _researchPhaseProcessor = new ResearchPhaseProcessor(technologyCatalog);
        _colonyPhaseProcessor = new ColonyPhaseProcessor();
        _militaryPhaseProcessor = new MilitaryPhaseProcessor();
        _conflictResolver = new ConflictResolver();
        _eventPhaseProcessor = new EventPhaseProcessor();
    }

    public void ProcessTurn(GameState gameState)
    {
        if (gameState is null)
        {
            throw new ArgumentNullException(nameof(gameState));
        }

        foreach (var faction in gameState.Factions)
        {
            _economyPhaseProcessor.ProcessFaction(gameState, faction);
            _researchPhaseProcessor.ProcessFaction(gameState, faction);
            _colonyPhaseProcessor.ProcessFaction(gameState, faction);
            _militaryPhaseProcessor.ProcessFaction(gameState, faction);
        }

        _conflictResolver.Resolve(gameState);
        _eventPhaseProcessor.Trigger(gameState);

        gameState.TurnNumber++;
    }
}
