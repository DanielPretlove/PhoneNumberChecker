using Microsoft.IdentityModel.Tokens;
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
            PhoneNumberUtil phoneUtil = PhoneNumberUtil.GetInstance();
            PhoneNumber phoneNumber = phoneUtil.Parse(telephoneNumber, countryCode);

            bool isMobile = false;
            bool isValidRegion = phoneUtil.IsValidNumberForRegion(phoneNumber, countryCode);
            var numberType = phoneUtil.GetNumberType(phoneNumber);

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

                if (!string.IsNullOrEmpty(numberType.ToString()) && numberType == PhoneNumberType.MOBILE)
                {
                    isMobile = true;
                }

                var internationalNumber = phoneUtil.Format(phoneNumber, PhoneNumberFormat.E164); 
                if(telephoneNumber.Length == 10 && isValidRegion == true)
                {
                    validationResult = new ValidationResultModel()
                    {
                        IsValid = isValidRegion,
                        IsPossible = isMobile,
                        PhoneType = numberType.ToString().ToLower(),
                        InternationalFormat = internationalNumber,
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
