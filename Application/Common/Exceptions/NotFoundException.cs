using System;

namespace Application.Common.Exceptions
{
    /// <summary>
    /// Exception uses when data is not found 
    /// </summary>
    public class NotFoundException : Exception
    {
        public NotFoundException()
            : base()
        {
        }

        public NotFoundException(string message)
            : base(message)
        {
            Source = message;
        }

        public NotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
            Source = message; 
        }

        public NotFoundException(string name, object key)
            : base()
        {
            Source = $"Entity \"{name}\" ({key}) was not found.";
        }
    }
}
