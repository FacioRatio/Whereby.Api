using FacioRatio.CSharpRailway;
using ServiceStack;

namespace FacioRatio.Whereby.Api
{
    public static class ServiceStackStringExtensions
    {
        public static Result<string> GetJsonResultFromUrl(this string url, Action<HttpRequestMessage> requestFilter = null, Action<HttpResponseMessage> responseFilter = null)
        {
            try
            {
                var result = url.GetJsonFromUrl(requestFilter, responseFilter);
                return result == null
                    ? Result.Fail<string>(new EmptyServiceStackResponseException("Json not found at url."))
                    : Result.Ok(result);
            }
            catch (Exception ex)
            {
                return Result.Fail<string>(ex);
            }
        }

        public static async Task<Result<string>> GetJsonResultFromUrlAsync(this string url, Action<HttpRequestMessage> requestFilter = null, Action<HttpResponseMessage> responseFilter = null)
        {
            try
            {
                var result = await url.GetJsonFromUrlAsync(requestFilter, responseFilter);
                return result == null
                    ? Result.Fail<string>(new EmptyServiceStackResponseException("Json not found at url."))
                    : Result.Ok(result);
            }
            catch (Exception ex)
            {
                return Result.Fail<string>(ex);
            }
        }

        public static Result<string> GetStringResultFromUrl(this string url, string accept = "*/*", Action<HttpRequestMessage> requestFilter = null, Action<HttpResponseMessage> responseFilter = null)
        {
            try
            {
                var result = url.GetStringFromUrl(accept, requestFilter, responseFilter);
                return result == null
                    ? Result.Fail<string>(new EmptyServiceStackResponseException("String not found at url."))
                    : Result.Ok(result);
            }
            catch (Exception ex)
            {
                return Result.Fail<string>(ex);
            }
        }

        public static async Task<Result<string>> GetStringResultFromUrlAsync(this string url, string accept = "*/*", Action<HttpRequestMessage> requestFilter = null, Action<HttpResponseMessage> responseFilter = null)
        {
            try
            {
                var result = await url.GetStringFromUrlAsync(accept, requestFilter, responseFilter);
                return result == null
                    ? Result.Fail<string>(new EmptyServiceStackResponseException("String not found at url."))
                    : Result.Ok(result);
            }
            catch (Exception ex)
            {
                return Result.Fail<string>(ex);
            }
        }

        public static Result<string> PostJsonToResultUrl(this string url, object data, Action<HttpRequestMessage> requestFilter = null, Action<HttpResponseMessage> responseFilter = null)
        {
            try
            {
                var result = url.PostJsonToUrl(data, requestFilter, responseFilter);
                return result == null
                    ? Result.Fail<string>(new EmptyServiceStackResponseException("Json posted to url, but received null response."))
                    : Result.Ok(result);
            }
            catch (Exception ex)
            {
                return Result.Fail<string>(ex);
            }
        }

        public static async Task<Result<string>> PostJsonToResultUrlAsync(this string url, object data, Action<HttpRequestMessage> requestFilter = null, Action<HttpResponseMessage> responseFilter = null)
        {
            try
            {
                var result = await url.PostJsonToUrlAsync(data, requestFilter, responseFilter);
                return result == null
                    ? Result.Fail<string>(new EmptyServiceStackResponseException("Json posted to url, but received null response."))
                    : Result.Ok(result);
            }
            catch (Exception ex)
            {
                return Result.Fail<string>(ex);
            }
        }

        public static Result<string> PostStringToResultUrl(this string url, string requestBody = null, string contentType = null, string accept = "*/*", Action<HttpRequestMessage> requestFilter = null, Action<HttpResponseMessage> responseFilter = null)
        {
            try
            {
                var result = url.PostStringToUrl(requestBody, contentType, accept, requestFilter, responseFilter);
                return result == null
                    ? Result.Fail<string>(new EmptyServiceStackResponseException("String posted to url, but received null response."))
                    : Result.Ok(result);
            }
            catch (Exception ex)
            {
                return Result.Fail<string>(ex);
            }
        }

        public static async Task<Result<string>> PostStringToResultUrlAsync(this string url, string requestBody = null, string contentType = null, string accept = "*/*", Action<HttpRequestMessage> requestFilter = null, Action<HttpResponseMessage> responseFilter = null)
        {
            try
            {
                var result = await url.PostStringToUrlAsync(requestBody, contentType, accept, requestFilter, responseFilter);
                return result == null
                    ? Result.Fail<string>(new EmptyServiceStackResponseException("String posted to url, but received null response."))
                    : Result.Ok(result);
            }
            catch (Exception ex)
            {
                return Result.Fail<string>(ex);
            }
        }

        public static Result<string> PostToResultUrl(this string url, string formData, string accept, Action<HttpRequestMessage> requestFilter = null, Action<HttpResponseMessage> responseFilter = null)
        {
            try
            {
                var result = url.PostToUrl(formData, accept, requestFilter, responseFilter);
                return result == null
                    ? Result.Fail<string>(new EmptyServiceStackResponseException("Form posted to url, but received null response."))
                    : Result.Ok(result);
            }
            catch (Exception ex)
            {
                return Result.Fail<string>(ex);
            }
        }

        public static async Task<Result<string>> PostToResultUrlAsync(this string url, string formData, string accept, Action<HttpRequestMessage> requestFilter = null, Action<HttpResponseMessage> responseFilter = null)
        {
            try
            {
                var result = await url.PostToUrlAsync(formData, accept, requestFilter, responseFilter);
                return result == null
                    ? Result.Fail<string>(new EmptyServiceStackResponseException("Form posted to url, but received null response."))
                    : Result.Ok(result);
            }
            catch (Exception ex)
            {
                return Result.Fail<string>(ex);
            }
        }
    }
}
