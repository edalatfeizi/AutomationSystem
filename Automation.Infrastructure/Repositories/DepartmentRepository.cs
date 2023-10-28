
namespace Automation.Infrastructure.Repositories;

public class DepartmentRepository : IDepartmentRepository
{
    private readonly AutomationDbContext _context;
    public DepartmentRepository(AutomationDbContext context)
    {
        _context = context;

    }
    public async Task<Department> AddDepartment(string name, string description, Guid? parentId)
    {
        var department = new Department
        {
            Name = name,
            Description = description,
            ParentId = parentId
        };

        await _context.Departments.AddAsync(department);
        await _context.SaveChangesAsync();

        return department;
    }

    public async Task<bool?> DeleteDepartment(Guid id)
    {
        var department = await _context.Departments.FirstOrDefaultAsync(x => x.Id == id);
        if (department == null)
            return null;

        department.IsActive = false;
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<List<Department>> GetAllDepartments()
    {
        var departments = await _context.Departments.Where(x => x.IsActive == true).ToListAsync();
        return departments;
    }

    public async Task<Department?> GetDepartmentById(Guid id)
    {
        var department = await _context.Departments.FindAsync(id);

        return department;
    }

    public async Task<Department?> UpdateDepartment(Guid id, string name, string description, bool isActive, Guid? parentId)
    {
        var department = await _context.Departments.FindAsync(id);
        if (department == null)
            return null;

        department.Name = name;
        department.Description = description;
        department.IsActive = isActive;
        department.ParentId = parentId;

        await _context.SaveChangesAsync();
        return department;
    }


}
