using FacioRatio.CSharpRailway;

namespace FacioRatio.Whereby.Api
{
    internal class ApiCallRateLimitDecorator<TResult> : IApiCall<TResult>
    {
        private readonly IApiCall<TResult> Decorated;
        private readonly IApiCallConfig ApiCallConfig;

        public ApiCallRateLimitDecorator(
            IApiCall<TResult> Decorated,
            IApiCallConfig ApiCallConfig)
        {
            this.Decorated = Decorated;
            this.ApiCallConfig = ApiCallConfig;
        }

        public async Task<Result<ApiCallResult<TResult>>> Invoke(IDto<TResult> Dto)
        {
            var attempts = ApiCallConfig.RetryAttempts;

            static bool tryAgain(ApiCallResult<TResult> r, int a)
            {
                return !r.Ok && r.AtLimit && a > 0;
            }

            Result<ApiCallResult<TResult>> result;
            bool keeptrying = false;
            do
            {
                result = await Decorated.Invoke(Dto)
                    .Bind(async apiResult =>
                    {
                        keeptrying = tryAgain(apiResult, attempts);
                        attempts--;
                        if (keeptrying)
                        {
                            await Task.Delay((apiResult.ApiRateLimit.Reset + 1) * 1000); //Reset is in seconds
                        }
                        return apiResult;
                    });
                    //!!need a railway version of the ApiCall that returns a Failure under retry conditions
                    //.OnFailure(async ex =>
                    //{
                    //    await Task.Delay((apiResult.ApiRateLimit.Reset + 1) * 1000);
                    //    attempts--;
                    //    keeptrying = tryAgain(apiResult, attempts);
                    //});
            }
            while (keeptrying);
            return result;
        }
    }
}
