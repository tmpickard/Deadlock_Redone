using Deadlock_Redone.Core.Combat;
using Deadlock_Redone.Core.Factions;
using Deadlock_Redone.Core.Game;
using Deadlock_Redone.Core.Units;
using System;
using System.Collections.Generic;
using System.Text;

namespace Deadlock_Redone.Core.Turns
{
    public sealed class ConflictResolver
    {
        public void Resolve(GameState gameState)
        {
            if (gameState is null)
            {
                throw new ArgumentNullException(nameof(gameState));
            }

            foreach (var battle in gameState.PendingBattles.ToList())
            {
                ResolveBattle(gameState, battle);
                gameState.PendingBattles.Remove(battle);
            }
        }

        private void ResolveBattle(GameState gameState, PendingBattle battle)
        {
            int attackerPower = CalculateTotalCombatStrength(
                battle.AttackingUnits,
                battle.AttackerFaction);

            int defenderPower = CalculateTotalCombatStrength(
                battle.DefendingUnits,
                battle.DefenderFaction);

            if (attackerPower > defenderPower)
            {
                ApplyLosses(battle.DefendingUnits, 1.0);
                ApplyLosses(battle.AttackingUnits, 0.35);

                gameState.PendingEvents.Add(new GameEvent
                {
                    Title = "Battle Won",
                    Description = $"{battle.AttackerFaction.Name} defeated {battle.DefenderFaction.Name} at {battle.LocationName}."
                });
            }
            else
            {
                ApplyLosses(battle.AttackingUnits, 1.0);
                ApplyLosses(battle.DefendingUnits, 0.35);

                gameState.PendingEvents.Add(new GameEvent
                {
                    Title = "Battle Defended",
                    Description = $"{battle.DefenderFaction.Name} repelled an attack by {battle.AttackerFaction.Name} at {battle.LocationName}."
                });
            }

            RemoveDestroyedUnits(battle.AttackingUnits, battle.AttackerFaction);
            RemoveDestroyedUnits(battle.DefendingUnits, battle.DefenderFaction);
        }

        private int CalculateTotalCombatStrength(IEnumerable<Unit> units, Faction faction)
        {
            int total = 0;

            foreach (var unit in units)
            {
                double modifiedAttack = unit.Attack * faction.Race.UnitAttackMultiplier;
                double modifiedDefense = unit.Defense * faction.Race.UnitDefenseMultiplier;
                total += (int)Math.Floor(modifiedAttack + modifiedDefense);
            }

            return total;
        }

        private void ApplyLosses(IEnumerable<Unit> units, double severity)
        {
            foreach (var unit in units)
            {
                int damage = (int)Math.Ceiling(unit.MaxHitPoints * severity);
                unit.CurrentHitPoints = Math.Max(0, unit.CurrentHitPoints - damage);
            }
        }

        private void RemoveDestroyedUnits(IEnumerable<Unit> units, Faction faction)
        {
            var destroyed = units.Where(u => u.CurrentHitPoints <= 0).ToList();

            foreach (var unit in destroyed)
            {
                faction.Units.Remove(unit);
            }
        }
    }
}
