using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PhoneDictionary.Data.Views;
using PhoneDictionary.Interfaces;

namespace PhoneDictionary.API.Controllers
{
    [AllowAnonymous]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorsController : ControllerBase
    {
        private readonly IErrorMapper _errorMapper;

        public ErrorsController(IErrorMapper errorMapper)
        {
            _errorMapper = errorMapper;
        }
        
        [Route("error")]
        public ActionResult<ErrorResponseVM> Error()
        {
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
            var exception = context.Error;

            var code = _errorMapper.Map(exception);
            Response.StatusCode = (int)code;

            return new ErrorResponseVM(exception);
        }
    }
}