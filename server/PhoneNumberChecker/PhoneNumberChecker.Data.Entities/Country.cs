using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneNumberChecker.Data.Entities
{
    public class Country
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string CountryCode { get; set; }
    }
}
