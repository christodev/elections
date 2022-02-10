using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Elections.Models;

namespace Elections.Repositories
{
    public interface IElectoralListRepository
    {
        List<ElectoralList> GetElectoralLists();

        void IncrementVotes(int listId, int candId);
    }
}
