
namespace Automation.API.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class EmployeesController : ControllerBase
{
    private readonly IEmployeeService _service;
    private readonly IAccountService _accountService;
    public EmployeesController(IEmployeeService service, IAccountService accountService)
    {
        _service = service;
        _accountService = accountService;
    }

    [HttpPost]
    [ProducesResponseType((int) HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(ApiResponse<EmployeeResDto>),(int)HttpStatusCode.OK)]
    public async Task<IActionResult> AddEmployee([FromQuery] Guid departmentId, [FromBody] EmployeeAddReqDto dto)
    {
        var result = await _service.AddEmployee(departmentId, dto);
        var user = await _accountService.RegisterAsync(new UserRegisterReqDto { Email = dto.Email, Password = "Passw0rd@1" });
        return Ok(result);
    }

    [HttpGet("all")]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(ApiResponse<List<EmployeeResDto>>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetAllEmployees()
    {
        var employees = await _service.GetAll();
        return Ok(employees);
    }

    [HttpGet("{id}")]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(ApiResponse<EmployeeResDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetEmployeeById(Guid id)
    {
        var employee = await _service.GetById(id);
        return Ok(employee);
    }
    
    [HttpPut("{id}")]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(ApiResponse<EmployeeResDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> UpdateEmployee(Guid id, [FromBody] EmployeeUpdateReqDto dto)
    {
        var employee = await _service.UpdateEmployee(id, dto);
        return Ok(employee);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    [ProducesResponseType(typeof(ApiResponse<EmployeeResDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> DeleteEmployee(Guid id)
    {
        var employee = await _service.DeleteEmployee(id);
        return Ok(employee);
    }


}
