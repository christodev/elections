using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Elections.Models
{
    public class User
    {
        [Required]
        [MinLength(3, ErrorMessage = "The Username must be with a minimum length of 3 characters")]
        [MaxLength(20)]
        [Display(Name = "Username")]
        public string UserName { get; set; }

        [Required]
        [MinLength(8, ErrorMessage = "The field Password must be with a minimum length of 8 characters")]
        [MaxLength(20)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        //public string PasswordHash { get; set; }
        
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        //Boolean var to know if User has voted or not
        public bool Voted { get; set; }

        ////Var to know which Electoral
        //public ElectoralList VotedTo { get; set; }

        //Parameterless ctor
        public User() {}

        public User(string userName, string password, string email)
        {
            UserName = userName;
            Password = password;
            Email = email;
            Voted = false;
        }

        //Method to Set Voted var to true
        public void DisableVoting()
        {
            this.Voted = true;
        }
    }
}
