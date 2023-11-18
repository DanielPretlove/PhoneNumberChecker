using Azure.Core;
using PhoneNumberChecker.Data.Access.Repositories;
using PhoneNumberChecker.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace PhoneNumberChecker.Application.Services
{
    public class CountryService
    {
        private readonly ICountryReposiotry _countryReposiotry;

        public CountryService(ICountryReposiotry countryReposiotry)
        {
            _countryReposiotry = countryReposiotry;
        }

        public async Task<IList<Country>> GetAllCountries()
        {
           return await _countryReposiotry.GetAllCountries();
        }
    }
}
