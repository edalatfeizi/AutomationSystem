
namespace Automation.Domain.Interfaces.Repositories;

public interface IEmployeeDepartmentRepository
{
    Task<EmployeeDepartment?> GetByEmployeeId(Guid id);
}
