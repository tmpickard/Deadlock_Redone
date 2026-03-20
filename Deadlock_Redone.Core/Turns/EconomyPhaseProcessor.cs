using Deadlock_Redone.Core.Factions;
using Deadlock_Redone.Core.Game;
using Deadlock_Redone.Core.Colonies;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetaryConquest.Core.Turns;

public sealed class EconomyPhaseProcessor
{
    public void ProcessFaction(GameState gameState, Faction faction)
    {
        if (faction is null)
        {
            throw new ArgumentNullException(nameof(faction));
        }

        int totalTaxIncome = 0;
        int totalTradeIncome = 0;
        int totalMaintenanceCost = 0;
        int totalTransportCost = 0;

        foreach (var colony in faction.Colonies)
        {
            totalTaxIncome += CalculateColonyTaxIncome(colony, faction);
            totalTradeIncome += CalculateColonyTradeIncome(colony, faction);
            totalMaintenanceCost += CalculateColonyMaintenance(colony);
        }

        totalTransportCost = CalculateTransportCosts(faction);

        int grossIncome = totalTaxIncome + totalTradeIncome;
        int netIncome = grossIncome - totalMaintenanceCost - totalTransportCost;

        faction.Credits += netIncome;

        if (faction.Credits < 0)
        {
            ApplyBankruptcyPressure(faction);
        }
    }

    private int CalculateColonyTaxIncome(Colony colony, Faction faction)
    {
        int baseIncome = colony.Population * colony.TaxRate;
        double modifiedIncome = baseIncome * faction.Race.TaxIncomeMultiplier;
        return Math.Max(0, (int)Math.Floor(modifiedIncome));
    }

    private int CalculateColonyTradeIncome(Colony colony, Faction faction)
    {
        int baseTrade = colony.TradeValue;
        double modifiedTrade = baseTrade * faction.Race.TradeIncomeMultiplier;
        return Math.Max(0, (int)Math.Floor(modifiedTrade));
    }

    private int CalculateColonyMaintenance(Colony colony)
    {
        int buildingMaintenance = colony.Buildings.Sum(b => b.MaintenanceCost);
        int unitMaintenance = colony.StationedUnits.Sum(u => u.MaintenanceCost);
        return buildingMaintenance + unitMaintenance;
    }

    private int CalculateTransportCosts(Faction faction)
    {
        int baseTransportCost = faction.Colonies.Count * 2;
        double modified = baseTransportCost * faction.Race.TransportCostMultiplier;
        return Math.Max(0, (int)Math.Floor(modified));
    }

    private void ApplyBankruptcyPressure(Faction faction)
    {
        foreach (var colony in faction.Colonies)
        {
            colony.Morale = Math.Max(0, colony.Morale - 5);
        }
    }
}