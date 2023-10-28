using System.IdentityModel.Tokens.Jwt;

namespace Automation.API.Extensions
{
    public static class HttpContextExtensions
    {
        public static Guid GetUserId(this HttpContext context)
        {
            var identity = context.User.Identities.First();
            var userId = Guid.Parse(identity.Claims.Where(x => x.Type == "Id").First().Value!.ToString());
            return userId;
        }
        public static string GetUserEmail(this HttpContext context)
        {
            var identity = context.User.Identities.First();
            var email = identity.Claims.Where(x => x.Type.Contains("emailaddress")).First().Value.ToString();
            return email;
        }
    }
}
