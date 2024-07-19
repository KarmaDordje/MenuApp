namespace Recipe.Infrastructure.External
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Recipe.Application.ApiModels;
    using Recipe.Application.Interfaces;
    using RestSharp;

    public class DeepLApiClient : GenericApiClient, IDeepLClient
    {

        public DeepLApiClient(string baseUrl, string apiKey, string headerName)
            : base(baseUrl, apiKey, headerName) { }
        public async Task<string> Translate(DeepLTranslationRequest request)
        {
            var result = await Request<DeepLTranslateResponse>(() => new RestRequest("v2/translate", Method.Post).AddJsonBody(request));
            return result.Translations?.FirstOrDefault().Text;
        }
    }
}
