using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Elections.Models
{
    public class PoliticalParty
    {

        public string Identifier { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageURL { get; set; }


        public PoliticalParty(string identifier, string name, string desc, string imageURL)
        {
            Identifier = identifier;
            Name = name;
            Description = desc;
            ImageURL = imageURL;
        }

    }
}
