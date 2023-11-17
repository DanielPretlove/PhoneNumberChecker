using AutoMapper;
using PhoneNumberChecker.Data.Entities;
using PhoneNumberChecker.Web.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneNumberChecker.Application.Mappers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles() 
        {
            //CreateMap<Country, CountryListModel>();
            //CreateMap<CountryListModel, Country>();
        }
    }
}
