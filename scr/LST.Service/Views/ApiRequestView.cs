using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LST.Service.Views
{
    public class ApiRequestView
    {
        public string? RequestId { get; set; }
        public string? Text { get; set; }
        public DateTime CreatedOn { get; set; }
    }

    public class ApiResponseView
    {
        public string? JSONResponse { get; set; }
        public DateTime CreatedOn { get; set; }
        public string? Text { get; set; }
        public string? Translation { get; set; }
        public string? Translated { get; set; }
    }
}
