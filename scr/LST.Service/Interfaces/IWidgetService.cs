using LST.Service.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LST.Service.Interfaces
{
    public interface IWidgetService
    {
        Task<List<ApiRequestView>> GetApiRequests();
        Task<List<ApiResponseView>> GetApiResponses();
    }
}
