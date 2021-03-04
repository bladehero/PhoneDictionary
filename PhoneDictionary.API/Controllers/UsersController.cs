using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PhoneDictionary.CQRS.Requests.Queries;
using PhoneDictionary.CQRS.Responses.Queries;

namespace PhoneDictionary.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpGet]
        public async Task<GetUserByIdResponse> Get([FromQuery] GetUserByIdRequest request)
        {
            var response = await _mediator.Send(request);
            return response;
        }
    }
}