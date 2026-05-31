using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HikoukiApi.Models;
using HikoukiApi.Data;
using HikoukiApi.Dtos;

namespace HikoukiApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AirportsController : ControllerBase
    {
        private readonly HikoukiDbContext _context;
        public AirportsController(HikoukiDbContext context)
        {
            _context = context;
        }

        // GET: api/Airport
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AirportResponse>>> GetAirport()
        {
            var airports = await _context.Airports.ToListAsync();

            return airports.Select(HikoukiResponse.ToResponse).ToList();
        }

        // GET: api/Airport/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AirportResponse>> GetAirport(int id)
        {
            var airport = await _context.Airports.FirstOrDefaultAsync(a => a.Id == id);

            if (airport == null)
            {
                return NotFound();
            }

            return HikoukiResponse.ToResponse(airport);
        }

        // PUT: api/Airport/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAirport(int id, CreateAirportRequest airport)
        {
            Airport? existingAirport = await _context.Airports.FindAsync(id);
            if (existingAirport == null)
            {
                return NotFound();
            }

            existingAirport.Iata = airport.Iata;
            existingAirport.Icao = airport.Icao;
            existingAirport.Name = airport.Name;
            existingAirport.AlternateName = airport.AlternateName;
            existingAirport.Country = airport.Country;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        // POST: api/Airport
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AirportResponse>> PostAirport(CreateAirportRequest airport)
        {
            Airport newAirport = new()
            {
                Iata = airport.Iata,
                Icao = airport.Icao,
                Name = airport.Name,
                AlternateName = airport.AlternateName,
                Country = airport.Country
            };

            _context.Airports.Add(newAirport);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAirport", new { id = newAirport.Id }, HikoukiResponse.ToResponse(newAirport));
        }

        // DELETE: api/Airport/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAirport(int id)
        {
            var airport = await _context.Airports.FindAsync(id);
            if (airport == null)
            {
                return NotFound();
            }

            _context.Airports.Remove(airport);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}