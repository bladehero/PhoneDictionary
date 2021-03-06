using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PhoneDictionary.CQRS.Requests.Commands;
using PhoneDictionary.CQRS.Responses.Commands;

namespace PhoneDictionary.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TagsController : Controller
    {
        private readonly IMediator _mediator;

        public TagsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<AssignTagToUserResponse> Post(AssignTagToUserRequest request)
        {
            var response = await _mediator.Send(request);
            return response;
        }
    }
}