using System;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Elections.Models.VotingTimeObserverPattern
{
    public class VotingDeadline: ISubject
    {
        //Used to implement Disabling voting for All Users after deadline reached

        //Subject
        //When Notifies Obsever, Voting is Closed

        List<IObserver> Observers = new List<IObserver>();

        public VotingDeadline()
        {
        }

        public void Notify()
        {
            foreach (var obs in Observers)
            {
                obs.OnDeadlineReached();
            }
        }

        //Method to add Observers watching
        public void Subscribe(IObserver observer)
        {
            Observers.Add(observer);
        }

        //Method to remove Observers watching
        public void Unsubscribe(IObserver observer)
        {
            Observers.Remove(observer);
        }

        public async Task<string> WatchForDeadlineAsync()
        {
            await Task.Delay(15000);
            string time = DateTime.Now.ToString("G");

            return time;
        }
    }
}
