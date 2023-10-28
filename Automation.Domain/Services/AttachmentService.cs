
namespace Automation.Domain.Services;

public class AttachmentService : IAttachmentService
{
    private readonly IAttachmentRepository _attachmentRepository;
    public AttachmentService(IAttachmentRepository attachmentRepository)
    {

        _attachmentRepository = attachmentRepository;

    }
    public async Task<Guid> AddAttachment(AttachmentReqDto dto)
    {
        var attachment = new Attachment()
        {
            Name = dto.Name,
            MimeType = dto.MimeType,
            URI = dto.URI,
            CreatedOn = dto.CreatedOn,
            CreatedBy = dto.CreatedBy,
            IsDeleted = dto.IsDeleted,
            DeletedBy = dto.DeletedBy
        };
        await _attachmentRepository.AddAttachment(attachment);

        return attachment.Id;
    }

    public async Task<ApiResponse<bool?>> DeleteAttachment(Guid deletedByUserId, Guid attachmentId)
    {
        var attachment = await _attachmentRepository.DeleteAttachment(deletedByUserId, attachmentId);
        if (attachment == null)
            return new ApiResponse<bool?>((int)HttpStatusCode.NotFound, ResponseMessages.AttachmentNotFound);

        return new ApiResponse<bool?>(true);
    }

    public async Task<ApiResponse<AttachmentResDto?>> GetByCreatorId(Guid creatorUserId)
    {
        var attachment = await _attachmentRepository.GetByCreatorId(creatorUserId);
        if (attachment == null)
            return new ApiResponse<AttachmentResDto?>((int)HttpStatusCode.NotFound, ResponseMessages.AttachmentNotFound);

        
        return new ApiResponse<AttachmentResDto?>(GetAttachmentResponse(attachment));
    }

    public async Task<ApiResponse<AttachmentResDto?>> GetById(Guid id)
    {
        var attachment = await _attachmentRepository.GetById(id);
        if (attachment == null)
            return new ApiResponse<AttachmentResDto?>((int)HttpStatusCode.NotFound, ResponseMessages.AttachmentNotFound);

    
        return new ApiResponse<AttachmentResDto?>(GetAttachmentResponse(attachment));
    }
    private AttachmentResDto GetAttachmentResponse(Attachment attachment)
    {
        return  new AttachmentResDto
        {
            Id = attachment.Id,
            Name = attachment.Name,
            MimeType = attachment.MimeType,
            CreatedOn = attachment.CreatedOn,
            CreatedBy = attachment.CreatedBy,
            IsDeleted = attachment.IsDeleted,
            DeletedBy = attachment.DeletedBy
        };
    }
}
