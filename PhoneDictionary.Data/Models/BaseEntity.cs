using System;
using System.ComponentModel.DataAnnotations;

namespace PhoneDictionary.Data.Models
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}