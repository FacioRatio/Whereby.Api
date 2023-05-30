using System.Runtime.Serialization;

namespace FacioRatio.Whereby.Api
{
    [Serializable]
    public class MissingHttpResponseException : ApplicationException
    {
        public string Host { get; private set; }

        public MissingHttpResponseException(string Host)
            : base()
        {
            this.Host = Host;
        }

        public MissingHttpResponseException(string Host, string message)
            : base(message)
        {
            this.Host = Host;
        }

        public MissingHttpResponseException(string Host, string message, Exception innerException)
            : base(message, innerException)
        {
            this.Host = Host;
        }

        public MissingHttpResponseException(string Host, SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            this.Host = Host;
        }
    }
}
