using LST.Infrastructure.Domain;
using LST.Model.Model.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LST.Model.Model.IRepository
{
    public interface IApiRequestRepository : IWriteRepository<ApiRequest, int>
    {
        Task<List<ApiRequest>> GetAllApiRequest();
    }
    public interface IApiResponseRepository : IWriteRepository<ApiResponse, int>
    {
        Task<List<ApiResponse>> GetAllApiResponse();
    }
}
