namespace PhoneDictionary.Data.Models
{
    public class ContactInfo : BaseEntity
    {
        public string Country { get; set; }
        public string City { get; set; }
        public string Provider { get; set; }

        public int ContactId { get; set; }
        public Contact Contact { get; set; }
    }
}