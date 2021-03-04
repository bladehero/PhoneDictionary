using System.Collections.Generic;

namespace PhoneDictionary.CQRS.Responses.Queries
{
    public class GetPageContactResponse
    {
        public IEnumerable<PageContact> Contacts { get; set; }

        public record PageContact(string Contact, string ContactType, int UserId, string UserName);
    }
}