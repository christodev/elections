using Elections.Repositories;
using System;
namespace Elections.Models.ObserverPattern
{
    public interface IObserver
    {
        void OnDeadlineReached_CalculateResults();
    }
}
