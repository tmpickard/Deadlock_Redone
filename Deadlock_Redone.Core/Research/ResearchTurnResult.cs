using System;
using System.Collections.Generic;
using System.Text;

namespace Deadlock_Redone.Core.Research
{
    public sealed class ResearchTurnResult
    {
        public bool HadActiveResearch { get; init; }
        public bool CompletedTechnology { get; init; }
        public string? TechnologyId { get; init; }
        public string? TechnologyName { get; init; }
        public int Progress { get; init; }
        public int Cost { get; init; }
        public int PointsEarnedThisTurn { get; init; }

        public static ResearchTurnResult NoActiveResearch() => new()
        {
            HadActiveResearch = false
        };

        public static ResearchTurnResult InProgress(
            string technologyId,
            string technologyName,
            int progress,
            int cost,
            int pointsEarnedThisTurn) => new()
            {
                HadActiveResearch = true,
                CompletedTechnology = false,
                TechnologyId = technologyId,
                TechnologyName = technologyName,
                Progress = progress,
                Cost = cost,
                PointsEarnedThisTurn = pointsEarnedThisTurn
            };

        public static ResearchTurnResult Completed(
            string technologyId,
            string technologyName,
            int pointsEarnedThisTurn) => new()
            {
                HadActiveResearch = true,
                CompletedTechnology = true,
                TechnologyId = technologyId,
                TechnologyName = technologyName,
                PointsEarnedThisTurn = pointsEarnedThisTurn
            };
    }
}