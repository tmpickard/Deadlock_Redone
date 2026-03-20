using Deadlock_Redone.Core.Factions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Deadlock_Redone.Core.Research
{
    public static class ResearchRules
    {
        public static bool CanStartResearch(
        ResearchState researchState,
        TechnologyDefinition technology,
        IReadOnlyDictionary<string, TechnologyDefinition> allTechnologies)
        {
            if (researchState.HasCompleted(technology.Id))
            {
                return false;
            }

            if (string.Equals(researchState.CurrentTechnologyId, technology.Id, StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }

            foreach (string prerequisiteId in technology.PrerequisiteTechnologyIds)
            {
                if (!researchState.HasCompleted(prerequisiteId))
                {
                    return false;
                }
            }

            return true;
        }

        public static int CalculateResearchPointsPerTurn(
            Faction faction,
            int colonyResearchOutput)
        {
            double modifiedOutput = colonyResearchOutput * faction.Race.ResearchMultiplier;
            return Math.Max(0, (int)Math.Floor(modifiedOutput));
        }

        public static ResearchTurnResult ProcessResearchTurn(
            ResearchState researchState,
            Faction faction,
            IReadOnlyDictionary<string, TechnologyDefinition> allTechnologies,
            int rawResearchOutput)
        {
            if (string.IsNullOrWhiteSpace(researchState.CurrentTechnologyId))
            {
                return ResearchTurnResult.NoActiveResearch();
            }

            if(!allTechnologies.TryGetValue(researchState.CurrentTechnologyId, out var technology))
            {
                throw new KeyNotFoundException(
                    $"Technology '{researchState.CurrentTechnologyId}' not found.");
            }

            int pointsEarned = CalculateResearchPointsPerTurn(faction, rawResearchOutput);
            researchState.AddProgress(pointsEarned);

            if (researchState.CurrentProgress >= technology.ResearchCost)
            { 
                researchState.CompleteCurrentResearch();

                return ResearchTurnResult.Completed(
                    technology.Id,
                    technology.DisplayName,
                    pointsEarned);
            }

            return ResearchTurnResult.InProgress(
                technology.Id,
                technology.DisplayName,
                researchState.CurrentProgress,
                technology.ResearchCost,
                pointsEarned);
        }
    }
}
