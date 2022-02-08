using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Elections.Models
{
    public class ElectoralList: Candidate
    {

        public List<Candidate> Candidates { get; set; }

        public ElectoralList()
        {

        }

        public ElectoralList(string name, int nbOfVotes)
        {
            Name = name;
            NbOfVotes = nbOfVotes;
        }

        public ElectoralList(string name, int nbOfVotes, List<Candidate> candidates)
        {
            Name = name;
            NbOfVotes = nbOfVotes;
            Candidates = candidates;
        }

    }
}
