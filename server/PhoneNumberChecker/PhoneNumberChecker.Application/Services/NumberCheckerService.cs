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
        public ValidationResultModel ValidatePhoneNumber(string telephoneNumber, string countryCode)
        {
            ValidationResultModel validationResult;
            var unknownType = PhoneNumberType.UNKNOWN.ToString().ToLower();
            if (string.IsNullOrEmpty(telephoneNumber))
            {
                validationResult = new ValidationResultModel()
                {
                    IsValid = false,
                    IsPossible = false,
                    PhoneType = unknownType,
                    InternationalFormat = "unknown"
                };
            }
            else if ((string.IsNullOrEmpty(countryCode)) || ((countryCode.Length != 2)))
            {
                validationResult = new ValidationResultModel()
                {
                    IsValid = false,
                    IsPossible = false,
                    PhoneType = unknownType,
                    InternationalFormat = "unknown"
                };
            }
            else
            {
                PhoneNumberUtil phoneUtil = PhoneNumberUtil.GetInstance();
                PhoneNumber phoneNumber = phoneUtil.Parse(telephoneNumber, countryCode);

                bool isMobile = false;
                bool isValidRegion = phoneUtil.IsValidNumberForRegion(phoneNumber, countryCode); 
                var numberType = phoneUtil.GetNumberType(phoneNumber); 

                string phoneNumberType = numberType.ToString();

                if (!string.IsNullOrEmpty(phoneNumberType) && phoneNumberType == PhoneNumberType.MOBILE.ToString())
                {
                    isMobile = true;
                }
                var originalNumber = phoneUtil.Format(phoneNumber, PhoneNumberFormat.E164); 


                if(telephoneNumber.Length == 10 && isValidRegion == true)
                {
                    validationResult = new ValidationResultModel()
                    {
                        IsValid = isValidRegion,
                        IsPossible = isMobile,
                        PhoneType = phoneNumberType.ToLower(),
                        InternationalFormat = originalNumber,
                    };
                }

                else
                {
                    validationResult = new ValidationResultModel() 
                    {
                        IsValid = false,
                        IsPossible = false,
                        PhoneType = unknownType,
                        InternationalFormat = "unknown"
                    };
                }
            }
            return validationResult;

        }
    }
}
