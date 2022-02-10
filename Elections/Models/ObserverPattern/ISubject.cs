using System;
namespace Elections.Models.ObserverPattern
{
    public interface ISubject
    {
        void Subscribe(IObserver observer);

        void Unsubscribe(IObserver observer);

        void NotifyAllObservers();
    }
}
