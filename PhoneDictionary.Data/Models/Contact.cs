namespace PhoneDictionary.Data.Models
{
    public class Contact : BaseEntity
    {
        public string Value { get; set; }
        public ContactTypes ContactType { get; set; }
        
        public int UserId { get; set; }
        public User User { get; set; }

        public ContactInfo ContactInfo { get; set; }
    }
}