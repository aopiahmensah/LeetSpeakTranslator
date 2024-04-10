using LST.Infrastructure.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LST.Service.Messaging.Authentication.Response
{
    public class LoginResponse : ResponseBase
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? MiddleName { get; set; }
        public string? Username { get; set; }
        public bool IsAuthenticated { get; set; }
    }
}
