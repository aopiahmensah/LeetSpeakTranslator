using LST.Infrastructure.Messaging;
using LST.Model.Model.Api;
using LST.Model.Model.Messaging;
using LST.Service.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LST.Service.Interfaces
{
    public interface ITransactionService
    {
        Task<Model.Model.Api.ApiResponseView> SubmitQuery(SubmitQueryRequest request);
        Task<Model.Model.Api.ApiResponseView> UnitTestQuery(SubmitQueryRequest request);
    }
}
