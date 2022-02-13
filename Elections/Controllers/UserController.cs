using Elections.Models;
using Elections.Repositories;
using Elections.Models.ObserverPattern;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
//using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Elections.ConstantValues;

namespace Elections.Controllers
{
    [Authorize(AuthenticationSchemes = "Cookies")]
    [Route("User")]
    public class UserController : Controller
    {
        private IPoliticalPartyRepository politicalPartyRepository;
        private IElectoralListRepository electoralListRepository;
        private IUserRepository userRepository;

        //Subject that will Notify the ResultsCalculator (observer) when voting is closed
        VotingPermission votingPermission = new VotingPermission();

        //Observer, when notified will calculate the results and return them to be displayed
        //IResultsCalculator resultsCalculator;

        ProxyResultsCalculator resultsCalculator;

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
            if (DateTime.Now >= Constants.DEADLINE)
            {
                //Notify Calculator to start Calculating (Internal Notification in the Setter)
                votingPermission.VotingIsOpen = false;
            }
        }


        [HttpGet]
        [AllowAnonymous]
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
        [AllowAnonymous]
        [HttpGet("PoliticalParty%2F{identifier}")]
        public IActionResult PoliticalParty(string identifier)
        {
            //Retrieve the Electoral List and pass it to the View to display its details
            var politicalParty = politicalPartyRepository.GetPoliticalParty_ByIdentifier(identifier);

            //Pass it to the View to display its details
            return View(politicalParty);
        }


        //Action used to Show the Full Electoral List
        //To be [HttpGet("Vote")]
        [HttpGet("ListsVote")]
        public IActionResult ListsVote_View(int? listId)
        {
            //Show Results if Deadline reached
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
                if (listId != null)
                {
                    //Show the user he Casted his Vote successfully via label and Disable button for all Lists
                    var tempList = electoralListRepository.GetElectoralListById(listId.Value);
                    ViewData["VotingResult"] = $"You have successfully voted to {tempList.Name}. You cannot Vote anymore!";
                }

                //ReDisplay the View with all the Lists
                return View("ListsVote", els);
            }
            catch
            {
                ViewData["VotingResult"] = "Unexpected Error Occured";
                return View("ListsVote");
            }
        }


        [HttpPost("ListsVote")]
        public IActionResult ListsVote([FromForm(Name = "listId")] int listId)
        {

            //Show Results if Deadline reached
            //Prevent User from Voting
            if (!votingPermission.VotingIsOpen)
                return RedirectToAction("Results");

            //Get the electoral list that the user clicked on
            ElectoralList tempList = electoralListRepository.GetElectoralListById(listId);
            
            //Display Candidates Voting List
            return View("CandidatesVote", tempList);

            #region Old
            ////Increase Nb of Votes
            //electoralListRepository.IncrementVotes(electoralListName);

            ////Disallow User from Voting Again
            //userRepository.DisableVoting(SignedInUser.Instance.UserName);

            ////Update User Singleton (No Full User with Credentials Exposure)
            //SignedInUser.Instance.DisableVoting();

            //return ListsVote_View  (electoralListName);
            ////return Ok(list);
            #endregion 
        }

        //This action is used when user refreshes listsvote view after voting, so he doesn't get 404
        [HttpGet("CandidatesVote")]
        public IActionResult CandidatesVote()
        {
            return ListsVote_View(null);
        }

        //Run when user Votes for a Candidate
        [HttpPost("CandidatesVote")]
        public IActionResult CandidatesVote(int listId, int candId)
        {
            //Increment the Votes of the List and the Candidate
            electoralListRepository.IncrementVotes(listId, candId);

            //Disallow User from Voting Again
            userRepository.DisableVoting(SignedInUser.Instance.UserName);

            //Update User Singleton (No Full User with Credentials Exposure)
            SignedInUser.Instance.DisableVoting();

            return ListsVote_View(listId);
        }


        //Action to Display Election Results
        [HttpGet("Results")]
        [AllowAnonymous]
        public IActionResult Results()
        {
            if (votingPermission.VotingIsOpen)
                return RedirectToAction("ListsVote_View", null);
            //Display Calculation

            var lists = electoralListRepository.GetElectoralLists();

            if (resultsCalculator == null)
                resultsCalculator = new ProxyResultsCalculator(lists, electoralListRepository);

            resultsCalculator.CalculateResults();

            return View(lists);
        }
    }
}