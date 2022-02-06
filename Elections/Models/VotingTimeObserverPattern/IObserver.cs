using System;
namespace Elections.Models.VotingTimeObserverPattern
{
    public interface IObserver
    {
        void OnDeadlineReached();
    }
}
