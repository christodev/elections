using System;
namespace Elections.Models.VotingTimeObserverPattern
{
    public interface ISubject
    {
        void Subscribe(IObserver observer);

        void Unsubscribe(IObserver observer);

        void NotifyAllObservers();
    }
}
