namespace PhoneDictionary.CQRS.Responses.Queries
{
    public class GetContactInfoByIdResponse
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Provider { get; set; }
        public string Contact { get; set; }
    }
}