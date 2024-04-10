using LST.Service.Views;

namespace LeetSpeakTranslator.Models.ViewModels
{
    public class DashboardViewModel
    {
        public DashboardViewModel()
        {
            ApiRequestView = new List<ApiRequestView>();
            ApiResponseView = new List<ApiResponseView>();
        }

        public List<ApiResponseView> ApiResponseView { get; set; }
        public List<ApiRequestView> ApiRequestView { get; set; }
    }
}
