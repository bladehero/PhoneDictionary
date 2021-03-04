using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PhoneDictionary.CQRS.Requests.Queries;
using PhoneDictionary.CQRS.Responses.Queries;

namespace PhoneDictionary.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactInfosController
    {
        private readonly IMediator _mediator;

        public ContactInfosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<GetContactInfoByIdResponse> Get([FromQuery] GetContactInfoByIdRequest request)
        {
            var response = await _mediator.Send(request);
            return response;
        }
    }
}