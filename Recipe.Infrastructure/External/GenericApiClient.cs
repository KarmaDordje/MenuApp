namespace Recipe.Infrastructure.External
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using RestSharp;

    public abstract class GenericApiClient
    {
        private readonly string _baseUrl;
        private readonly string _apiKey;
        private readonly string _headerName;

        public GenericApiClient(string baseUrl, string apiKey, string headerName)
        {
            _baseUrl = baseUrl;
            _apiKey = apiKey;
            _headerName = headerName;
        }

        public async Task<T?> Request<T>(Func<RestRequest> compose_request_fn, string url = null) where T : class
        {
            RestClient c = url == null ? new RestClient(_baseUrl) : new RestClient(url);
            var r = compose_request_fn();

            r.AddHeader($"{_headerName}", $"{_apiKey}");

            var response = await c.ExecuteAsync<T>(r);

            int lastDigit = (int)response.StatusCode / 100;
            if (lastDigit == 4 || lastDigit == 5)
            {
                throw new Exception($"Generic client calling endpoint: {response.ResponseUri.AbsoluteUri} encountered error {response.StatusCode}. Message content: {response.Content}");
            }

            if (typeof(T) == typeof(string))
            {

                return response.Content as T;
            }
            else
            {

                return response.Data;
            }

        }
    }
}
