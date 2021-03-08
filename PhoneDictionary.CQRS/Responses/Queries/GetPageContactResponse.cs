using System.Collections.Generic;

namespace PhoneDictionary.CQRS.Responses.Queries
{
    public class GetPageContactResponse
    {
        public IEnumerable<PageContact> Contacts { get; set; }
        public int Pages { get; set; }
        public int Records { get; set; }

        public record PageContact(int ContactId, string Contact, string ContactType, int UserId, string UserName);
    }
}