namespace PhoneDictionary.Interfaces
{
    public interface IAuth
    {
        string GetToken(string login, string password);
    }
}