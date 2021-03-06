using System.Collections.Generic;

namespace PhoneDictionary.CQRS.Responses.Queries
{
    public class GetCitiesResponse
    {
        public List<string> Cities { get; set; }
    }
}