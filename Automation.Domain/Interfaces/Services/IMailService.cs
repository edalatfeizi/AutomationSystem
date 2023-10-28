
namespace Automation.Domain.Interfaces.Services;

public interface IMailService
{
    Task<ApiResponse<MailResDto>> AddMailAsync(MailAddReqDto dto);
    Task<ApiResponse<bool>> DeleteMailAsync(Guid mailId, Guid deletedByUserId);
    Task<ApiResponse<MailResDto?>> GetMailByIdAsync(Guid mailId);
    Task<ApiResponse<List<MailResDto>>> FilterMailsAsync(FilterMailsReqDto dto);
}
