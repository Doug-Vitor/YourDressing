using System;

namespace YourDressing.Repositories.Exceptions
{
    public class IdNotProvidedException : ApplicationException
    {
        public IdNotProvidedException(string message) : base(message)
        {
        }
    }
}
