using Deadlock_Redone.Core.Game;
using System;
using System.Collections.Generic;
using System.Text;

namespace Deadlock_Redone.Core.Events
{
    public sealed class EventPhaseProcessor
    {
        private readonly Random _random = new();

        public void Trigger(GameState gameState)
        {
            if (gameState is null)
            {
                throw new ArgumentNullException(nameof(gameState));
            }

            TriggerRandomEvents(gameState);
            ResolvePendingEvents(gameState);
        }

        private void TriggerRandomEvents(GameState gameState)
        {
            foreach (var faction in gameState.Factions)
            {
                foreach (var colony in faction.Colonies)
                {
                    int roll = _random.Next(1, 101);

                    if (roll <= 2)
                    {
                        colony.Morale = Math.Max(0, colony.Morale - 10);

                        gameState.PendingEvents.Add(new GameEvent
                        {
                            Title = "Civil Unrest",
                            Description = $"Civil unrest has broken out in {colony.Name}."
                        });
                    }
                    else if (roll >= 99)
                    {
                        colony.Morale = Math.Min(100, colony.Morale + 5);

                        gameState.PendingEvents.Add(new GameEvent
                        {
                            Title = "Festival",
                            Description = $"A planetary festival in {colony.Name} has raised morale."
                        });
                    }
                }
            }
        }

        private void ResolvePendingEvents(GameState gameState)
        {
            foreach (var gameEvent in gameState.PendingEvents)
            {
                gameState.EventLog.Add(gameEvent);
            }

            gameState.PendingEvents.Clear();
        }
    }
}


