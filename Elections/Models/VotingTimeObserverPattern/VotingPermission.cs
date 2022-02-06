using System;
namespace Elections.Models.VotingTimeObserverPattern
{
    //Instead of the Controller
    public class VotingPermission: IObserver
    {
        private bool votingIsOpen = false;

        public bool VotingIsOpen
        {
            get
            {
                return votingIsOpen;
            }
        }

        public VotingPermission()
        {
        }

        public void OnDeadlineReached()
        {
            this.votingIsOpen =false;
        }
    }
}
