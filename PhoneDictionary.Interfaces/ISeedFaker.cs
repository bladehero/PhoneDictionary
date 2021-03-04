using System.Collections.Generic;
using PhoneDictionary.Data.Models;

namespace PhoneDictionary.Interfaces
{
    public interface ISeedFaker
    {
        IEnumerable<Contact> Contacts { get; }
        IEnumerable<ContactInfo> ContactInfos { get; }
        IEnumerable<Moderator> Moderators { get; }
        IEnumerable<Tag> Tags { get; }
        IEnumerable<User> Users { get; }
        void Prepare(int userCount = 300, int tagCount = 1200, int contactCount = 1500);
    }
}