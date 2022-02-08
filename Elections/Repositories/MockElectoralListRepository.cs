using Elections.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Elections.Repositories
{
    public class MockElectoralListRepository : IElectoralListRepository
    {

        const string desc = "Short description of the candidate Short description of the candidate Short description of the candidate Short description of the candidate Short description of the candidate";

        List<ElectoralList> ElectoralLists = new List<ElectoralList>()
        {
            new ElectoralList(0, "Elec List 1", 0, new List<Candidate>
            {
                new Candidate(0, "Christian Mikhael", 0, desc, "male.png"),
                new Candidate(1, "Michel Mikhael", 0, desc, "male.png"),
                new Candidate(2, "Christiane Mikhael", 0, desc, "female.png"),
                new Candidate(3, "Michelle Mikhael", 0, desc, "female.png")
            }),

            new ElectoralList(1, "Elec List 2", 0, new List<Candidate>
            {
                new Candidate(4, "Marilyn Chlimoun", 0, desc, "female.png"),
                new Candidate(5, "Melissa Chlimoun", 0, desc, "female.png"),
                new Candidate(6, "Michel Gerges", 0, desc, "male.png")
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
