namespace Automation.API.Extensions
{
    public static class HttpContextExtensions
    {
        public static Guid GetUserId(this HttpContext context)
        {
            var identity = context.User.Identities.First();
            var userId = Guid.Parse(identity.Claims.Where(x => x.Type == "Id").FirstOrDefault().Value!.ToString());
            return userId;
        }
    }
}
