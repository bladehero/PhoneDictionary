using System.ComponentModel.DataAnnotations;
using MediatR;
using PhoneDictionary.CQRS.Responses.Queries;
using PhoneDictionary.Data.Models;

namespace PhoneDictionary.CQRS.Requests.Queries
{
    public class GetPageContactRequest : IRequest<GetPageContactResponse>
    {
        [Range(0, int.MaxValue)] public int Page { get; set; } = 0;
        [Range(1, 50)] public int Size { get; set; } = 10;

        public ContactTypes? ContactType { get; set; }

        [MaxLength(25)] public string City { get; set; }

        [MaxLength(100)] public string Search { get; set; }
    }
}