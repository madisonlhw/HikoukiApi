using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HikoukiApi.Models;
using HikoukiApi.Data;
using HikoukiApi.Dtos;

namespace HikoukiApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AirlinesController : ControllerBase
    {
        private readonly HikoukiDbContext _context;
        public AirlinesController(HikoukiDbContext context)
        {
            _context = context;
        }

        // GET: api/Airline
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AirlineResponse>>> GetAirline()
        {
            var airlines = await _context.Airlines.ToListAsync();

            return airlines.Select(HikoukiResponse.ToResponse).ToList();
        }

        // GET: api/Airline/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AirlineResponse>> GetAirline(int id)
        {
            var airline = await _context.Airlines.FirstOrDefaultAsync(a => a.Id == id);

            if (airline == null)
            {
                return NotFound();
            }

            return HikoukiResponse.ToResponse(airline);
        }

        // PUT: api/Airline/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAirline(int id, CreateAirlineRequest airline)
        {
            Airline? existingAirline = await _context.Airlines.FindAsync(id);
            if (existingAirline == null)
            {
                return NotFound();
            }

            existingAirline.Iata = airline.Iata;
            existingAirline.Icao = airline.Icao;
            existingAirline.Name = airline.Name;
            existingAirline.Country = airline.Country;
            existingAirline.IsActive = airline.IsActive;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        // POST: api/Airline
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AirlineResponse>> PostAirline(CreateAirlineRequest airline)
        {
            Airline newAirline = new()
            {
                Iata = airline.Iata,
                Icao = airline.Icao,
                Name = airline.Name,
                Country = airline.Country,
                IsActive = airline.IsActive
            };

            _context.Airlines.Add(newAirline);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAirline", new { id = newAirline.Id }, HikoukiResponse.ToResponse(newAirline));
        }

        // DELETE: api/Airline/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAirline(int id)
        {
            var airline = await _context.Airlines.FindAsync(id);
            if (airline == null)
            {
                return NotFound();
            }

            _context.Airlines.Remove(airline);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}