using LST.Infrastructure.Messaging;
using LST.Service.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LST.Service.Messaging
{
    public class ViewApiRequestsResponse : ResponseBase
    {
        public ICollection<ApiRequestView>? ApiRequestViews { get; set; }
    }
    public class ViewApiResponse : ResponseBase
    {
        public ICollection<ApiResponseView>? ApiResponseViews { get; set; }
    }
}
