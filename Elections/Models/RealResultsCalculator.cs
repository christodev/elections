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

            int blankVotes = 541;

            int nbOfSeats = 6;

            int nbOfVoters = 0;

            //1-Calculate initial Total Number of Voters
            nbOfVoters = blankVotes + ElectoralLists.Sum(el => el.NbOfVotes);

            //STEP 1 - Filter the winning lists

            //2-Calculate the first EQ (Electoral Quotient - الحاصل الانتخابي) -- it will decide which lists continue to the next step
            double EQ = nbOfVoters / nbOfSeats;

            //3-Eliminate the lists that didn't reach the first EQ
            List<ElectoralList> EligibleElectoralLists = new List<ElectoralList>();

            EligibleElectoralLists = ElectoralLists.Where(el => el.NbOfVotes >= EQ).ToList();

            //Calculate new nb of voters
            nbOfVoters = blankVotes + EligibleElectoralLists.Sum(el => el.NbOfVotes);

            //Fix the status of the lists in the original list of elec lists
            foreach(var list in ElectoralLists)
            {
                //By Default all lists are winners, until they don't pass the first EQ check 
                list.Status = Status.Winner;

                if(list.NbOfVotes < EQ)
                {
                    list.Status = Status.Loser;
                }
            }

            //STEP 2 - Distribute the seats among the winning lists
            //Here we have a fresh NbOfVoters = TotalNbOfVoters - NbOfVotersOfLosingLists

            //4-Calculate the second EQ
            EQ = nbOfVoters / nbOfSeats;

            //5-NbOfVoters/EQ => NbOfSeats of each list
            EligibleElectoralLists.ForEach(el => el.NumberOfSeats = (int)Math.Floor((double)el.NbOfVotes / (double)EQ));

            //END OF WORK WITH LISTS

            //START OF WORK WITH CANDIDATES

            //Create a list of the Eligible Candidates
            List<Candidate> EligibleCandidates = EligibleElectoralLists.SelectMany<ElectoralList, Candidate>(el => el.Candidates).ToList();

            //Sort them according to the proportion (DESC)
            EligibleCandidates = EligibleCandidates.OrderByDescending<Candidate, double>(c => c.NbOfVotes/EQ).ToList();

            //Choose the Winners (According to the highest pref votes) (Neglect the Religions and the small regions)
            EligibleCandidates.ForEach(c =>
            {
                if (c.ElectoralList.NumberOfSeats > 0)
                {
                    c.Status = Status.Winner;
                    c.ElectoralList.NumberOfSeats--;
                }
            });
        }

        public void OnDeadlineReached_CalculateResults()
        {
            //Dummy method ta sakkit l interface
        }
    }
}
