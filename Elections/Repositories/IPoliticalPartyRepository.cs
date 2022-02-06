using Elections.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Elections.Repositories
{
    public interface IPoliticalPartyRepository
    {
        public List<PoliticalParty> GetPoliticalParties();

        public PoliticalParty GetPoliticalParty_ByIdentifier(string identifier);
    }
}
