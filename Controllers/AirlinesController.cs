using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HikoukiApi.Models;
using HikoukiApi.Data;

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
    public async Task<ActionResult<IEnumerable<Airline>>> GetAirline()
    {
        return await _context.Airlines.ToListAsync();
    }

    // GET: api/Airline/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Airline>> GetAirline(int id)
    {
        var airline = await _context.Airlines.FindAsync(id);

        if (airline == null)
        {
            return NotFound();
        }

        return airline;
    }

    // PUT: api/Airline/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAirline(int? id, Airline airline)
    {
        if (id != airline.Id)
        {
            return BadRequest();
        }

        _context.Entry(airline).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!AirlineExists(id))
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

    // POST: api/Airline
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Airline>> PostAirline(Airline airline)
    {
        _context.Airlines.Add(airline);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetAirline", new { id = airline.Id }, airline);
    }

    // DELETE: api/Airline/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAirline(int? id)
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

    private bool AirlineExists(int? id)
    {
        return _context.Airlines.Any(e => e.Id == id);
    }
}
