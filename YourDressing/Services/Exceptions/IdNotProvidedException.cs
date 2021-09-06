using System;

namespace YourDressing.Services.Exceptions
{
    public class IdNotProvidedException : ApplicationException
    {
        public IdNotProvidedException(string message) : base(message)
        {
        }
    }
}
