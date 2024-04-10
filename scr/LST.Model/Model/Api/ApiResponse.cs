using LST.Infrastructure.Domain;
using LST.Infrastructure.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LST.Model.Model.Api
{
    public class ApiResponse : EntityBase
    {
        public string? JSONResponse { get; set; }
        public string? Text { get; set; }
        public string? Translation { get; set; }
        public string? Translated { get; set; }
        public int? Total { get; set; }
    }

    public class ApiResponseView : ResponseBase
    {
        public ApiResponseView()
        {
            success = new();
            contents = new();
        }

        public Success? success { get; set; }
        public Content? contents { get; set; }
        public string? JSONResponse { get; set; }
    }

    public class Success
    {
        public int total { get; set; }

    }

    public class Content
    {
        public string? text { get; set; }
        public string? translation { get; set; }
        public string? translated { get; set; }
    }
}
