using DrMW.Cqrs.Service.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DrMW.Cqrs.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SoapController : ControllerBase
    {
        private readonly ISoapService _soapService;

        public SoapController(ISoapService soapService)
        {
            _soapService = soapService;
        }

     
        [HttpGet("[action]")]
        public async Task<IActionResult> NumebrToDollars([FromQuery]decimal num) 
        {
            var result = await _soapService.NumberToDollars(num);

            return Ok(result);
        }


        [HttpGet("[action]")]
        public async Task<IActionResult> NumberToWords([FromQuery] ulong num)
        {
            var result = await _soapService.NumberToWords(num);

            return Ok(result);
        }

    }
}
