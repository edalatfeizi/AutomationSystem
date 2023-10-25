

namespace Automation.Domain.Dtos.Request.Department;

public class DepartmentAddReqDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public Guid? ParentId { get; set; }
}
