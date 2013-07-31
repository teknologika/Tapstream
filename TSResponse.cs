namespace TapstreamMetrics.Sdk
{
    public sealed class TSResponse
    {
        private int status;
        private string message;

        public TSResponse(int status, string message)
        {
            this.status = status;
            this.message = message;
        }

        public int Status
        {
            get
            {
                return status;
            }
        }

        public string Message
        {
            get
            {
                return message;
            }
        }
    }
}