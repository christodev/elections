using System;
using Elections.Models.VotingTimeObserverPattern;

namespace Elections.Models
{
    public interface IResultsCalculator: IObserver
    {
        void CalculateResults();
    }
}
