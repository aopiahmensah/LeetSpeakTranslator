using LST.Model.Model.Api;
using LST.Repository.EF.All;
using Microsoft.EntityFrameworkCore.Storage.Json;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace LST.Service.Common
{
    public abstract class ServiceBase(LSTContext context, IHttpClientFactory httpClient,
        IConfiguration configuration, ILogger<ServiceBase> logger)
    {
        protected readonly IConfiguration _configuration = configuration;
        protected readonly ILogger<ServiceBase> _logger = logger;
        protected readonly LSTContext _context = context;
        protected readonly IHttpClientFactory _httpClient = httpClient;

        //this method is responsible for connecting to the api
        protected async Task<ApiResponseView> ConnectToApi(ApiRequest apiRequest)
        {
            string url = "https://api.funtranslations.com/translate/yoda.json";
            object postParams = "";
            ApiResponseView? apiResponseView = new();
            var client = _httpClient.CreateClient();
            if(client is null)
                client = new HttpClient();

            postParams = new
            {
                text = apiRequest.Text,
            };

            string postParamsJson = JsonConvert.SerializeObject(postParams);

            var request = new HttpRequestMessage(HttpMethod.Post, url)
            {
                Content = new StringContent(postParamsJson, Encoding.UTF8, "application/json")
            };

            try
            {
                HttpResponseMessage response = await client.SendAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    apiResponseView = await response.Content.ReadFromJsonAsync<ApiResponseView>();
                    apiResponseView!.JSONResponse = await response.Content.ReadAsStringAsync();
                    apiResponseView!.MessageInfo.MessageType = Infrastructure.Messaging.MessageType.Success;
                    _logger.LogInformation("Operation successful.");
                }
                else
                {
                    _logger.LogError("Operation was not successful.");
                    apiResponseView.MessageInfo.MessageType = Infrastructure.Messaging.MessageType.Error;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, "Operation was not successful.");
                apiResponseView!.MessageInfo.MessageType = Infrastructure.Messaging.MessageType.Error;
            }

            return apiResponseView!;
        }
    }
}
