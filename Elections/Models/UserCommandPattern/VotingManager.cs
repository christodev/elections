using System;
namespace Elections.Models.UserCommandPattern
{
   
    public class VotingManager
    {
        //This class is the Invoker for IUserCommand interface

        private IUserCommand disableVotingCommand;

        public VotingManager(IUserCommand _disableVotingCommand)
        {
            disableVotingCommand = _disableVotingCommand;
        }

        public void DisableVoting()
        {
            disableVotingCommand.Execute();
        }


    }
}
