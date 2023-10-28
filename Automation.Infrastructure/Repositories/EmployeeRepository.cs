
namespace Automation.Infrastructure.Repositories;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly AutomationDbContext _context;
    public EmployeeRepository(AutomationDbContext context)
    {
        _context = context;

    }
    
    public async Task<Employee> AddEmployee(Department department, string firstName, string lastName, string role, string email)
    {
        var employee = new Employee
        {
            FirstName = firstName,
            LastName = lastName,
            Role = role,
            Email = email
        };
     

        var employeeDepartment = new EmployeeDepartment()
        {
            Employee = employee,
            EmployeeId = employee.Id,
            Department= department,
            DepartmentId = department.Id,
            
        };
        await _context.Employees.AddAsync(employee);
        await _context.EmployeeDepartments.AddAsync(employeeDepartment);

        await _context.SaveChangesAsync();

        return employee;
    }

    public async Task<bool?> DeleteEmployee(Guid id)
    {
        var employee = await _context.Employees.FindAsync(id);
        if (employee == null)
            return null;

        employee.IsActive = false;
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<List<Employee>> GetAll()
    {
        var employees = await _context.Employees.Where(x => x.IsActive == true).ToListAsync();
        return employees;
    }


    public async Task<Employee?> GetById(Guid id)
    {
        var employee = await _context.Employees.FindAsync(id);

        return employee;
    }

    public async Task<Employee?> UpdateEmployee(Guid id, string firstName, string lastName, string role, string email, bool isActive)
    {

        var employee = await _context.Employees.FindAsync(id);
        if (employee == null)
            return null;

        employee.FirstName = firstName;
        employee.LastName = lastName;
        employee.Role = role;
        employee.Email = email;
        employee.IsActive = isActive;

        await _context.SaveChangesAsync();
        return employee;
    }
}
