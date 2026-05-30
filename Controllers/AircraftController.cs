using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HikoukiApi.Models;
using HikoukiApi.Data;
using HikoukiApi.Dtos;

namespace HikoukiApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AircraftController : ControllerBase
    {
        private readonly HikoukiDbContext _context;
        public AircraftController(HikoukiDbContext context)
        {
            _context = context;
        }

        // GET: api/Aircraft
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AircraftResponse>>> GetAircraft()
        {
            var aircraft = await _context.Airplanes
                .Include(a => a.TypeCode)
                .Include(a => a.TypeCodeVariant)
                .Include(a => a.Airline)
                .ToListAsync();

            return aircraft.Select(ToResponse).ToList();
        }

        // GET: api/Aircraft/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AircraftResponse>> GetAircraft(int id)
        {
            var aircraft = await _context.Airplanes
                .Include(a => a.TypeCode)
                .Include(a => a.TypeCodeVariant)
                .Include(a => a.Airline)
                .FirstOrDefaultAsync(a => a.Id == id);

            if (aircraft == null)
            {
                return NotFound();
            }

            return ToResponse(aircraft);
        }

        // PUT: api/Aircraft/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAircraft(int id, CreateAircraftRequest aircraft)
        {
            Aircraft? existingAircraft = await _context.Airplanes.FindAsync(id);
            if (existingAircraft == null)
            {
                return NotFound();
            }

            existingAircraft.Registration = aircraft.Registration;
            existingAircraft.AircraftTypeCodeId = aircraft.AircraftTypeCodeId;
            existingAircraft.TypeCodeVariantId = aircraft.TypeCodeVariantId;
            existingAircraft.SerialNumber = aircraft.SerialNumber;
            existingAircraft.LineNumber = aircraft.LineNumber;
            existingAircraft.AirlineId = aircraft.AirlineId;
            existingAircraft.AlternateOperatorName = aircraft.AlternateOperatorName;
            existingAircraft.IsGovOrMilitary = aircraft.IsGovOrMilitary;
            existingAircraft.IsSpecialLivery = aircraft.IsSpecialLivery;
            existingAircraft.SpecialLiveryName = aircraft.SpecialLiveryName;
            existingAircraft.Remarks = aircraft.Remarks;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        // POST: api/Aircraft
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Aircraft>> PostAircraft(CreateAircraftRequest aircraft)
        {
            Aircraft newAircraft = new()
            {
                Registration = aircraft.Registration,
                AircraftTypeCodeId = aircraft.AircraftTypeCodeId,
                TypeCodeVariantId = aircraft.TypeCodeVariantId,
                SerialNumber = aircraft.SerialNumber,
                LineNumber = aircraft.LineNumber,
                AirlineId = aircraft.AirlineId,
                AlternateOperatorName = aircraft.AlternateOperatorName,
                IsGovOrMilitary = aircraft.IsGovOrMilitary,
                IsSpecialLivery = aircraft.IsSpecialLivery,
                SpecialLiveryName = aircraft.SpecialLiveryName,
                Remarks = aircraft.Remarks
            };

            _context.Airplanes.Add(newAircraft);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAircraft", new { id = newAircraft.Id }, newAircraft);
        }

        // DELETE: api/Aircraft/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAircraft(int? id)
        {
            var aircraft = await _context.Airplanes.FindAsync(id);
            if (aircraft == null)
            {
                return NotFound();
            }

            _context.Airplanes.Remove(aircraft);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AircraftExists(int? id)
        {
            return _context.Airplanes.Any(e => e.Id == id);
        }

        private static AircraftResponse ToResponse(Aircraft aircraft)
        {
            AircraftResponse response = new()
            {
                Id = aircraft.Id,
                Registration = aircraft.Registration,
                TypeCode = aircraft.TypeCode == null ? null : new AircraftTypeCodeResponse
                {
                    Id = aircraft.TypeCode.Id,
                    Icao = aircraft.TypeCode.Icao,
                    Manufacturer = aircraft.TypeCode.Manufacturer
                },
                TypeCodeVariant = aircraft.TypeCodeVariant == null ? null : new TypeCodeVariantResponse
                {
                    Id = aircraft.TypeCodeVariant.Id,
                    VariantName = aircraft.TypeCodeVariant.VariantName
                },
                SerialNumber = aircraft.SerialNumber,
                LineNumber = aircraft.LineNumber,
                Airline = aircraft.Airline == null ? null : new AirlineResponse
                {
                    Id = aircraft.Airline.Id,
                    Iata = aircraft.Airline.Iata,
                    Icao = aircraft.Airline.Icao,
                    Name = aircraft.Airline.Name,
                    Country = aircraft.Airline.Country,
                    IsActive = aircraft.Airline.IsActive
                },
                AlternateOperatorName = aircraft.AlternateOperatorName,
                IsGovOrMilitary = aircraft.IsGovOrMilitary,
                IsSpecialLivery = aircraft.IsSpecialLivery,
                SpecialLiveryName = aircraft.SpecialLiveryName,
                Remarks = aircraft.Remarks
            };

            return response;
        }
    }
}