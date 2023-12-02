using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization.Policy;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace SacraLingua.Vocalbulary.IntegrationTests.Setup
{
    public class MockAutorizationPolicy : IPolicyEvaluator
    {
        public virtual async Task<AuthenticateResult> AuthenticateAsync(AuthorizationPolicy policy, HttpContext context)
        {
            var principal = new ClaimsPrincipal();

            principal.AddIdentity(new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Role, "read"),
                new Claim(ClaimTypes.Role, "write")
            }, "Bearer"));

            return await Task.FromResult(AuthenticateResult.Success(new AuthenticationTicket(principal,
             new AuthenticationProperties(), "Bearer")));
        }

        public virtual async Task<PolicyAuthorizationResult> AuthorizeAsync(AuthorizationPolicy policy,
         AuthenticateResult authenticationResult, HttpContext context, object resource)
        {
            return await Task.FromResult(PolicyAuthorizationResult.Success());
        }
    }
}
