using System;
using System.Collections.Generic;
using System.Text;
using Deadlock_Redone.Core.Game;
using Deadlock_Redone.Core.Factions;
using Deadlock_Redone.Core.Colonies;
using Deadlock_Redone.Core.Buildings;
using Deadlock_Redone.Core.Units;

namespace PlanetaryConquest.Core.Turns;

public sealed class ColonyPhaseProcessor
{
    public void ProcessFaction(GameState gameState, Faction faction)
    {
        if (faction is null)
        {
            throw new ArgumentNullException(nameof(faction));
        }

        foreach (var colony in faction.Colonies)
        {
            ProcessColony(gameState, faction, colony);
        }
    }

    private void ProcessColony(GameState gameState, Faction faction, Colony colony)
    {
        ProduceResources(faction, colony);
        ConsumeFood(faction, colony);
        ApplyMoraleChanges(colony);
        ApplyPopulationGrowth(faction, colony);
        AdvanceBuildQueue(gameState, faction, colony);
    }

    private void ProduceResources(Faction faction, Colony colony)
    {
        faction.Food += colony.FoodOutput;
        faction.Ore += colony.OreOutput;
        faction.Energy += colony.EnergyOutput;
    }

    private void ConsumeFood(Faction faction, Colony colony)
    {
        int foodNeeded = colony.Population * 2;
        faction.Food -= foodNeeded;

        if (faction.Food < 0)
        {
            faction.Food = 0;
            colony.Morale = Math.Max(0, colony.Morale - 10);
        }
    }

    private void ApplyMoraleChanges(Colony colony)
    {
        if (colony.TaxRate > 3)
        {
            colony.Morale = Math.Max(0, colony.Morale - 2);
        }

        if (colony.Population > colony.PopulationCapacity)
        {
            colony.Morale = Math.Max(0, colony.Morale - 3);
        }
    }

    private void ApplyPopulationGrowth(Faction faction, Colony colony)
    {
        if (colony.Morale < 25)
        {
            return;
        }

        double growth = colony.BasePopulationGrowthRate * faction.Race.PopulationGrowthMultiplier;
        colony.Population += Math.Max(0, (int)Math.Floor(growth));
    }

    private void AdvanceBuildQueue(GameState gameState, Faction faction, Colony colony)
    {
        if (colony.BuildQueue.Count == 0)
        {
            return;
        }

        var currentItem = colony.BuildQueue[0];
        currentItem.Progress += colony.ProductionOutput;

        if (currentItem.Progress < currentItem.Cost)
        {
            return;
        }

        if (currentItem.ItemType == BuildQueueItemType.Building)
        {
            colony.Buildings.Add(new BuildingInstance
            {
                BuildingId = currentItem.DefinitionId,
                MaintenanceCost = currentItem.MaintenanceCost,
                IsOnline = true
            });

            gameState.PendingEvents.Add(new GameEvent
            {
                Title = "Building Completed",
                Description = $"{colony.Name} completed building: {currentItem.DisplayName}."
            });
        }

        if (currentItem.ItemType == BuildQueueItemType.Unit)
        {
            colony.StationedUnits.Add(new Unit
            {
                UnitId = currentItem.DefinitionId,
                DisplayName = currentItem.DisplayName,
                Attack = currentItem.Attack,
                Defense = currentItem.Defense,
                MaintenanceCost = currentItem.MaintenanceCost,
                CurrentHitPoints = currentItem.MaxHitPoints,
                MaxHitPoints = currentItem.MaxHitPoints
            });

            gameState.PendingEvents.Add(new GameEvent
            {
                Title = "Unit Completed",
                Description = $"{colony.Name} produced unit: {currentItem.DisplayName}."
            });
        }

        colony.BuildQueue.RemoveAt(0);
    }
}
