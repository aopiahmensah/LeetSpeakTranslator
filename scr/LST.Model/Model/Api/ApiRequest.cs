using LST.Infrastructure.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LST.Model.Model.Api
{
    public class ApiRequest : EntityBase
    {
        public string? RequestId { get; set; }
        public string? Text { get; set; }

        public int? ApiResponseId { get; set; }
        public virtual ApiResponse? ApiResponse { get; set; }
    }
}
