using System.Runtime.Serialization;

namespace BEChallenge.CrossCutting.Exceptions
{
    [Serializable]
    public class ValidationException : Exception
    {
        public ValidationException(String message)
           : base(message)
        {
        }
        protected ValidationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
