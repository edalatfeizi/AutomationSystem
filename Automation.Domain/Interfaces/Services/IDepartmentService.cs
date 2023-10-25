
namespace Automation.Domain.Interfaces.Services;

public interface IDepartmentService
{
    Task<ApiResponse<DepartmentResDto>> GetDepartmentById(Guid id);
    Task<ApiResponse<List<DepartmentResDto>>> GetAllDepartments();
    Task<ApiResponse<DepartmentResDto>> AddDepartment(DepartmentAddReqDto dto);
    Task<ApiResponse<DepartmentResDto>> UpdateDepartment(Guid id, DepartmentUpdateReqDto dto);
    Task<ApiResponse<bool?>> DeleteDepartment(Guid id);
}
