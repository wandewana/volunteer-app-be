using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using volunteer_app_backend.Data;
using volunteer_app_backend.Models;

namespace volunteer_app_backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegistrationsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RegistrationsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Registration>>> GetRegistrations()
        {
            return await _context.Registrations.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Registration>> GetRegistration(int id)
        {
            var registration = await _context.Registrations.FindAsync(id);

            if (registration == null)
            {
                return NotFound();
            }

            return registration;
        }

        [HttpPost]
        public async Task<ActionResult<Registration>> CreateRegistration(Registration registration)
        {
            _context.Registrations.Add(registration);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetRegistration), new { id = registration.Id }, registration);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRegistration(int id, Registration registration)
        {
            if (id != registration.Id)
            {
                return BadRequest();
            }

            _context.Entry(registration).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (!RegistrationExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRegistration(int id)
        {
            var registration = await _context.Registrations.FindAsync(id);
            if (registration == null)
            {
                return NotFound();
            }

            _context.Registrations.Remove(registration);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RegistrationExists(int id)
        {
            return _context.Registrations.Any(e => e.Id == id);
        }
    }
}
