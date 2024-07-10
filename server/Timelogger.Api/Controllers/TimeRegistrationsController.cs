using ExampleProject.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Timelogger.Api.DTOs;
using Timelogger.Api.Services;

namespace Timelogger.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowSpecificOrigin")]
    public class TimeRegistrationsController : ControllerBase
    {
        private readonly ITimeRegistrationService _timeRegistrationService;

        public TimeRegistrationsController(ITimeRegistrationService timeRegistrationService)
        {
            _timeRegistrationService = timeRegistrationService;
        }

        // GET: api/TimeRegistrations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TimeRegistrationDTO>>> GetTimeRegistrations()
        {
            var timeRegistrations = await _timeRegistrationService.GetTimeRegistrationsAsync();
            return Ok(timeRegistrations);
        }

        // GET: api/TimeRegistrations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TimeRegistrationDTO>> GetTimeRegistration(int id)
        {
            var timeRegistration = await _timeRegistrationService.GetTimeRegistrationByIdAsync(id);
            if (timeRegistration == null)
            {
                return NotFound();
            }
            return Ok(timeRegistration);
        }

        // POST: api/TimeRegistrations
        [HttpPost]
        public async Task<IActionResult> PostTimeRegistration([FromBody] TimeRegistrationDTO timeRegistration)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _timeRegistrationService.AddTimeRegistrationAsync(timeRegistration);
            return CreatedAtAction(nameof(GetTimeRegistration), new { id = timeRegistration.Id }, timeRegistration);
        }

        // PUT: api/TimeRegistrations/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTimeRegistration(int id, [FromBody] TimeRegistrationDTO timeRegistration)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != timeRegistration.Id)
            {
                return BadRequest("ID mismatch");
            }

            await _timeRegistrationService.UpdateTimeRegistrationAsync(timeRegistration);
            return NoContent();
        }

        // DELETE: api/TimeRegistrations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTimeRegistration(int id)
        {
            var timeRegistration = await _timeRegistrationService.GetTimeRegistrationByIdAsync(id);
            if (timeRegistration == null)
            {
                return NotFound();
            }

            await _timeRegistrationService.DeleteTimeRegistrationAsync(id);
            return NoContent();
        }
    }
}
