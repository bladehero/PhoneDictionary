// ReSharper disable All
namespace PhoneDictionary.Data.Models
{
    public class User : BaseEntity
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}