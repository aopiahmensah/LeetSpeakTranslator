using LST.Service.Messaging.Authentication.Request;
using LST.Service.Messaging.Authentication.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LST.Service.Interfaces
{
    public interface IAuthenticationService
    {
        Task<LoginResponse> LoginUserAsync(LoginRequest request);
    }
}
