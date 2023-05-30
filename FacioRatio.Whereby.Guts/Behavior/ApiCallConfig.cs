namespace FacioRatio.Whereby.Api
{
    public class ApiCallConfig : IApiCallConfig
    {
        public int RetryAttempts { get; set; }

        public ApiCallConfig(int RetryAttempts)
        {
            this.RetryAttempts = RetryAttempts;
        }
    }
}
