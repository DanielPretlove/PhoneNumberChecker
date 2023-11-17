using Microsoft.EntityFrameworkCore;
using PhoneNumberChecker.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneNumberChecker.Data.Access.Repositories
{
    public class CountryRepository : ICountryReposiotry
    {
        private readonly DataContext _context;
        public CountryRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<IList<Country>> GetAllCountries()
        {
            return await _context.Set<Country>().ToListAsync();
        }

        public async Task<Country> GetCountryByCountryCode(string countryCode)
        {
            return await _context.Set<Country>().FirstOrDefaultAsync(c => c.CountryCode == countryCode);
        }
    }
}