using System;
using System.Collections.Generic;
using System.Text;

namespace Deadlock_Redone.Core.Research
{
    public sealed class ResearchState
    {
        public string? CurrentTechnologyId { get; private set; }
        public int CurrentProgress { get; private set; }
        public HashSet<string> CompletedTechnologyIds { get; } = new(StringComparer.OrdinalIgnoreCase);
        public bool HasCompleted(string technologyId)
        {
            return CompletedTechnologyIds.Contains(technologyId);
        }
        public bool IsResearchingAnything()
        {
            return !string.IsNullOrWhiteSpace(CurrentTechnologyId);
        }
        public void StartResearch(string technologyId)
        {
            CurrentTechnologyId = technologyId;
            CurrentProgress = 0;
        }

        public void AddProgress(int amount)
        {
            if(amount < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Progress cannot be negative.");
            }

            if (string.IsNullOrWhiteSpace(CurrentTechnologyId))
            { 
                return;
            }

            CurrentProgress += amount;
        }

        public void CompleteCurrentResearch() 
        {
            if (string.IsNullOrWhiteSpace(CurrentTechnologyId)) 
            {
                throw new InvalidOperationException("No technology is currently being researched.");
            }

            CompletedTechnologyIds.Add(CurrentTechnologyId);
            CurrentTechnologyId = null;
            CurrentProgress = 0;
        }
    }
}
