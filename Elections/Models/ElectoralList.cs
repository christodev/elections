using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Elections.Models
{
    public class ElectoralList: Contestant
    {
        public int NumberOfSeats { get; set; }

        public List<Candidate> Candidates { get; set; }

        public ElectoralList()
        {

        }

        public ElectoralList(int id, string name, int nbOfVotes)
        {
            Id = id;
            Name = name;
            NbOfVotes = nbOfVotes;
        }

        public ElectoralList(int id, string name, int nbOfVotes, List<Candidate> candidates)
        {
            Id = id;
            Name = name;
            NbOfVotes = nbOfVotes;
            Candidates = candidates;
        }

    }
}
