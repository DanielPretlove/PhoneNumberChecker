using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PhoneNumberChecker.Application.Services;
using PhoneNumberChecker.Data.Entities;

namespace PhoneNumberChecker.Web.Server.Controllers
{
    public class CountryController : BaseApiController
    {
        private readonly CountryService _service;
        public CountryController(CountryService service) 
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IList<Country>> GetCountryList()
        {
            var result = await _service.GetAllCountries();
            return result;
        }
    }
}
