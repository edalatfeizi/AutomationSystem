

namespace Automation.Domain.Interfaces.Services;

public interface IEmployeeService
{
    Task<ApiResponse<EmployeeResDto?>> GetById(Guid id);
    Task<ApiResponse<List<EmployeeResDto>>> GetAll();
    Task<ApiResponse<EmployeeResDto?>> AddEmployee(Guid departmentId, EmployeeAddReqDto dto);
    Task<ApiResponse<EmployeeResDto?>> UpdateEmployee(Guid id, EmployeeUpdateReqDto dto);
    Task<ApiResponse<bool?>> DeleteEmployee(Guid id);
}
