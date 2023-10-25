
namespace Automation.Infrastructure.Repositories;

public class EmployeeDepartmentRepository : IEmployeeDepartmentRepository
{
    private readonly AutomationDbContext _context;
    public EmployeeDepartmentRepository(AutomationDbContext context)
    {
        _context = context;

    }

    public async Task<EmployeeDepartment?> GetByEmployeeId(Guid id)
    {
        var employeeDepartment = await _context.EmployeeDepartments.Where(x => x.EmployeeId == id).FirstOrDefaultAsync();
        if (employeeDepartment == null)
            return null;

        return employeeDepartment;
    }

}
