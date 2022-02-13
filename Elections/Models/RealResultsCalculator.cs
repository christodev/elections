using System;
using System.Collections.Generic;
using System.Linq;
using Elections.Models.ObserverPattern;
using Elections.Repositories;

namespace Elections.Models
{
    public class RealResultsCalculator: IResultsCalculator
    {

        private List<ElectoralList> ElectoralLists;
        private List<Candidate> EligibleCandidates;

        private int nbOfSeats;

        private IElectoralListRepository ElectoralListRepository;

        public RealResultsCalculator(List<ElectoralList> electoralLists, IElectoralListRepository electoralListRepository)
        //public RealResultsCalculator(List<ElectoralList> electoralLists)
        {
            ElectoralLists = electoralLists;
            ElectoralListRepository = electoralListRepository;
        }

        //public void CalculateResults()
        public void CalculateResults()
        {
            nbOfSeats = 6;

            int blankVotes = 541;
            //Bekaa 2

            //1-Calculate initial Total Number of Voters
            int nbOfVoters = blankVotes + ElectoralLists.Sum(el => el.NbOfVotes);

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

            //Dictionary of ElectoralListIds-remainders of each elect list (if seats are left, after distribution)
            Dictionary<int,double> listId_remainderDict = new Dictionary<int, double>();

            //5-NbOfVoters/EQ => NbOfSeats of each list
            EligibleElectoralLists.ForEach(el => 
            {
                el.NumberOfSeats = (int)Math.Floor((double)el.NbOfVotes / (double)EQ);
                listId_remainderDict.Add(el.Id,(int)Math.Round((double)el.NbOfVotes % (double)EQ, 2));
            }
            );

            //Sort the dictionary according to the remainder (DESC)
            //listId_remainderDict.OrderByDescending(kvp => kvp.Value);

            //END OF WORK WITH LISTS

            //START OF WORK WITH CANDIDATES

            //Create a list of the Eligible Candidates
            EligibleCandidates = EligibleElectoralLists.SelectMany<ElectoralList, Candidate>(el => el.Candidates).ToList();

            //Sort them according to the proportion (DESC)
            EligibleCandidates = EligibleCandidates.OrderByDescending<Candidate, double>(c => c.NbOfVotes/EQ).ToList();

            //Choose the Winners (According to the highest pref votes) (Neglect the Religions and the small regions)
            List<Candidate> ToBeRemoved = new List<Candidate>();
            //EligibleCandidates.ForEach(c =>
            foreach(var c in EligibleCandidates)
            {
                if (c.ElectoralList.NumberOfSeats > 0)
                {
                    this.ElectCandidate(c);
                    ToBeRemoved.Add(c);
                }
                else
                    c.Status = Status.Loser;
            }
            ToBeRemoved.ForEach(c => EligibleCandidates.Remove(c));
            ToBeRemoved.Clear();

            //Check if there are still empty seats
            while(nbOfSeats > 0)
            {
                //Check the remainders of each list
                foreach(var kvp in listId_remainderDict.OrderByDescending(kvp => kvp.Value))
                {
                    //Check if it can still win a seat
                    var tempList = ElectoralListRepository.GetElectoralListById(kvp.Key);
                    
                    //EligibleCandidates.ForEach(c =>
                    foreach(var c in EligibleCandidates)
                    {
                        if (c.ElectoralList == tempList)
                        {
                            //Assign Candidate to Winner Status, Reduce the number of seats left (from region and list)
                            this.ElectCandidate(c);
                            ToBeRemoved.Add(c);
                            break;
                        }
                    }
                    ToBeRemoved.ForEach(c => EligibleCandidates.Remove(c));
                    ToBeRemoved.Clear();
                    break;
                }
            }


        }

        private void ElectCandidate(Candidate cand)
        {
            cand.Status = Status.Winner;
            cand.ElectoralList.NumberOfSeats--;
            nbOfSeats--;
            //EligibleCandidates.Remove(cand);
        }
    }
}
