using System;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Elections.Models.VotingTimeObserverPattern
{
    public class ProxyResultsCalculator: IResultsCalculator
    {
        private RealResultsCalculator realResultsCalculator;

        List<ElectoralList> ElectoralLists;

        public ProxyResultsCalculator(List<ElectoralList> lists)
        {
            ElectoralLists = lists;

            //List<Candidate> candidates = lists.SelectMany<ElectoralList, Candidate>(el => el.Candidates).ToList();

            //candidates.ForEach(
            //     c => {
            //         foreach(var list in lists)
            //         {

            //         }
            //})
        }

        public void CalculateResults()
        {
            try
            {
                //Check if realResultsCalculator instance is not null
                if (realResultsCalculator == null)
                    realResultsCalculator = new RealResultsCalculator(ElectoralLists);

                //Check if Voting Deadline has been reached
                DateTime DEADLINE = new DateTime(2022, 2, 7, 15, 14, 00);

                //If no => exit
                if (DateTime.Now < DEADLINE)
                {
                    //Notify Calculator to start Calculating
                    throw new Exception("Deadline not reached yet");
                }

                //If everything is alright, Calculate Results
                realResultsCalculator.CalculateResults();
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public void OnDeadlineReached_CalculateResults()
        {
            this.CalculateResults();
        }
    }
}
