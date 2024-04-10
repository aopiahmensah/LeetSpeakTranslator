using LeetSpeakTranslator.Models;
using LeetSpeakTranslator.Models.ViewModels;
using LST.Infrastructure.Messaging;
using LST.Model.Model.Messaging;
using LST.Service.Interfaces;
using LST.Service.Messaging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LeetSpeakTranslator.Controllers
{
    [Authorize]
    public class HomeController(ITransactionService service,IWidgetService widgetService) : Controller
    {
        private readonly ITransactionService _transactionService = service;
        private readonly IWidgetService _widgetService = widgetService;
        public async Task<IActionResult> Index()
        {
            DashboardViewModel viewModel = new DashboardViewModel();
            ViewApiRequestsResponse response = new ViewApiRequestsResponse();
            ViewApiResponse responseApiResponse = new ViewApiResponse();

            //get list of all api requests and responses
            viewModel.ApiRequestView = await _widgetService.GetApiRequests();
            viewModel.ApiResponseView = await _widgetService.GetApiResponses();
            return View(viewModel);
        }

        public IActionResult SubmitQuery()
        {
            QueryApiViewModel model = new QueryApiViewModel();
            

            return View(model);
        }

        [HttpPost,Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SubmitQuery(QueryApiViewModel model)
        {
            if (ModelState.IsValid)
            {
                SubmitQueryRequest request = new SubmitQueryRequest()
                {
                    Text = model.Text,
                };

                ResponseBase response = await _transactionService.SubmitQuery(request);
                if(response.MessageInfo.MessageType == MessageType.Success)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["ErrorMessage"] = "Error performing transaction.";
                }
            }
            else
            {
                TempData["ErrorMessage"] = "Business validation error.";
            }

            return View(model);
        }
    }
}
