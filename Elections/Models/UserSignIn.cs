using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Elections.Models
{
    public class UserSignIn
    {

        [Required]
        [EmailAddress]
        public string Email { get; set; }
     
        [Required]
        [MinLength(8, ErrorMessage = "The field Password must be with a minimum length of 8 characters")]
        [MaxLength(20)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
