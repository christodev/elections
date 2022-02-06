using Elections.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Elections.Repositories
{
    public interface IUserRepository
    {
        User AddIfNewUser(User user);

        User GetUserByCreds(string email, string password);

        //method to disable User from Voting
        void DisableVoting(string username);
    }
}
