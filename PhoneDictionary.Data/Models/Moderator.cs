using System.ComponentModel.DataAnnotations;

namespace PhoneDictionary.Data.Models
{
    public class Moderator : BaseEntity
    {
        public string Login { get; set; }
        [StringLength(32, MinimumLength = 32)] public string Password { get; set; }
    }
}