using System.Collections.Generic;

namespace PhoneDictionary.CQRS.Responses.Queries
{
    public class GetCitiesResponse
    {
        public IEnumerable<string> Cities { get; set; }
    }
}