using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using volunteer_app_backend.Data;
using volunteer_app_backend.Models;

namespace volunteer_app_backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VolunteersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public VolunteersController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Volunteer>>> GetVolunteers()
        {
            return await _context.Volunteers.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Volunteer>> GetVolunteer(int id)
        {
            var volunteer = await _context.Volunteers.FindAsync(id);

            if (volunteer == null)
            {
                return NotFound();
            }

            return volunteer;
        }

        [HttpPost]
        public async Task<ActionResult<Volunteer>> CreateVolunteer(Volunteer volunteer)
        {
            _context.Volunteers.Add(volunteer);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetVolunteer), new { id = volunteer.Id }, volunteer);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVolunteer(int id, Volunteer volunteer)
        {
            if (id != volunteer.Id)
            {
                return BadRequest();
            }

            _context.Entry(volunteer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (!VolunteerExists(id))
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
        public async Task<IActionResult> DeleteVolunteer(int id)
        {
            var volunteer = await _context.Volunteers.FindAsync(id);
            if (volunteer == null)
            {
                return NotFound();
            }

            _context.Volunteers.Remove(volunteer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VolunteerExists(int id)
        {
            return _context.Volunteers.Any(e => e.Id == id);
        }
    }
}
