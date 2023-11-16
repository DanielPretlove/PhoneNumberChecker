using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneNumberChecker.Data.Entities
{
    public class PhoneNumberValidation : DataEntity
    {
        public IList<Country> Countries { get; set; } = new ObservableCollection<Country>();
        public string PhoneNumber { get; set; }
        public bool IsValid { get; set; }
        public bool IsPossible { get; set; }
        public string PhoneType { get; set; }
        public string InternationalFormat { get; set; }
    }
}
