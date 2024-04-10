using LST.Infrastructure.Messaging;
using LST.Model.Model.Api;
using LST.Model.Model.Messaging;
using LST.Repository.EF.All;
using LST.Service.Common;
using LST.Service.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LST.Service.Implementations
{
    public class TransactionService : ServiceBase, ITransactionService
    {
        public TransactionService(LSTContext context, IHttpClientFactory httpClient, IConfiguration configuration, ILogger<ServiceBase> logger) : base(context, httpClient, configuration, logger)
        {
        }
       

        public async Task<ApiResponseView> SubmitQuery(SubmitQueryRequest request)
        {
            
            ApiRequest apiRequest = new ApiRequest
            {
                Text = request.Text,
            };
            var apiResponse = await ConnectToApi(apiRequest);
            if (apiResponse.MessageInfo.MessageType == MessageType.Success)
            {
                //create and save apiRequest and response objects
                ApiRequest apiRequestObj = new ApiRequest
                {
                    Text = request.Text,
                    RequestId = Guid.NewGuid().ToString().Replace("-", ""),
                    CreatedOn = DateTime.Now,
                };

                ApiResponse apiResponseObj = new ApiResponse
                {
                    JSONResponse = apiResponse.JSONResponse,
                    CreatedOn = apiRequestObj.CreatedOn,
                    Text = apiResponse.contents!.text,
                    Translated = apiResponse.contents.translated,
                    Translation = apiResponse.contents.translation,
                    Total = apiResponse.success!.total
                };

                //assign the apiResponse obj to apiRequest.ApiResponse
                apiRequestObj.ApiResponse = apiResponseObj;

                await _context.AddAsync(apiRequestObj);

                await _context.SaveChangesAsync();

               
            }
            else
            {
                apiResponse.MessageInfo.MessageType = MessageType.Error;
            }

            return apiResponse;
        }

        //for testing
        public async Task<ApiResponseView> UnitTestQuery(SubmitQueryRequest request)
        {
            ApiRequest apiRequest = new ApiRequest
            {
                Text = request.Text,
            };
            var apiResponse = await ConnectToApi(apiRequest);

            return apiResponse;
        }
    }
}
