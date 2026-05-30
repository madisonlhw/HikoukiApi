using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HikoukiApi.Models;
using HikoukiApi.Data;

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
    public async Task<ActionResult<IEnumerable<Airport>>> GetAirport()
    {
        return await _context.Airports.ToListAsync();
    }

    // GET: api/Airport/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Airport>> GetAirport(int id)
    {
        var airport = await _context.Airports.FindAsync(id);

        if (airport == null)
        {
            return NotFound();
        }

        return airport;
    }

    // PUT: api/Airport/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAirport(int? id, Airport airport)
    {
        if (id != airport.Id)
        {
            return BadRequest();
        }

        _context.Entry(airport).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!AirportExists(id))
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

    // POST: api/Airport
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Airport>> PostAirport(Airport airport)
    {
        _context.Airports.Add(airport);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetAirport", new { id = airport.Id }, airport);
    }

    // DELETE: api/Airport/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAirport(int? id)
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

    private bool AirportExists(int? id)
    {
        return _context.Airports.Any(e => e.Id == id);
    }
}
