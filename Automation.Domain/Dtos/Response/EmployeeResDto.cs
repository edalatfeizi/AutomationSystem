
namespace Automation.Domain.Dtos.Response;

public record EmployeeResDto
{
    public Guid Id { get; set; }
    public Guid? DepartmentId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Role { get; set; }
    public string Email { get; set; }
    public DateTime CreatedOn { get; set; }
    public bool IsActive { get; set; }
}
