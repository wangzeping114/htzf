using System;

namespace WS.HTZF.Core.Exceptions
{
    public class AuthorizeFailException:Exception
    {
        public AuthorizeFailException(string message):base(message)
        {

        }
    }
}
