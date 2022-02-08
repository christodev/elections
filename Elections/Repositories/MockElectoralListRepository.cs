using Elections.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Elections.Repositories
{
    public class MockElectoralListRepository : IElectoralListRepository
    {

        List<ElectoralList> ElectoralLists = new List<ElectoralList>()
        {
            new ElectoralList(0, "Elec List 1", 0, new List<Candidate>
            {
                new Candidate(0, "Christian Mikhael", 0),
                new Candidate(1, "Michel Mikhael", 0),
                new Candidate(2, "Christiane Mikhael", 0),
                new Candidate(3, "Michelle Mikhael", 0)
            }),


            new ElectoralList(1, "Elec List 2", 0, new List<Candidate>
            {
                new Candidate(4, "Marilyn Chlimoun", 0),
                new Candidate(5, "Melissa Chlimoun", 0),
                new Candidate(6, "Marc Chlimoun", 0)
            }),
        };

        public List<ElectoralList> GetElectoralLists()
        {
            return ElectoralLists;
        }

        public void IncrementVotes_ForList(string electoralListName)
        {
            ElectoralLists.SingleOrDefault(el => el.Name == electoralListName).NbOfVotes++;
        }
    }
}
