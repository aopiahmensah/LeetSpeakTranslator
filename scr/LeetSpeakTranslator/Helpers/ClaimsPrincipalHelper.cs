using LST.Service.Messaging.Authentication.Response;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace LeetSpeakTranslator.Helpers
{
    public static class ClaimsPrincipalHelper
    {
        public static ClaimsPrincipal SetClaimsPrincipalDetails(LoginResponse response)
        {
            var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
            identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, response.FirstName!));
            identity.AddClaim(new Claim(ClaimTypes.Name, response.LastName!));
            identity.AddClaim(new Claim(ClaimTypes.GivenName, response.Username!));

            return new ClaimsPrincipal(identity);
        }
    }
}
