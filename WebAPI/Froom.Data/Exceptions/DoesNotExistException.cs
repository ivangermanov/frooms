using System;

namespace Froom.Data.Exceptions
{
    /// <summary>
    /// Exception raised when a resource that does not exist is requested.
    /// </summary>
    public class DoesNotExistException : Exception
    {
        public DoesNotExistException() : base("Does not exist.") { }
        public DoesNotExistException(string message) : base(message) { }
        public DoesNotExistException(string message, Exception innerException) : base(message, innerException) { }
    }
}
