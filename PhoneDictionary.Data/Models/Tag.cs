namespace PhoneDictionary.Data.Models
{
    public class Tag : BaseEntity
    {
        public string Text { get; set; }
        public string Color { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}