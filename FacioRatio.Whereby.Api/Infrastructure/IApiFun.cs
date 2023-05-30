namespace FacioRatio.Whereby.Api
{
    internal interface IApiFun<TResult>
    {
        string Endpoint { get; }
        Func<Action<HttpRequestMessage>, Action<HttpResponseMessage>, Task<string>> Generate(string Host, IDto<TResult> Dto);
    }
}
