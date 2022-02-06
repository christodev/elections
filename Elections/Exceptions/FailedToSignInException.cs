using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Elections.Exceptions
{
    public class FailedToSignInException: Exception
    {
        public FailedToSignInException()
        {
        }

        public FailedToSignInException(string message) : base(message)
        {

        }
    }
}
