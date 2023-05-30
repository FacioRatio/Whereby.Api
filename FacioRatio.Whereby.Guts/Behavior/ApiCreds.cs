namespace FacioRatio.Whereby.Api
{
    public class ApiCreds : IApiCreds
    {
        public string Host { get; set; }
        public string Token { get; set; }

        public ApiCreds(string Host, string Token)
        {
            this.Host = Host;
            this.Token = Token;
        }
    }
}
