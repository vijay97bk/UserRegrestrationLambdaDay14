using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsweRegistrationUsingLambda
{
    public class UserRegistrationCustomException : Exception
    {
        ExceptionType type;
        public enum ExceptionType
        {
            EMPTY_EXCEPTION,
            MINIMUM_LENGTH_EXCEPTION,
            USER_ENTERED_NUMBER,
            USER_ENTERED_LOWERCASE,
            USER_ENTERED_SPECIAL_CHARACTER,
        }
        public UserRegistrationCustomException(ExceptionType type, string message) : base(message)
        {
            this.type = type;
        }
    }
}