
namespace Automation.Domain.Services;

public class MailAttachmentService : IMailAttachmentService
{
    private readonly IMailAttachmentRepository _mailAttachmentRepository;
    private readonly IMailRepository _mailRepository;
    private readonly IAttachmentRepository _attachmentRepository;
    public MailAttachmentService(IMailAttachmentRepository mailAttachmentRepository, IMailRepository mailRepository, IAttachmentRepository attachmentRepository) 
    {
        _mailAttachmentRepository = mailAttachmentRepository;
        _mailRepository = mailRepository;
        _attachmentRepository = attachmentRepository;
    }

    public async Task AddMailAttachmentAsync(Guid mailId,  Guid attachmentId)
    {
        var mail = await _mailRepository.GetMailByIdAsync(mailId);
        var attachment = await _attachmentRepository.GetById(attachmentId);

        await _mailAttachmentRepository.AddMailAttachmentAsync(mailId, mail!, attachmentId, attachment!);
    }

    public async Task<ApiResponse<List<AttachmentResDto>>> GetMailAttachmentsAsync(Guid mailId)
    {
        var mailAttachments = await _mailAttachmentRepository.GetByMailIdAsync(mailId);
        var attachments = new List<AttachmentResDto>();
        foreach (var mailAttachment in mailAttachments)
        {
            var attachment = await _attachmentRepository.GetById(mailAttachment.AttachmentId);
            attachments.Add(new AttachmentResDto
            {
                Id = attachment!.Id,
                Name = attachment.Name,
                MimeType = attachment.MimeType,
                CreatedOn = attachment.CreatedOn,
                CreatedBy = attachment.CreatedBy,
                IsDeleted = attachment.IsDeleted,
                DeletedBy = attachment.DeletedBy
            });
        }
        return new ApiResponse<List<AttachmentResDto>>(attachments);
    }
}
