// ReSharper disable All

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace PhoneDictionary.Data.Models
{
    public class User : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<Tag> Tags { get; set; }
        public ICollection<Contact> Contacts { get; set; }

        public User()
        {
            Tags = new List<Tag>();
            Contacts = new List<Contact>();
        }
    }
}