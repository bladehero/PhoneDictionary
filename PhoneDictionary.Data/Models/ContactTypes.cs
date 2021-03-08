using System.ComponentModel;

namespace PhoneDictionary.Data.Models
{
    public enum ContactTypes
    {
        [Description("Телефоний номер")] PhoneNumber,
        [Description("Email")] Email
    }
}