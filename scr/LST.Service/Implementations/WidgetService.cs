using LST.Model.Model.IRepository;
using LST.Repository.EF.All;
using LST.Service.Common;
using LST.Service.Interfaces;
using LST.Service.Views;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LST.Service.Implementations
{
    public class WidgetService : ServiceBase, IWidgetService
    {
        private readonly IApiResponseRepository _responseRepository;
        private readonly IApiRequestRepository _apiRequestRepository;
        public WidgetService(LSTContext context, IHttpClientFactory httpClient, IConfiguration configuration,
            ILogger<ServiceBase> logger, IApiRequestRepository apiRequestRepository, IApiResponseRepository apiResponseRepository)
            : base(context, httpClient, configuration, logger)
        {
            _responseRepository = apiResponseRepository;
            _apiRequestRepository = apiRequestRepository;
        }

        //pulls all api requests into a list
        public async Task<List<ApiRequestView>> GetApiRequests()
        {
            var results = await _apiRequestRepository.GetAllApiRequest();
            var r = results.Select(s => new ApiRequestView
            {
                RequestId = s.RequestId,
                Text = s.Text,
                CreatedOn = s.CreatedOn,
            }).ToList();


            return r;
        }

        //pulls all api response into a list
        public async Task<List<ApiResponseView>> GetApiResponses()
        {
            var results = await _responseRepository.GetAllApiResponse();
            var r = results.Select(s => new ApiResponseView
            {
                JSONResponse = s.JSONResponse,
                Text = s.Text,
                CreatedOn = s.CreatedOn,
                Translated = s.Translated,
                Translation = s.Translation,
            }).ToList();

            return r;
        }
    }
}
