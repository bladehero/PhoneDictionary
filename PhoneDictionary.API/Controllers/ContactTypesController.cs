using System;
using System.Collections;
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
        public IEnumerable Get()
        {
            return Enum.GetValues<ContactTypes>().Select(x => new
            {
                Text = x.GetDescription(), 
                Value = x
            });
        }
    }
}