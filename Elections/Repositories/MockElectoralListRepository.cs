using Elections.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Elections.Repositories
{
    public class MockElectoralListRepository : IElectoralListRepository
    {

        const string desc = "Short description of the candidate Short description of the candidate Short description of the candidate Short description of the candidate Short description of the candidate";

        //List<ElectoralList> List1 = new ElectoralList(0, "Better Tomorrow", 32578, new List<Candidate>

        List <ElectoralList> ElectoralLists = new List<ElectoralList>()
        {
            new ElectoralList(0, "Better Tomorrow", 32578, new List<Candidate>
            {
                new Candidate(0, "Abdel Rahim Youssef Mrad", 15111, desc, "male.png"),
                new Candidate(1, "Mohamad Dib Nasrallah", 8897, desc, "male.png"),
                new Candidate(2, "Elie Ferzli", 4899, desc, "male.png"),
                new Candidate(4, "Faysal Daoud", 2041, desc, "male.png"),
                new Candidate(5, "Naji Ghanem", 838, desc, "male.png")
            }),

            new ElectoralList(1, "Future for W. Bekaa and Rashaya", 31817, new List<Candidate>
            {
                new Candidate(6, "Wael Abou Faour", 10677, desc, "male.png"),
                new Candidate(7, "Mohamad El Karaaoui", 8768, desc, "male.png"),
                new Candidate(8, "Ziad El Kadri", 8392, desc, "male.png"),
                new Candidate(9, "Henry Chedid", 1584, desc, "male.png"),
                new Candidate(10, "Ghassan El Skaff", 995, desc, "male.png"),
                new Candidate(11, "Amin Wehbe", 741, desc, "male.png"),
            }),
            
            new ElectoralList(2, "Civil Society", 1546, new List<Candidate>
            {
                new Candidate(12, "Maguy Aoun", 847, desc, "female.png"),
                new Candidate(13, "Aladdine El Chemali", 168, desc, "male.png"),
                new Candidate(14, "Ali Sobeh", 162, desc, "male.png"),
                new Candidate(15, "Joseph Ayoub", 150, desc, "male.png"),
                new Candidate(16, "Faysal Rahal", 106, desc, "male.png"),
            }),
        };

        public List<ElectoralList> GetElectoralLists()
        {
            return ElectoralLists;
        }

        public void IncrementVotes_ForList(string electoralListName)
        {
            ElectoralLists.SingleOrDefault(el => el.Name == electoralListName).NbOfVotes++;
        }
    }
}
