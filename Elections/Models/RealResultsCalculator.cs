using System;
using Elections.Models.VotingTimeObserverPattern;

namespace Elections.Models
{
    public class RealResultsCalculator: IResultsCalculator
    {
        private RealResultsCalculator realResultsCalculator;

        public RealResultsCalculator()
        {

        }

        public void CalculateResults()
        {
            //Calculate Results
        }

        public void OnDeadlineReached_CalculateResults()
        {
            //Dummy method ta sakkit l interface
        }
    }
}
