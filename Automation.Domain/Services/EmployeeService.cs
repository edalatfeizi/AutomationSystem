

namespace Automation.Domain.Services;

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _repo;
    private readonly IEmployeeDepartmentRepository _employeeDepartmentRepo;
    private readonly IDepartmentRepository _departmentRepo;
    public EmployeeService(IEmployeeRepository employeeRepository, IEmployeeDepartmentRepository employeeDepartmentRepo, IDepartmentRepository departmentRepository)
    {
        _repo = employeeRepository;
        _employeeDepartmentRepo = employeeDepartmentRepo;
        _departmentRepo = departmentRepository;
    }


    public async Task<ApiResponse<EmployeeResDto?>> AddEmployee(Guid departmentId, EmployeeAddReqDto dto)
    {
        var department = await _departmentRepo.GetDepartmentById(departmentId);
        if(department == null)
            return new ApiResponse<EmployeeResDto?>((int)HttpStatusCode.NotFound, ResponseMessages.DepartmentNotFound);

        var employee = await _repo.AddEmployee(department, dto.FirstName, dto.LastName, dto.Role, dto.Email);

        var data = new EmployeeResDto
        {
            Id = employee.Id,
            DepartmentId = departmentId,
            FirstName = employee.FirstName,
            LastName = employee.LastName,
            Role = employee.Role,
            Email = employee.Email,
            IsActive = employee.IsActive,
            CreatedOn = employee.CreatedOn
        };

        return new ApiResponse<EmployeeResDto?>(data);
    }

    public async Task<ApiResponse<bool?>> DeleteEmployee(Guid id)
    {
        var isDeleted = await _repo.DeleteEmployee(id);
        if (isDeleted == null)
            return new ApiResponse<bool?>((int)HttpStatusCode.NotFound, ResponseMessages.EmployeeNotFound);

        return new ApiResponse<bool?>(isDeleted);
    }

    public async Task<ApiResponse<List<EmployeeResDto>>> GetAll()
    {
        var employees = await _repo.GetAll();
        var data = new List<EmployeeResDto>();

        foreach (var employee in employees)
        {
            var employeeDepartment = await _employeeDepartmentRepo.GetByEmployeeId(employee.Id);
            var resDto = new EmployeeResDto
            {
                Id = employee.Id,
                DepartmentId = employeeDepartment!.DepartmentId,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Role = employee.Role,
                Email = employee.Email,
                CreatedOn = employee.CreatedOn,
                IsActive = employee.IsActive
            };
            data.Add(resDto);
        }


        return new ApiResponse<List<EmployeeResDto>>(data);
    }

    public async Task<ApiResponse<EmployeeResDto?>> GetById(Guid id)
    {
        var employee = await _repo.GetById(id);
        if (employee == null)
            return new ApiResponse<EmployeeResDto?>((int)HttpStatusCode.NotFound, ResponseMessages.EmployeeNotFound);

        var employeeDepartment = await _employeeDepartmentRepo.GetByEmployeeId(employee.Id);

        var data = new EmployeeResDto
        {
            Id = employee.Id,
            DepartmentId = employeeDepartment!.DepartmentId,
            FirstName = employee.FirstName,
            LastName = employee.LastName,
            Role = employee.Role,
            Email = employee.Email,
            CreatedOn = employee.CreatedOn,
            IsActive = employee.IsActive
        };

        return new ApiResponse<EmployeeResDto?>(data);
    }

    public async Task<ApiResponse<EmployeeResDto?>> UpdateEmployee(Guid id, EmployeeUpdateReqDto dto)
    {
        var employee = await _repo.UpdateEmployee(id, dto.FirstName, dto.LastName, dto.Role, dto.Email, dto.IsActive);
        if (employee == null)
            return new ApiResponse<EmployeeResDto?>((int)HttpStatusCode.NotFound, ResponseMessages.EmployeeNotFound);

        var data = new EmployeeResDto
        {
            Id = employee.Id,
            FirstName = employee.FirstName,
            LastName = employee.LastName,
            Role = employee.Role,
            Email = employee.Email,
            CreatedOn = employee.CreatedOn,
            IsActive = employee.IsActive
        };

        return new ApiResponse<EmployeeResDto?>(data);
    }
}
