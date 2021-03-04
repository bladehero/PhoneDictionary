using MediatR;
using PhoneDictionary.CQRS.Responses.Queries;

namespace PhoneDictionary.CQRS.Requests.Queries
{
    public class GetContactInfoByIdRequest : IRequest<GetContactInfoByIdResponse>
    {
        public int ContactInfoId { get; set; }
    }
}