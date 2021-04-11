using Bogus;
using PhoneDictionary.Data.Models;

namespace PhoneDictionary.Services.Seed
{
    internal sealed class BaseEntityFaker<T> : Faker<T> where T : BaseEntity
    {
        public BaseEntityFaker(string locale = "en") : base(locale)
        {
            var id = 1;
            RuleFor(x => x.Id, _ => id++);
            RuleFor(x => x.CreatedAt, x => x.Date.Past());
        }
    }
}