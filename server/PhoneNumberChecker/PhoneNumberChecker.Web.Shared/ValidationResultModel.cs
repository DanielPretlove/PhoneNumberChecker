using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneNumberChecker.Web.Shared
{
    public class ValidationResultModel
    {
        public bool IsValid { get; set; }
        public bool IsPossible { get; set; }
        public string? PhoneType { get; set; }
        public string? InternationalFormat { get; set; }
    }
}