using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PhoneNumberChecker.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
    }
}