
namespace Automation.Domain.Entities;

public class EmployeeDepartment
{
    public Guid Id { get; set; }
    public Employee Employee { get; set; }
    public Guid EmployeeId { get; set; }
    public Department Department { get; set; }
    public Guid DepartmentId { get; set; }
}
