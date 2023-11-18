using PhoneNumberChecker.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneNumberChecker.Data.Access.Repositories
{
    public interface ICountryReposiotry
    {
        Task<IList<Country>> GetAllCountries();
    }
}
