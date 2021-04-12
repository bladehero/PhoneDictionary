using System.ComponentModel;

namespace PhoneDictionary.Data.Models
{
    public enum ContactTypes
    {
        [Description("Phone")] PhoneNumber,
        [Description("Email")] Email
    }
}