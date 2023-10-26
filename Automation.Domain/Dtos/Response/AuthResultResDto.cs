
namespace Automation.Domain.Dtos.Response;

public class AuthResultResDto
{
    public string Token { get; set; }
    public string RefreshToken { get; set; }
    public bool Result { get; set; } = false;

}
