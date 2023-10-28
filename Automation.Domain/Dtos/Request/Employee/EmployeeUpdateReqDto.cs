

namespace Automation.Domain.Dtos.Request.Employee;

public class EmployeeUpdateReqDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Role { get; set; }
    public string Email { get; set; }
    public bool IsActive { get; set; }
}
