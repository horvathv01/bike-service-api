using System.Security.Claims;
using System.Text.Encodings.Web;
using BikeServiceAPI.Models.Entities;
using BikeServiceAPI.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;

namespace BikeServiceAPI.Auth
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly IUserService _userService;
        public BasicAuthenticationHandler(IOptionsMonitor<AuthenticationSchemeOptions> options, 
            ILoggerFactory logger, 
            UrlEncoder encoder, 
            ISystemClock clock,
            IUserService userService) : base(options, logger, encoder, clock)
        {
            _userService = userService;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            var endpoint = Context.GetEndpoint();
            if (endpoint?.Metadata?.GetMetadata<IAllowAnonymous>() != null || endpoint?.Metadata?.GetMetadata<AuthorizeWithTokenAttribute>() != null)
            {
                return AuthenticateResult.NoResult();
            }

            if (!Request.Headers.ContainsKey("Authorization"))
            {
                return AuthenticateResult.Fail("Missing authorization header");
            }

            var authorizationHeader = Request.Headers.Authorization.ToString();
            var userInfoDecoded =
                System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String(authorizationHeader));
            string userName = userInfoDecoded.Split(":")[0];
            string password = userInfoDecoded.Split(":")[1];

            User? user = await _userService.GetUserByName(userName);
            if (user == null || HashPasswords.HashPassword(password) != user.Password)
            {
                return AuthenticateResult.Fail("Incorrect username or password!");
            }

            var claims = new List<Claim>();
            foreach (var userRole in user.Roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, userRole.ToString()));
            }
            claims.Add(new Claim(ClaimTypes.Name, userName));
            claims.Add(new Claim("DatabaseID", user.Id.ToString()));

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, CookieAuthenticationDefaults.AuthenticationScheme);
            await Context.SignInAsync(principal);
            Console.WriteLine($"User login: {userName}");
            return AuthenticateResult.Success(ticket);
            
        }
    }
}