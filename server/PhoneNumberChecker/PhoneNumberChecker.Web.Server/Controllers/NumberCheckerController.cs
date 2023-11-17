using Microsoft.AspNetCore.Mvc;
using PhoneNumberChecker.Application.Services;
using PhoneNumberChecker.Web.Shared;


namespace PhoneNumberChecker.Web.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NumberCheckerController : ControllerBase
    {
        private readonly NumberCheckerService _service;
        
        public NumberCheckerController(NumberCheckerService service)
        {
            _service = service;
        }

        [Route("ValidatePhoneNumber/{telephoneNumber}/{countryCode}")]
        [HttpGet]
        public Task<ValidationResultModel> ValidatePhoneNumber(string telephoneNumber, string countryCode)
        {
            var result = _service.ValidatePhoneNumber(telephoneNumber, countryCode);
            return result;
        }
    }
}
