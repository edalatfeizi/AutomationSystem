
namespace Automation.Domain.Interfaces.Repositories;

public interface IDepartmentRepository
{
    Task<Department?> GetDepartmentById(Guid id);
    Task<List<Department>> GetAllDepartments();
    Task<Department> AddDepartment(string name, string description, Guid? parentId);
    Task<Department?> UpdateDepartment(Guid id, string name, string description, bool isActive, Guid? parentId);
    Task<bool?> DeleteDepartment(Guid id);

}
