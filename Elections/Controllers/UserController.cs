using Elections.Models;
using Elections.Repositories;
using Elections.Models.VotingTimeObserverPattern;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Elections.Controllers
{
    [Authorize(AuthenticationSchemes = "Cookies")]
    [Route("User")]
    public class UserController : Controller
    {
        private IPoliticalPartyRepository politicalPartyRepository;
        private IElectoralListRepository electoralListRepository;
        private IUserRepository userRepository;

        #region ConfusedAboutVotingDeadlineImplementation
        /*So basically, I don't know whether to put a single boolean var 
         * to indicate that elections time's up, or put an object to relate it with Observer Pattern
         * I need to ask my manager if Controllers can be part of Design patterns
         *
         * First, I will try with an object
         * This object will be watching for the end of the Elections (Until time's up)*/

        VotingPermission votingPermission = new VotingPermission();

        IResultsCalculator resultsCalculator = new ProxyResultsCalculator();

        DateTime DEADLINE = new DateTime(2022, 2, 7, 15, 14, 00);

        bool redirect;
        //bool var to indicate if voting's deadline is reached
        //private bool timeIsUp;
        #endregion ConfusedAboutVotingDeadlineImplementation
        public UserController(IPoliticalPartyRepository _politicalPartyRepository, 
            IElectoralListRepository _electoralListRepository,
            IUserRepository _userRepository)
        {
            politicalPartyRepository = _politicalPartyRepository;
            electoralListRepository = _electoralListRepository;
            userRepository = _userRepository;

            //Let Results Calc keep Watching for Elections Deadline
            votingPermission.Subscribe(resultsCalculator);

            //Check if Voting Closed, Display Results
            //Check if Voting Deadline has been reached
            //If yes
            if (DateTime.Now > DEADLINE)
            {
                //Notify Calculator to start Calculating
                votingPermission.VotingIsOpen = false;
                redirect = true;
            }
        }

        [HttpGet]
        public IActionResult Homepage()
        {
            try
            {
                //Retrieve the Electoral Lists to pass them to the View to be displayed
                var politicalParties = politicalPartyRepository.GetPoliticalParties();

                //Pass them to the View to be displayed
                return View(politicalParties);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }


        //Action used to View the details of a Political Party
        [HttpGet("PoliticalParty%2F{identifier}")]
        //public IActionResult PoliticalPartyInformation(string identifier)
        public IActionResult PoliticalParty(string identifier)
        {
            //Retrieve the Electoral List and pass it to the View to display its details
            var politicalParty = politicalPartyRepository.GetPoliticalParty_ByIdentifier(identifier);

            //Pass it to the View to display its details
            return View(politicalParty);
        }

        //Action used to Increment the nb of Votes of an Electoral List

        [HttpGet("Vote")]
        public IActionResult IncrementVotes_View(string listName)
        {
            if (redirect)
                return RedirectToAction("Results");

            List<ElectoralList> els = electoralListRepository.GetElectoralLists();

            try
            {
                //SETTING DEFAULT VALUES
                ViewData["disabled"] = "";

                //Check if Voting Deadline has been reached
                //If yes
                if (DateTime.Now > DEADLINE)
                {
                    //Notify Calculator to start Calculating
                    votingPermission.VotingIsOpen = false;
                }

                if (!votingPermission.VotingIsOpen || SignedInUser.Instance.Voted)
                    ViewData["disabled"] = "disabled";

                //If User has Voted
                if(listName != null)
                    //Show the user he Casted his Vote successfully via label and Disable button for all Lists
                    ViewData["Error"] = $"Successfully voted to {listName}";
                //ReDisplay the View
                return View("Vote", els);
            }
            catch
            {
                ViewData["Error"] = "Unexpected Error Occured";
                return View("Vote");
            }
        }

        [HttpPost("Vote")]
        public IActionResult Increment_Votes([FromForm(Name = "name")]string electoralListName)
        //public IActionResult Increment_Votes(string list)
        {

            //Increase Nb of Votes
            electoralListRepository.IncrementVotes_ForList(electoralListName);

            //Disallow User from Voting Again
            userRepository.DisableVoting(SignedInUser.Instance.UserName);

            //Update User Singleton (No Full User with Credentials Exposure)
            SignedInUser.Instance.DisableVoting();

            return IncrementVotes_View(electoralListName);
            //return Ok(list);
        }

        //Method to Display Election Results
        [HttpGet("Results")]
        [AllowAnonymous]
        public IActionResult Results() 
        {
            //Display Calculation
            
            return Ok("Results calculated!");
        }

        private void RedirectToResults()
        {
            if(redirect)
                RedirectToAction("Results");
        }
    }
}
