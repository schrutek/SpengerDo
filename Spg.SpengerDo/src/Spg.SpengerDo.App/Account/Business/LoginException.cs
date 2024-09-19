using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.SpengerDo.App.Account.Business
{
    public class LoginException : Exception
    {
        public LoginException()
            : base()
        { }
        public LoginException(string message)
            : base(message)
        { }
        public LoginException(string message, Exception innerException)
            : base(message, innerException)
        { }

        public static LoginException FromNotFound()
        {
            return new LoginException("User not found!");
        }
    }
}
