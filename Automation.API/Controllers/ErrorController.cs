using Microsoft.AspNetCore.Diagnostics;

namespace Automation.API.Controllers
{
    public class ErrorController : ControllerBase
    {
        private readonly ILogger<ErrorController> _logger;
        public ErrorController(ILogger<ErrorController> logger)
        {

            _logger = logger;

        }
        [Route("/error-dev")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public ActionResult ErrorDev()
        {
            //Get the exception object from the current request context
            Exception? exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
            _logger.LogError(exception ?? new Exception("Exception is null!"), exception?.Message);

            return Problem(title: exception?.InnerException?.Message ?? exception?.Message, statusCode: (int)HttpStatusCode.InternalServerError);
        }

        [Route("/error")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public ActionResult Error()
        {
            //Get the exception object from the current request context
            Exception? exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
            _logger.LogError(exception ?? new Exception("Exception is null!"), exception?.Message);

            return Problem(title: exception?.Message , statusCode: (int)HttpStatusCode.InternalServerError);
        }
    }
}
