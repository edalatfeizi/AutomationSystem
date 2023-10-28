
namespace Automation.API.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
[Authorize]
public class DepartmentsController : ControllerBase
{
    private readonly IDepartmentService _service;
    public DepartmentsController(IDepartmentService service)
    {
        _service = service;
    }

    [HttpPost]
    [ProducesResponseType((int) HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(ApiResponse<DepartmentResDto>),(int)HttpStatusCode.OK)]
    public async Task<IActionResult> AddDepartment([FromBody] DepartmentAddReqDto dto)
    {
        var result = await _service.AddDepartment(dto);
        return Ok(result);
    }

    [HttpGet("all")]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(ApiResponse<List<DepartmentResDto>>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetAllDepartments()
    {
        var departments = await _service.GetAllDepartments();
        return Ok(departments);
    }

    [HttpGet("{id}")]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(ApiResponse<DepartmentResDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetDepartmentById(Guid id)
    {
        var department = await _service.GetDepartmentById(id);
        return Ok(department);
    }
    
    [HttpPut("{id}")]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(ApiResponse<DepartmentResDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> UpdateDepartment(Guid id, [FromBody] DepartmentUpdateReqDto dto)
    {
        var department = await _service.UpdateDepartment(id, dto);
        return Ok(department);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(ApiResponse<DepartmentResDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> DeleteDepartment(Guid id)
    {
        var department = await _service.DeleteDepartment(id);
        return Ok(department);
    }


}
