using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PhoneNumberChecker.Application.Services;
using PhoneNumberChecker.Data.Entities;

namespace PhoneNumberChecker.Web.Server.Controllers
{
    public class CountryController : BaseApiController
    {
        private readonly CountryService _service;
        private readonly Mapper _mapper;
        
        public CountryController(CountryService service, Mapper mapper) 
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IList<Country>> GetCountryList()
        {
            var result = await _service.GetAllCountries();
            return result;
        }

        [HttpGet("{countryCode}")]
        public async Task<Country> GetCountryByCountryCode(string countryCode)
        {
            var result = await _service.GetCountryByCountryCode(countryCode);
            return result;
        }
    }
}
