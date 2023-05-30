using FacioRatio.CSharpRailway;

namespace FacioRatio.Whereby.Api
{
    internal interface IApiCall<TResult>
    {
        Task<Result<ApiCallResult<TResult>>> Invoke(IDto<TResult> Dto);
    }
}
