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
        public async Task<ActionResult<IEnumerable<AircraftTypeCode>>> GetAircraftTypeCode()
        {
            return await _context.AircraftTypeCodes.ToListAsync();
        }

        // GET: api/AircraftTypeCode/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AircraftTypeCode>> GetAircraftTypeCode(int id)
        {
            var aircrafttypecode = await _context.AircraftTypeCodes.FindAsync(id);

            if (aircrafttypecode == null)
            {
                return NotFound();
            }

            return aircrafttypecode;
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
        public async Task<ActionResult<AircraftTypeCode>> PostAircraftTypeCode(AircraftTypeCode aircrafttypecode)
        {
            _context.AircraftTypeCodes.Add(aircrafttypecode);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAircraftTypeCode", new { id = aircrafttypecode.Id }, aircrafttypecode);
        }

        // DELETE: api/AircraftTypeCode/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAircraftTypeCode(int? id)
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

        private bool AircraftTypeCodeExists(int? id)
        {
            return _context.AircraftTypeCodes.Any(e => e.Id == id);
        }
    }
}