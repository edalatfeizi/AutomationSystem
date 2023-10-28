

namespace Automation.Domain.Dtos.Request.Department;

public class DepartmentUpdateReqDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public Guid? ParentId { get; set; }
    public bool IsActive { get; set; }
}
