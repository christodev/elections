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
            new ElectoralList("Elec List 1", 0),
            new ElectoralList("Elec List 2", 0),
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
