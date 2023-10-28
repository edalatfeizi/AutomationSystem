
namespace Automation.Domain.Services;

public class DepartmentService : IDepartmentService
{
    private readonly IDepartmentRepository _repo;
    public DepartmentService(IDepartmentRepository departmentRepository)
    {
        _repo = departmentRepository;
    }
    public async Task<ApiResponse<DepartmentResDto>> AddDepartment(DepartmentAddReqDto dto)
    {
        var department = await _repo.AddDepartment(dto.Name, dto.Description, dto.ParentId);
        var data = new DepartmentResDto
        {
            Id = department.Id,
            Name = dto.Name,
            Description = dto.Description,
            ParentId = dto.ParentId,
            IsActive = department.IsActive
        };

        return new ApiResponse<DepartmentResDto>(data);

    }

    public async Task<ApiResponse<bool?>> DeleteDepartment(Guid id)
    {
        var isDeleted = await _repo.DeleteDepartment(id);
        if (isDeleted == null)
            return new ApiResponse<bool?>((int)HttpStatusCode.NotFound, ResponseMessages.DepartmentNotFound);
    
        return new ApiResponse<bool?>(isDeleted);
    
    }

    public async Task<ApiResponse<List<DepartmentResDto>>> GetAllDepartments()
    {
        var departments = await _repo.GetAllDepartments();

        var data = departments.Select(x => new  DepartmentResDto
        {
            Id=x.Id,
            Name = x.Name,
            Description = x.Description,
            ParentId = x.ParentId,
            IsActive = x.IsActive
        }).ToList();

        return new ApiResponse<List<DepartmentResDto>>(data);
    }

    public async Task<ApiResponse<DepartmentResDto>> GetDepartmentById(Guid id)
    {
        var department = await _repo.GetDepartmentById(id);
        if (department == null)
            return new ApiResponse<DepartmentResDto>((int)HttpStatusCode.NotFound, ResponseMessages.DepartmentNotFound);

        var data = new DepartmentResDto
        {
            Id = department.Id,
            Name = department.Name,
            Description = department.Description,
            ParentId = department.ParentId,
            IsActive = department.IsActive
        };

        return new ApiResponse<DepartmentResDto>(data);
    }

    public async Task<ApiResponse<DepartmentResDto>> UpdateDepartment(Guid id, DepartmentUpdateReqDto dto)
    {
        var department = await _repo.UpdateDepartment(id,dto.Name,dto.Description,dto.IsActive,dto.ParentId);
        if (department == null)
            return new ApiResponse<DepartmentResDto>((int)HttpStatusCode.NotFound, ResponseMessages.DepartmentNotFound);

        var data = new DepartmentResDto
        {
            Id = department.Id,
            Name = department.Name,
            Description = department.Description,
            ParentId = department.ParentId,
            IsActive = department.IsActive
        };

        return new ApiResponse<DepartmentResDto>(data);
    }
}
