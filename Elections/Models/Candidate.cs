using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Elections.Models
{
    public class Candidate: Contestant
    {
        public ElectoralList ElectoralList { get; set; }

        public Candidate()
        {

        }

        public Candidate(int id, string name, int nbOfVotes)
        {
            Id = id;
            Name = name;
            NbOfVotes = nbOfVotes;
        }

        public Candidate(int id, string name, int nbOfVotes, ElectoralList electoralList)
        {
            Id = id;
            Name = name;
            NbOfVotes = nbOfVotes;
            ElectoralList = electoralList;
        }


    }
}
