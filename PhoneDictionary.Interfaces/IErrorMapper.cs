using System;
using System.Net;

namespace PhoneDictionary.Interfaces
{
    public interface IErrorMapper
    {
        HttpStatusCode Map(Exception exception);
    }
}