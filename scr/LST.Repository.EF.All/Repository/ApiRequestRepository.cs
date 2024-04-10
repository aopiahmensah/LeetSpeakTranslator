using LST.Model.Model.Api;
using LST.Model.Model.IRepository;
using LST.Repository.EF.All.Common;
using Microsoft.EntityFrameworkCore;

namespace LST.Repository.EF.All.Repository
{
    public class ApiRequestRepository : Repository<ApiRequest, int>, IApiRequestRepository
    {
        public ApiRequestRepository(LSTContext context) : base(context)
        {
        }

        public async Task<List<ApiRequest>> GetAllApiRequest()
        {
            // Execute stored procedure and retrieve records
            var records = await ctx.ApiRequests.FromSqlRaw("EXEC GetAllApiRequests").ToListAsync();

            return records;
        }

        public override string GetEntitySetName()
        {
            return "ApiRequest";
        }
    }

    public class ApiResponseRepository : Repository<ApiResponse, int>, IApiResponseRepository
    {
        public ApiResponseRepository(LSTContext context) : base(context)
        {
        }

        public async Task<List<ApiResponse>> GetAllApiResponse()
        {
            // Execute stored procedure and retrieve records
            var records = await ctx.ApiResponses.FromSqlRaw("EXEC GetAllApiResponse").ToListAsync();

            return records;
        }

        public override string GetEntitySetName()
        {
            return "ApiResponse";
        }
    }
}
