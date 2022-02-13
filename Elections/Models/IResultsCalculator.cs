using System;
using Elections.Repositories;
using Elections.Models.ObserverPattern;

namespace Elections.Models
{
    public interface IResultsCalculator
    {
        void CalculateResults();
    }
}
