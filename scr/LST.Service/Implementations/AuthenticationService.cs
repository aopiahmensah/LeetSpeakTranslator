using LST.Model.Model;
using LST.Model.Model.IRepository;
using LST.Repository.EF.All;
using LST.Service.Common;
using LST.Service.Interfaces;
using LST.Service.Messaging.Authentication.Request;
using LST.Service.Messaging.Authentication.Response;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LST.Service.Implementations
{
    public class AuthenticationService : ServiceBase, IAuthenticationService
    {
        private readonly IUserRepository _userRepository;
        public AuthenticationService(LSTContext context, IHttpClientFactory httpClient, IConfiguration configuration, ILogger<ServiceBase> logger,IUserRepository userRepository) 
            : base(context, httpClient, configuration, logger)
        {
            _userRepository = userRepository;
        }

        public async Task<LoginResponse> LoginUserAsync(LoginRequest request)
        {
            LoginResponse response = new();
            //pulls user details using the supplied username and password
            var user = await _userRepository.GetDbSet().Where(s => s.Username!.ToLower() == request.Username && s.Password == request.Password).FirstOrDefaultAsync();
            if (user == null)
            {
                
                response.MessageInfo.Message = "Invalid username or password!";
                response.MessageInfo.MessageType = Infrastructure.Messaging.MessageType.BusinessValidationError;
            }
            else
            {
                response.IsAuthenticated = true;
                response.FirstName = user.FirstName;
                response.LastName = user.LastName;
                response.MiddleName = user.MiddleName;
                response.Username = user.Username;
            }

            return response;
        }
    }
}
