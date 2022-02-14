using System;

namespace CustomVision
{
    public class ServiceException : Exception
    {
        private readonly int _statusCode;

        public ServiceException(string message, Exception innerException) : base(message, innerException)
        {

        }

        public ServiceException(int statusCode, string message) : this(message, null)
        {
            _statusCode = statusCode;
        }

        public ServiceException(string message) : this(message, null)
        {

        }

    }
}
