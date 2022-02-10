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

        List<ElectoralList> ElectoralLists;

        public MockElectoralListRepository()
        {

            //Creating List1
            ElectoralList list1 = new ElectoralList();

            Candidate cand1 = new Candidate(0, "Abdel Rahim Youssef Mrad", 15111, desc, "male.png");
            Candidate cand2 = new Candidate(1, "Mohamad Dib Nasrallah", 8897, desc, "male.png");
            Candidate cand3 = new Candidate(2, "Elie Ferzli", 4899, desc, "male.png");
            Candidate cand4 = new Candidate(3, "Faysal Daoud", 2041, desc, "male.png");
            Candidate cand5 = new Candidate(4, "Naji Ghanem", 838, desc, "male.png");

            list1 = new ElectoralList(0, "Better Tomorrow", 32578, new List<Candidate> {
                cand1, cand2, cand3, cand4, cand5
            });

            cand1.ElectoralList = list1;
            cand2.ElectoralList = list1;
            cand3.ElectoralList = list1;
            cand4.ElectoralList = list1;
            cand5.ElectoralList = list1;

            //Creating List2

            ElectoralList list2 = new ElectoralList();

            Candidate cand6 = new Candidate(5, "Wael Abou Faour", 10677, desc, "male.png");
            Candidate cand7 = new Candidate(6, "Mohamad El Karaaoui", 8768, desc, "male.png");
            Candidate cand8 = new Candidate(7, "Ziad El Kadri", 8392, desc, "male.png");
            Candidate cand9 = new Candidate(8, "Henry Chedid", 1584, desc, "male.png");
            Candidate cand10 = new Candidate(9, "Ghassan El Skaff", 995, desc, "male.png");
            Candidate cand11 = new Candidate(10, "Amin Wehbe", 741, desc, "male.png");

            list2 = new ElectoralList(1, "Future for W. Bekaa and Rashaya", 31817, new List<Candidate>
            {
                cand6, cand7, cand8, cand9, cand10, cand11
            });

            cand6.ElectoralList = list2;
            cand7.ElectoralList = list2;
            cand8.ElectoralList = list2;
            cand9.ElectoralList = list2;
            cand10.ElectoralList = list2;
            cand11.ElectoralList = list2;

            //Creating List3

            ElectoralList list3 = new ElectoralList();

            Candidate cand12 = new Candidate(11, "Maguy Aoun", 847, desc, "female.png");
            Candidate cand13 = new Candidate(12, "Aladdine El Chemali", 168, desc, "male.png");
            Candidate cand14 = new Candidate(13, "Ali Sobeh", 162, desc, "male.png");
            Candidate cand15 = new Candidate(14, "Joseph Ayoub", 150, desc, "male.png");
            Candidate cand16 = new Candidate(15, "Faysal Rahal", 106, desc, "male.png");

            list3 = new ElectoralList(2, "Civil Society", 1546, new List<Candidate>
            {
                cand12, cand13, cand14, cand15, cand16
            });

            cand12.ElectoralList = list3;
            cand13.ElectoralList = list3;
            cand14.ElectoralList = list3;
            cand15.ElectoralList = list3;
            cand16.ElectoralList = list3;

            ElectoralLists = new List<ElectoralList>()
            {
                list1, list2, list3
            };
        }

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
