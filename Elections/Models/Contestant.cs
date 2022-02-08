using System;
namespace Elections.Models
{
    public abstract class Contestant
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int NbOfVotes { get; set; }



    }
}
