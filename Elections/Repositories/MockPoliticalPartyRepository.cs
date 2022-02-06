using Elections.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Elections.Repositories
{
    public class MockPoliticalPartyRepository: IPoliticalPartyRepository
    {

        private List<PoliticalParty> PoliticalParties = new List<PoliticalParty>()
        {
            new PoliticalParty("taqaddom","Taqaddom - تقدم", "Taqaddom's goal is to set a good economic draft.", "taqaddom.jpg"),
            new PoliticalParty("mmfd","Mmfd - ممفد", "Mmfd, short of مواطنون و مواطنات في دولة", "mmfd.png"),
        };

        //Used in UserController - Homepage() action
        public List<PoliticalParty> GetPoliticalParties()
        {
            if(PoliticalParties != null && PoliticalParties.Count > 0)
            {
                return PoliticalParties;
            }

            throw new Exception("No Electoral Lists added yet");
        }

        //Used in UserController - PoliticalParty() action
        public PoliticalParty GetPoliticalParty_ByIdentifier(string identifier)
        {
            var list = PoliticalParties.SingleOrDefault(pp => pp.Identifier == identifier);

            if(list != null)
            {
                return list;
            }

            throw new Exception("No such Electoral List exists");
        }
    }
}
