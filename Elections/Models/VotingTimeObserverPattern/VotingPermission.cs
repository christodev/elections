using System;
using System.Collections.Generic;

namespace Elections.Models.VotingTimeObserverPattern
{
    //Instead of the Controller
    public class VotingPermission: ISubject
    {

        private List<IObserver> Observers = new List<IObserver>();

        private bool votingIsOpen;

        public bool VotingIsOpen
        {
            set
            {
                votingIsOpen = value;
                if (votingIsOpen)
                    NotifyAllObservers();
            }

            get
            {
                return votingIsOpen;
            }
        }

        public VotingPermission()
        {
            //Voting is Open by Default
            votingIsOpen = false;
        }

        public void NotifyAllObservers()
        {
            foreach (var obs in Observers)
            {
                obs.OnDeadlineReached_CalculateResults();
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
    }
}
