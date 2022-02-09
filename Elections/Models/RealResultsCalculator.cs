using System;
using System.Collections.Generic;
using System.Linq;
using Elections.Models.VotingTimeObserverPattern;

namespace Elections.Models
{
    public class RealResultsCalculator: IResultsCalculator
    {

        private List<ElectoralList> ElectoralLists;

        public RealResultsCalculator(List<ElectoralList> electoralLists)
        {
            ElectoralLists = electoralLists;
        }

        public void CalculateResults()
        {
            //int nbOfEligibleVoters = 134736;

            int nbOfSeats = 8;

            int nbOfVoters = 0;

            //1-Calculate Number of Voters
            foreach(var list in ElectoralLists)
            {
                nbOfVoters += list.NbOfVotes;
            }

            //2-Calculate the first EQ (Electoral Quotient - الحاصل الانتخابي)
            int firstEQ = nbOfVoters / nbOfSeats;

            //3-Eliminate the lists that don't have the

            //Dict that will hold the remainder for each list
            Dictionary<int, int> remainders = new Dictionary<int, int>();
            foreach(var list in ElectoralLists)
            {
                //By Default all lists are losers, until they pass the first EQ check
                list.Status = Status.Loser;

                //Check which lists have seats
                if(list.NbOfVotes >= firstEQ)
                {
                    list.Status = Status.Winner;

                    //Calculate the preliminary number of seats that the list will get
                    list.NumberOfSeats = (int)Math.Floor((double)list.NbOfVotes / firstEQ);

                    //Calculate its remainder
                    remainders.Add(list.Id, list.NbOfVotes % firstEQ);
                }
            }

            foreach(var list in ElectoralLists)
            {
                remainders.OrderByDescending
            }

            //Choose the Winners (According to the highest pref votes)

            //Calculate Results
        }

        public void OnDeadlineReached_CalculateResults()
        {
            //Dummy method ta sakkit l interface
        }
    }
}
