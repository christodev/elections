using System;
using Elections.Models.ObserverPattern;

namespace Elections.Models
{
    public interface IResultsCalculator: IObserver
    {
        void CalculateResults();
    }
}
