using System.Runtime.Serialization;

namespace bank.lib.Exceptions
{
    [Serializable]
    public class NameTooShortException : Exception
    {
        public NameTooShortException()
        {
        }

        public NameTooShortException(string? message) : base(message)
        {
        }

        public NameTooShortException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected NameTooShortException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}