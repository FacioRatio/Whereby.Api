namespace FacioRatio.Whereby.Api
{
    internal interface IApiCall<TResult>
    {
        Task<ApiCallResult<TResult>> Invoke(IDto<TResult> Dto);
    }
}
