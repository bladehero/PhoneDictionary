using MediatR;
using PhoneDictionary.CQRS.Responses.Queries;

namespace PhoneDictionary.CQRS.Requests.Queries
{
    public class GetUserByIdRequest : IRequest<GetUserByIdResponse>
    {
        public int UserId { get; set; }
    }
}