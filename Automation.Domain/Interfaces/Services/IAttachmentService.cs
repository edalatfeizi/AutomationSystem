

namespace Automation.Domain.Interfaces.Services;

public interface IAttachmentService 
{
    Task<ApiResponse<AttachmentResDto?>> GetById(Guid id);
    Task<ApiResponse<AttachmentResDto?>> GetByCreatorId(Guid creatorUserId);
    Task<Guid> AddAttachment(AttachmentReqDto dto);
    Task<ApiResponse<bool?>> DeleteAttachment(Guid deletedByUserId, Guid attachmentId);
}
