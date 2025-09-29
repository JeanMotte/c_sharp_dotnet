using Microsoft.AspNetCore.Mvc;
using BiblioManagement.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyService.Data;

[ApiController]
[Route("api/[controller]")]
public class LivresController : ControllerBase
{
    // Context as dependency injected via the constructor
    private readonly TempDbContext _context;

    public LivresController(TempDbContext context)
    {
        _context = context;
    }

    // GET: api/livres
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Livre>>> GetLivres()
    {
        // return Ok(BiblioInitializer.Livres);
        return await _context.Livres
            .Include(l => l.Auteurs)
            .Include(l => l.Categories)
            .ToListAsync();
    }

    // GET: api/livres/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Livre>> GetLivre(int id)
    {
        // var livre = BiblioInitializer.Livres.FirstOrDefault(l => l.Id == id);
        var livre = await _context.Livres
            .Include(l => l.Auteurs)
            .Include(l => l.Categories)
            .FirstOrDefaultAsync(l => l.Id == id);

        if (livre == null)
        {
            return NotFound();
        }
        return livre;
    }

    // POST: api/livres
    [HttpPost]
    public async Task<ActionResult<Livre>> PostLivre(Livre livre)
    {
        // BiblioInitializer.Livres.Add(livre);
        _context.Livres.Add(livre);
        await _context.SaveChangesAsync(); // Save to DB

        return CreatedAtAction(nameof(GetLivre), new { id = livre.Id }, livre);
    }

    // PUT: api/livres/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutLivre(int id, Livre livre)
    {
        if (id != livre.Id)
        {
            return BadRequest();
        }

        _context.Entry(livre).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync(); // Save to DB
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Livres.Any(e => e.Id == id))
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

    // DELETE: api/livres/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteLivre(int id)
    {
        var livre = await _context.Livres.FindAsync(id);
        if (livre == null)
        {
            return NotFound();
        }

        _context.Livres.Remove(livre);
        await _context.SaveChangesAsync(); // Save to DB

        return NoContent();
    }

}