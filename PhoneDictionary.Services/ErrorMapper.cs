using System;
using System.Collections.Generic;
using System.Net;
using System.Security.Authentication;
using PhoneDictionary.Interfaces;

namespace PhoneDictionary.Services
{
    public class ErrorMapper : IErrorMapper
    {
        private const HttpStatusCode Default = HttpStatusCode.InternalServerError;
        private readonly IDictionary<Type, HttpStatusCode> _errors;
        
        public ErrorMapper()
        {
            _errors = new Dictionary<Type, HttpStatusCode>()
            {
                { typeof(AuthenticationException), HttpStatusCode.Unauthorized }
            };
        }

        public HttpStatusCode Map(Exception exception)
        {
            var success = _errors.TryGetValue(exception.GetType(), out var code);
            return success ? code : Default;
        }
    }
}