using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HikoukiApi.Models;
using HikoukiApi.Data;
using HikoukiApi.Dtos;

namespace HikoukiApi.Controllers
{
    [Route("aircrafttypecodes/{aircraftTypeCodeId:int}/variants")]
    [ApiController]
    public class TypeCodeVariantsController : ControllerBase
    {
        private readonly HikoukiDbContext _context;
        public TypeCodeVariantsController(HikoukiDbContext context)
        {
            _context = context;
        }

        // GET: api/TypeCodeVariant
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TypeCodeVariantResponse>>> GetTypeCodeVariant(int aircraftTypeCodeId)
        {
            var variants = await _context.TypeCodeVariants.Where(x => x.AircraftTypeCodeId == aircraftTypeCodeId).ToListAsync();
            return variants.Select(HikoukiResponse.ToResponse).ToList();
        }

        // GET: api/TypeCodeVariant/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TypeCodeVariantResponse>> GetTypeCodeVariant(int id, int aircraftTypeCodeId)
        {
            var typecodevariant = await _context.TypeCodeVariants.FirstOrDefaultAsync(a => a.Id == id);

            if (typecodevariant == null || typecodevariant.AircraftTypeCodeId != aircraftTypeCodeId)
            {
                return NotFound();
            }

            return HikoukiResponse.ToResponse(typecodevariant);
        }

        // PUT: api/TypeCodeVariant/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTypeCodeVariant(int id, int aircraftTypeCodeId, CreateTypeCodeVariantRequest request)
        {
            TypeCodeVariant? existingVariant = await _context.TypeCodeVariants.FindAsync(id);
            if (existingVariant == null || existingVariant.AircraftTypeCodeId != aircraftTypeCodeId)
            {
                return NotFound();
            }

            existingVariant.VariantName = request.VariantName;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // POST: api/TypeCodeVariant
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TypeCodeVariantResponse>> PostTypeCodeVariant(int aircraftTypeCodeId, CreateTypeCodeVariantRequest request)
        {
            TypeCodeVariant newVariant = new()
            {
                AircraftTypeCodeId = aircraftTypeCodeId,
                VariantName = request.VariantName
            };

            _context.TypeCodeVariants.Add(newVariant);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTypeCodeVariant", new { aircraftTypeCodeId, id = newVariant.Id }, HikoukiResponse.ToResponse(newVariant));
        }

        // DELETE: api/TypeCodeVariant/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTypeCodeVariant(int id, int aircraftTypeCodeId)
        {
            var typecodevariant = await _context.TypeCodeVariants.FindAsync(id);
            if (typecodevariant == null || typecodevariant.AircraftTypeCodeId != aircraftTypeCodeId)
            {
                return NotFound();
            }

            _context.TypeCodeVariants.Remove(typecodevariant);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}