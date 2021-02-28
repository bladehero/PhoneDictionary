using System.ComponentModel.DataAnnotations;

namespace PhoneDictionary.Data.Models
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}