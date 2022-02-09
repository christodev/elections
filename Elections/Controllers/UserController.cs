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
        //private IUserRepository userRepository;

        //Subject that will Notify the ResultsCalculator (observer) when voting is closed
        VotingPermission votingPermission = new VotingPermission();

        //Observer, when notified will calculate the results and return them to be displayed
        IResultsCalculator resultsCalculator;

        readonly DateTime DEADLINE = new DateTime(2022, 2, 8, 15, 14, 00);
        
        public UserController(IPoliticalPartyRepository _politicalPartyRepository,
            IElectoralListRepository _electoralListRepository,
            IUserRepository _userRepository)
        {
            politicalPartyRepository = _politicalPartyRepository;
            electoralListRepository = _electoralListRepository;
            //userRepository = _userRepository;

            //Let Results Calc keep Watching for Elections Deadline
            votingPermission.Subscribe(resultsCalculator);

            //Check if Voting Closed, Display Results
            //Check if Voting Deadline has been reached
            //If yes
            if (DateTime.Now > DEADLINE)
            {
                //Notify Calculator to start Calculating (Internal Notification in the Setter)
                votingPermission.VotingIsOpen = false;
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
            if (!votingPermission.VotingIsOpen)
                return RedirectToAction("Results");

            List<ElectoralList> els = electoralListRepository.GetElectoralLists();

            try
            {
                //SETTING DEFAULT VALUE (Voting Enabled)
                ViewData["disabled"] = "";

                if (!votingPermission.VotingIsOpen || SignedInUser.Instance.Voted)
                    ViewData["disabled"] = "disabled";

                //If User has Voted and reloading the page
                if (listName != null)
                    //Show the user he Casted his Vote successfully via label and Disable button for all Lists
                    ViewData["VotingResult"] = $"Successfully voted to {listName}";

                //ReDisplay the View
                return View("Vote", els);
            }
            catch
            {
                ViewData["VotingResult"] = "Unexpected Error Occured";
                return View("Vote");
            }
        }

        //[HttpGet]
        //public IActionResult Candidates_Vote(ElectoralList list)
        //{
        //    return View(list);
        //}


        [HttpPost("Vote")]
        public IActionResult Increment_Votes([FromForm(Name = "name")] string electoralListName)
        {

            //Get the electoral list that the user clicked on
            var tempElectoralList = electoralListRepository.GetElectoralLists().SingleOrDefault(el => el.Name == electoralListName);

            //Display Candidates Voting List
            return View("Candidates_Vote", tempElectoralList);

            #region Old
            ////Increase Nb of Votes
            //electoralListRepository.IncrementVotes_ForList(electoralListName);

            ////Disallow User from Voting Again
            //userRepository.DisableVoting(SignedInUser.Instance.UserName);

            ////Update User Singleton (No Full User with Credentials Exposure)
            //SignedInUser.Instance.DisableVoting();

            //return IncrementVotes_View  (electoralListName);
            ////return Ok(list);
            #endregion 
        }


        //Action to Display Election Results
        [HttpGet("Results")]
        [AllowAnonymous]
        public IActionResult Results()
        {
            if (votingPermission.VotingIsOpen)
                return RedirectToAction("IncrementVotes_View", null);
            //Display Calculation

            var lists = electoralListRepository.GetElectoralLists();

            if (resultsCalculator == null)
                resultsCalculator = new ProxyResultsCalculator(lists);

            resultsCalculator.CalculateResults();

            return View(lists);
        }
    }
}