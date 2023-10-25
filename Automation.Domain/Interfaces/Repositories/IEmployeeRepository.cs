
namespace Automation.Domain.Interfaces.Repositories;

public interface IEmployeeRepository
{
    Task<Employee?> GetById(Guid id);
    Task<List<Employee>> GetAll();
    Task<Employee> AddEmployee(Department department, string firstName, string lastName, string role, string email);
    Task<Employee?> UpdateEmployee(Guid id, string firstName, string lastName, string role, string email, bool isActive);
    Task<bool?> DeleteEmployee(Guid id);
}
