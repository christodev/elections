using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Elections.Models
{
    public class Candidate
    {
        public string Name { get; set; }

        public int NbOfVotes { get; set; }

        public ElectoralList ElectoralList { get; set; }

        public Candidate()
        {

        }

        public Candidate(string name, int nbOfVotes)
        {
            Name = name;
            NbOfVotes = nbOfVotes;
        }

        public Candidate(string name, int nbOfVotes, ElectoralList electoralList)
        {
            Name = name;
            NbOfVotes = nbOfVotes;
            ElectoralList = electoralList;
        }


    }
}
