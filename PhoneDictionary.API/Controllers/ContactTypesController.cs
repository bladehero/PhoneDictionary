using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PhoneDictionary.Data.Models;
using PhoneDictionary.Extensions;

namespace PhoneDictionary.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactTypesController : Controller
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return Enum.GetValues<ContactTypes>().Select(x => x.GetDescription());
        }
    }
}