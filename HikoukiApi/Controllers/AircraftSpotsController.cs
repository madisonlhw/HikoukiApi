using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HikoukiApi.Models;
using HikoukiApi.Data;
using HikoukiApi.Dtos;

namespace HikoukiApi.Controllers
{
    [Route("aircraft/{aircraftId:int}/spotting")]
    [ApiController]
    public class AircraftSpotsController : ControllerBase
    {
        private readonly HikoukiDbContext _context;
        public AircraftSpotsController(HikoukiDbContext context)
        {
            _context = context;
        }

        // GET: api/AircraftSpot
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AircraftSpotResponse>>> GetAircraftSpot(int aircraftId)
        {
            var spots = await SpotsWithIncludes().Where(x => x.AircraftId == aircraftId).ToListAsync();
            return spots.Select(HikoukiResponse.ToResponse).ToList();
        }

        // GET: api/AircraftSpot/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AircraftSpotResponse>> GetAircraftSpot(int id, int aircraftId)
        {
            var spot = await SpotsWithIncludes()
                .Where(x => x.AircraftId == aircraftId)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (spot == null)
            {
                return NotFound();
            }

            return HikoukiResponse.ToResponse(spot);
        }

        // PUT: api/AircraftSpot/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAircraftSpot(int id, int aircraftId, CreateAircraftSpotRequest aircraftspot)
        {
            AircraftSpot? existingSpot = await _context.AircraftSpotting.FindAsync(id);
            if (existingSpot == null || existingSpot.AircraftId != aircraftId)
            {
                return NotFound();
            }

            existingSpot.Date = aircraftspot.Date;
            existingSpot.TypeCodeVariantId = aircraftspot.TypeCodeVariantId;
            existingSpot.AirlineId = aircraftspot.AirlineId;
            existingSpot.AirportId = aircraftspot.AirportId;
            existingSpot.AirportLocation = aircraftspot.AirportLocation;
            existingSpot.Camera = aircraftspot.Camera;
            existingSpot.Lens = aircraftspot.Lens;
            existingSpot.Remarks = aircraftspot.Remarks;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        // POST: api/AircraftSpot
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AircraftSpotResponse>> PostAircraftSpot(int aircraftId, CreateAircraftSpotRequest request)
        {
            AircraftSpot newSpot = new()
            {
                Date = request.Date,
                AircraftId = aircraftId,
                TypeCodeVariantId = request.TypeCodeVariantId,
                AirlineId = request.AirlineId,
                AirportId = request.AirportId,
                AirportLocation = request.AirportLocation,
                Camera = request.Camera,
                Lens = request.Lens,
                Remarks = request.Remarks
            };

            _context.AircraftSpotting.Add(newSpot);
            await _context.SaveChangesAsync();

            var created = await SpotsWithIncludes().FirstAsync(s => s.Id == newSpot.Id);
            return CreatedAtAction("GetAircraftSpot", new { aircraftId, id = newSpot.Id }, HikoukiResponse.ToResponse(created));
        }

        // DELETE: api/AircraftSpot/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAircraftSpot(int id, int aircraftId)
        {
            var aircraftspot = await _context.AircraftSpotting.FindAsync(id);
            if (aircraftspot == null || aircraftspot.AircraftId != aircraftId)
            {
                return NotFound();
            }

            _context.AircraftSpotting.Remove(aircraftspot);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private IQueryable<AircraftSpot> SpotsWithIncludes() => _context.AircraftSpotting
            .Include(x => x.Aircraft).ThenInclude(a => a!.TypeCodeVariant)
            .Include(x => x.Aircraft).ThenInclude(a => a!.TypeCode)
            .Include(x => x.TypeCodeVariant)
            .Include(x => x.Airline)
            .Include(x => x.Airport);
    }
}