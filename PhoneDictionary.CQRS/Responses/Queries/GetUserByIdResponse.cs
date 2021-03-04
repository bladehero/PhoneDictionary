using System.Collections.Generic;

namespace PhoneDictionary.CQRS.Responses.Queries
{
    public class GetUserByIdResponse
    {
        public string UserName { get; set; }
        public IEnumerable<UserContact> Contacts { get; set; }
        public IEnumerable<UserTag> Tags { get; set; }

        public record UserContact(int ContactId, string Contact, string ContactType);
        public record UserTag(string Tag, string Color);
    }
}