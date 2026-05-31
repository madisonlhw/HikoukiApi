using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HikoukiApi.Models;
using HikoukiApi.Data;
using HikoukiApi.Dtos;

namespace HikoukiApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AircraftTypeCodesController(HikoukiDbContext context) : ControllerBase
    {
        private readonly HikoukiDbContext _context = context;

        // GET: api/AircraftTypeCode
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AircraftTypeCodeResponse>>> GetAircraftTypeCode()
        {
            var aircraftTypeCodes = await _context.AircraftTypeCodes.ToListAsync();
            return aircraftTypeCodes.Select(HikoukiResponse.ToResponse).ToList();
        }

        // GET: api/AircraftTypeCode/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AircraftTypeCodeResponse>> GetAircraftTypeCode(int id)
        {
            var aircrafttypecode = await _context.AircraftTypeCodes.FirstOrDefaultAsync(a => a.Id == id);

            if (aircrafttypecode == null)
            {
                return NotFound();
            }

            return HikoukiResponse.ToResponse(aircrafttypecode);
        }

        // PUT: api/AircraftTypeCode/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAircraftTypeCode(int id, CreateAircraftTypeCodeRequest request)
        {
            AircraftTypeCode? existingTypeCode = await _context.AircraftTypeCodes.FindAsync(id);
            if (existingTypeCode == null)
            {
                return NotFound();
            }

            existingTypeCode.Icao = request.Icao;
            existingTypeCode.Manufacturer = request.Manufacturer;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        // POST: api/AircraftTypeCode
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AircraftTypeCodeResponse>> PostAircraftTypeCode(CreateAircraftTypeCodeRequest aircrafttypecode)
        {
            AircraftTypeCode newAircraftTypeCode = new()
            {
                Icao = aircrafttypecode.Icao,
                Manufacturer = aircrafttypecode.Manufacturer
            };

            _context.AircraftTypeCodes.Add(newAircraftTypeCode);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAircraftTypeCode", new { id = newAircraftTypeCode.Id }, HikoukiResponse.ToResponse(newAircraftTypeCode));
        }

        // DELETE: api/AircraftTypeCode/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAircraftTypeCode(int id)
        {
            var aircrafttypecode = await _context.AircraftTypeCodes.FindAsync(id);
            if (aircrafttypecode == null)
            {
                return NotFound();
            }

            _context.AircraftTypeCodes.Remove(aircrafttypecode);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}