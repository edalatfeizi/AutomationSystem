

namespace Automation.Domain.Services;

public class MailService : IMailService
{
    private readonly IMailRepository _mailRepository;
    public MailService(IMailRepository mailRepository)
    {
        _mailRepository = mailRepository;
    }
    public async Task<ApiResponse<MailResDto>> AddMailAsync(MailAddReqDto dto)
    {
        var newMailNumber = await _mailRepository.GetLastMailNumberAsync() + 1;
        Mail? repliedToMail = null;
        Mail? forwardedFromMail = null;

        if (dto.RepliedTo != null)
            repliedToMail = await _mailRepository.GetMailByIdAsync((Guid)dto.RepliedTo);

        if (dto.ForwardedFrom != null)
            forwardedFromMail = await _mailRepository.GetMailByIdAsync((Guid)dto.ForwardedFrom);

        var mail = new Mail
        {
            MailNumber = newMailNumber,
            From = dto.From,
            To = dto.To,
            Subject = dto.Subject,
            Body = dto.Body,
            ImediacyType = dto.ImediacyType,
            ClassificationType = dto.ClassificationType,
            MailStatus = MailStatus.UnRead,
            MailType = dto.MailType,
            RepliedTo = dto.RepliedTo,
            RepliedToMail = repliedToMail,
            ForwardedFrom = dto.ForwardedFrom,
            ForwardedFromMail = forwardedFromMail,
            Description = dto.Description
        };

        var result = await _mailRepository.AddMailAsync(mail);
        var mailResponse = GetMailResponse(result);

        return new ApiResponse<MailResDto>(mailResponse);
    }

    public async Task<ApiResponse<bool>> DeleteMailAsync(Guid mailId, Guid deletedByUserId)
    {
        var mail = await _mailRepository.GetMailByIdAsync(mailId);
        if (mail == null)
            return new ApiResponse<bool>((int)HttpStatusCode.NotFound, ResponseMessages.MailNotFound);

        var result = await _mailRepository.DeleteMailAsync(mailId, deletedByUserId);
        return new ApiResponse<bool>(result);
    }

    public async Task<ApiResponse<List<MailResDto>>> FilterMailsAsync(FilterMailsReqDto dto)
    {
        var mails = await _mailRepository.FilterMailsAsync(dto.MailNumber, dto.From, dto.To, dto.Subject, dto.Body, dto.ImediacyType, dto.ClassificationType, dto.MailStatus, dto.MailType, dto.FromDate, dto.ToDate);
        var result = mails.Select(x => GetMailResponse(x)).ToList();

        return new ApiResponse<List<MailResDto>>(result);
    }

    public async Task<ApiResponse<MailResDto?>> GetMailByIdAsync(Guid mailId)
    {
        var mail = await _mailRepository.GetMailByIdAsync(mailId);
        if (mail == null)
            return new ApiResponse<MailResDto?>((int)HttpStatusCode.NotFound, ResponseMessages.MailNotFound);

        var result = GetMailResponse(mail);
        return new ApiResponse<MailResDto?>(result);
    }


    private MailResDto GetMailResponse(Mail mail)
    {
        return new MailResDto
        {
            Id = mail.Id,
            MailNumber = mail.MailNumber,
            From = mail.From,
            To = mail.To,
            Subject = mail.Subject,
            Body = mail.Body,
            ImediacyType = mail.ImediacyType,
            ClassificationType = mail.ClassificationType,
            MailStatus = mail.MailStatus,
            MailType = mail.MailType,
            RepliedTo = mail.RepliedTo,
            ForwardedFrom = mail.ForwardedFrom,
            CreatedOn = mail.CreatedOn,
            Description = mail.Description
        };
    }
}
