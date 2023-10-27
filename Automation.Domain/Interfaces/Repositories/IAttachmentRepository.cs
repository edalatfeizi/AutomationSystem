using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Domain.Interfaces.Repositories;

public interface IAttachmentRepository
{
    Task<Attachment?> GetById(Guid id);
    Task<Attachment?> GetByCreatorId(Guid creatorUserId);
    Task<Attachment> AddAttachment(Attachment attachment);
    Task<bool?> DeleteAttachment(Guid deletedByUserId, Guid attachmentId);
}
