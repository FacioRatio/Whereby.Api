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

        public async Task<ApiCallResult<TResult>> Invoke(IDto<TResult> Dto)
        {
            var attempts = ApiCallConfig.RetryAttempts;

            static bool tryAgain(ApiCallResult<TResult> r, int a)
            {
                return !r.Ok && r.AtLimit && a > 0;
            }

            var result = await Decorated.Invoke(Dto);
            var keeptrying = tryAgain(result, attempts);
            while (keeptrying)
            {
                await Task.Delay((result.ApiRateLimit.Reset + 1) * 1000); //Reset is in seconds
                result = await Decorated.Invoke(Dto);
                attempts--;
                keeptrying = tryAgain(result, attempts);
            }
            return result;
        }
    }
}
