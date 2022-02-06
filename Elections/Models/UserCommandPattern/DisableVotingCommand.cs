using System;
namespace Elections.Models.UserCommandPattern
{
    public class DisableVotingCommand: IUserCommand
    {
        private User user;

        public DisableVotingCommand(User _user)
        {
            user = _user;
        }

        public void Execute()
        {
            user.DisableVoting();
        }
    }
}
