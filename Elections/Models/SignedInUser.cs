using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Elections.Models
{
    public class SignedInUser: User
    {
        private static SignedInUser instance;

        private SignedInUser() {}

        public static SignedInUser Instance
        {
            get 
            {
                if(instance == null)
                {
                    instance = new SignedInUser();
                }
                //else if no instance is already created
                return instance;
            }

            //set 
            //{
            //    instance = value;
            //}
        }

        public static void SetInstance(User user)
        {
            if(instance == null)
            {
                instance = new SignedInUser();
            }
            instance.UserName = user.UserName;
            instance.Email = user.Email;
            instance.Voted = user.Voted;
        }
    }
}
