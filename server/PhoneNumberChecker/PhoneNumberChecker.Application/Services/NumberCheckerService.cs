using PhoneNumberChecker.Data.Entities;
using PhoneNumberChecker.Web.Shared;
using PhoneNumbers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PhoneNumberChecker.Application.Services
{
    public class NumberCheckerService
    {
        public async Task<ValidationResultModel> ValidatePhoneNumber(string telephoneNumber, string countryCode)
        {
            ValidationResultModel validationResult;

            if (string.IsNullOrEmpty(telephoneNumber))
            {
                validationResult = new ValidationResultModel() {};
            }
            else if ((string.IsNullOrEmpty(countryCode)) || ((countryCode.Length != 2) && (countryCode.Length != 3)))
            {

                validationResult = new ValidationResultModel() {};
            }
            else
            {
                PhoneNumberUtil phoneUtil = PhoneNumberUtil.GetInstance();
                PhoneNumber phoneNumber = phoneUtil.Parse(telephoneNumber, countryCode);

                bool isMobile = false;
                bool isValidNumber = phoneUtil.IsValidNumber(phoneNumber); 

                bool isValidRegion = phoneUtil.IsValidNumberForRegion(phoneNumber, countryCode); 

                string region = phoneUtil.GetRegionCodeForNumber(phoneNumber); 

                var numberType = phoneUtil.GetNumberType(phoneNumber); 

                string phoneNumberType = numberType.ToString();

                if (!string.IsNullOrEmpty(phoneNumberType) && phoneNumberType == "MOBILE")
                {
                    isMobile = true;
                }

                var originalNumber = phoneUtil.Format(phoneNumber, PhoneNumberFormat.E164); 

                if(telephoneNumber.Length == 10 && isMobile == true)
                {
                    validationResult = new ValidationResultModel()
                    {
                        IsValid = isValidNumber,
                        IsPossible = isMobile,
                        PhoneType = phoneNumberType.ToLower(),
                        PhoneNumber = telephoneNumber,
                        InternationalFormat = originalNumber,
                        CountryCode = region
                    };
                }

                else
                {
                    validationResult = new ValidationResultModel() { };
                }
            }
            return validationResult;

        }
    }
}
