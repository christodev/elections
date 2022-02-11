using System;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Elections.ConstantValues;
using Elections.Repositories;

namespace Elections.Models.ObserverPattern
{
    public class ProxyResultsCalculator: IResultsCalculator
    {
        private RealResultsCalculator realResultsCalculator;

        List<ElectoralList> ElectoralLists;

        private IElectoralListRepository ElectoralListRepository;

        public ProxyResultsCalculator(List<ElectoralList> lists, IElectoralListRepository electoralListRepository)
        {
            ElectoralLists = lists;
            ElectoralListRepository = electoralListRepository;
        }

        public void CalculateResults()
        {
            try
            {
                var tempList = ElectoralListRepository.GetElectoralListById(0);
                //Check if realResultsCalculator instance is not null
                if (realResultsCalculator == null)
                    realResultsCalculator = new RealResultsCalculator(ElectoralLists, ElectoralListRepository);

                //Check if Voting Deadline has been reached
                //If no => exit
                if (DateTime.Now < Constants.DEADLINE)
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
