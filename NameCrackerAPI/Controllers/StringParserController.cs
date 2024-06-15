using Microsoft.AspNetCore.Mvc;
using NameCrackerAPI.DTO;
using NameCrackerAPI.Interfaces;

namespace FullNameParserAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StringParcerController : ControllerBase
    {
        private readonly IStringParserService _parseNameService;

        public StringParcerController(IStringParserService parseNameService)
        {
            _parseNameService = parseNameService;
        }

        [HttpPost("parse")]
        public IActionResult ParseFullName(FullNameInputDto inputDto)
        {
            if (inputDto == null || string.IsNullOrWhiteSpace(inputDto.FullName))
            {
                return BadRequest("Input string cannot be empty or null.");
            }

            try
            {
                var parsedName = _parseNameService.ParseFullString(inputDto.FullName);
                return Ok(parsedName);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
