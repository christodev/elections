using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Elections.Models
{
    public class ElectoralList
    {
        public string Name { get; set; }

        public int NbOfVotes { get; set; }

        public ElectoralList(string name, int nbOfVotes)
        {
            Name = name;
            NbOfVotes = nbOfVotes;
        }

        public ElectoralList()
        {

        }
    }
}
