using Elections.Models;
using Elections.Exceptions;
using Elections.Models.UserCommandPattern;

using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Elections.Repositories
{
    public class MockUserRepository: IUserRepository
    {
        //User Commands (Command DP)
        private IUserCommand disableVotingCommand; //Command to Execute

        private VotingManager votingManager; //Invoker

        //to employ command pattern to add edit users..
        Dictionary<int, User> UsersList = new Dictionary<int, User>()
        {
            {0, new User("kik", "12345678", "kik@hotmail.com") },
            {1, new User("master", "12345678", "master@hotmail.com") }
        };

        //Method to add user if he does not already exist
        //If success return user
        //Else throw exception
        public User AddIfNewUser(User user)
        {
            //Verify if UserName or Email is already taken
            var alreadyExistingUser = UsersList.Values.Any(u => u.UserName == user.UserName);

            //If no user exists with such Username
            if(alreadyExistingUser != true)
            {
                //Check if Email is taken
                if(!UsersList.Values.Any(u => u.Email == user.Email))
                {
                    //Compute index where to add user
                    int indexOfNewUser = UsersList.Count;

                    //Add the User
                    UsersList.Add(indexOfNewUser, user);

                    //Return the User
                    return user;
                }
                throw new FailedToSignInException("Email is already taken");
            }

            //else if username already exists
            throw new FailedToSignInException("Username is already taken");
            
        }

        public void DisableVoting(string username)
        {
            //Search for the User
            User user = UsersList.Values.SingleOrDefault(u => u.UserName == username);

            //Prepare to Execute DisableVoting Command

            //Set the User on which to Execute the Command
            disableVotingCommand = new DisableVotingCommand(user);

            //Set the Command for the Invoker
            votingManager = new VotingManager(disableVotingCommand);

            //Execute the Command
            votingManager.DisableVoting();
        }

        //Method to Get User By Creds
        //If success return user
        //else return null
        public User GetUserByCreds(string email, string password)
        {
            User tempUser = UsersList.Values.SingleOrDefault(u => u.Email == email
                                                        && u.Password == password);

            //If User was found
            if(tempUser != null)
            {
                return tempUser;
            }

            //else => User was not found
            throw new FailedToSignInException("Incorrect Email and/or Password combination");

        }
    }
}
