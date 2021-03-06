using MediatR;
using PhoneDictionary.CQRS.Responses.Queries;

namespace PhoneDictionary.CQRS.Requests.Queries
{
    public class GetCitiesRequest : IRequest<GetCitiesResponse>
    {
        public string City { get; set; }
    }
}