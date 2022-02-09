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

            //Assume 3adad l nekhbin houwe 220000
            int nbOfEligibleVoters = 220000;

            int nbOfVoters = 0;

            //1-Calculate Number of Voters
            foreach(var list in ElectoralLists)
            {
                nbOfVoters += list.NbOfVotes;
            }

            //2-Calculate the EQ (Electoral Quotient - الحاصل الانتخابي)
            int EQ = nbOfVoters / nbOfEligibleVoters;

            //3-Calculate the first number of seats for each list
            Dictionary<int, int> remainders = new Dictionary<int, int>();
            foreach(var list in ElectoralLists)
            {
                list.NumberOfSeats = (int)Math.Floor((double)list.NbOfVotes / EQ);
                remainders.Add(list.Id, list.NbOfVotes % EQ);
            }


            foreach(var list in ElectoralLists)
            {
                //Chouf ba2iyet l ma2e3id hasab l ksourat
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
