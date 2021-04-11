using System;
using System.Collections.Generic;
using System.Linq;
using PhoneDictionary.Data.Models;
using PhoneDictionary.Extensions;
using PhoneDictionary.Interfaces;

namespace PhoneDictionary.Services.Seed
{
    public class SeedFaker : ISeedFaker
    {
        public IEnumerable<Contact> Contacts { get; private set; }
        public IEnumerable<ContactInfo> ContactInfos { get; private set; }
        public IEnumerable<Moderator> Moderators { get; private set; }
        public IEnumerable<Tag> Tags { get; private set; }
        public IEnumerable<User> Users { get; private set; }

        public void Prepare(int userCount = 300, int tagCount = 1200, int contactCount = 1500)
        {
            Moderators = new[] {new Moderator {Id = 1, Login = "admin", Password = "qwerty".ToMD5HashString()}};

            var userFaker = new BaseEntityFaker<User>()
                .RuleFor(x => x.Name, x => x.Person.FullName);

            Users = userFaker.Generate(userCount);

            var tagFaker = new BaseEntityFaker<Tag>()
                .RuleFor(x => x.Text, x => $"{x.Hacker.Adjective()} {x.Hacker.Noun()}")
                .RuleFor(x => x.Color, x => x.Internet.Color())
                .RuleFor(x => x.UserId, x => x.PickRandom(Users).Id);

            Tags = tagFaker.Generate(tagCount);

            var contactFaker = new BaseEntityFaker<Contact>()
                .RuleFor(x => x.ContactType, x => x.PickRandom<ContactTypes>())
                .RuleFor(x => x.Value, (x, contact) =>
                {
                    return contact.ContactType switch
                    {
                        ContactTypes.PhoneNumber => x.Phone.PhoneNumber(),
                        ContactTypes.Email => x.Internet.ExampleEmail(),
                        _ => throw new ArgumentOutOfRangeException()
                    };
                })
                .RuleFor(x => x.UserId, x => x.PickRandom(Users).Id);

            Contacts = contactFaker.Generate(contactCount);

            var phones = Contacts.Where(x => x.ContactType == ContactTypes.PhoneNumber);
            var providers = new[] {"Vodafone", "T-Mobile", "Orange", "Play"};
            var contactInfoFaker = new BaseEntityFaker<ContactInfo>()
                .RuleFor(x => x.City, x => x.Address.City())
                .RuleFor(x => x.Country, x => x.Address.Country())
                .RuleFor(x => x.Provider, x => x.PickRandom(providers));

            ContactInfos = phones.Select(x =>
            {
                var contactInfo = contactInfoFaker.Generate();
                contactInfo.ContactId = x.Id;
                return contactInfo;
            });
        }
    }
}