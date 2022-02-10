using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Elections.Models
{
    public class Candidate: Contestant
    {

        public Status Status { get; set; }
        public string ImageURL { get; set; }

        public string Description { get; set; }

        public ElectoralList ElectoralList { get; set; }

        public Candidate()
        {
            this.Status = Status.Loser;
        }

        public Candidate(int id, string name, int nbOfVotes)
        {
            Id = id;
            Name = name;
            NbOfVotes = nbOfVotes;
            this.Status = Status.Loser;
        }

        public Candidate(int id, string name, int nbOfVotes, ElectoralList electoralList)
        {
            Id = id;
            Name = name;
            NbOfVotes = nbOfVotes;
            ElectoralList = electoralList;
            this.Status = Status.Loser;
        }

        public Candidate(int id, string name, int nbOfVotes, string desc, string imageURL)
        {
            Id = id;
            Name = name;
            NbOfVotes = nbOfVotes;
            Description = desc;
            ImageURL = imageURL;
            this.Status = Status.Loser;
        }

        public Candidate(int id, string name, int nbOfVotes, string desc, string imageURL, ElectoralList electoralList)
        {
            Id = id;
            Name = name;
            NbOfVotes = nbOfVotes;
            Description = desc;
            ImageURL = imageURL;
            ElectoralList = electoralList;
        }


    }
}
