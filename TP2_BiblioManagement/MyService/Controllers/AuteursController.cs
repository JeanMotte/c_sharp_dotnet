using Microsoft.AspNetCore.Mvc;
using BiblioManagement.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyService.Data;

[ApiController]
[Route("api/[controller]")]
public class AuteursController : ControllerBase
{
    // Context as dependency injected via the constructor
    private readonly TempDbContext _context;

    public AuteursController(TempDbContext context)
    {
        _context = context;
    }

    // GET: api/auteurs
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Auteur>>> GetAuteurs()
    {
        // return Ok(BiblioInitializer.Auteurs);
        return await _context.Auteurs.ToListAsync();
    }

    // GET: api/auteurs/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Auteur>> GetAuteur(int id)
    {
        // var auteur = BiblioInitializer.Auteurs.FirstOrDefault(a => a.Id == id);
        var auteur = await _context.Auteurs.FindAsync(id);

        if (auteur == null)
        {
            return NotFound();
        }
        return auteur;
    }

    // POST: api/auteurs
    [HttpPost]
    public async Task<ActionResult<Auteur>> PostAuteur(Auteur auteur)
    {
        // BiblioInitializer.Auteurs.Add(auteur);
        _context.Auteurs.Add(auteur);
        await _context.SaveChangesAsync(); // Sauvegarde en base

        return CreatedAtAction(nameof(GetAuteur), new { id = auteur.Id }, auteur);
    }

    // PUT: api/auteurs/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAuteur(int id, Auteur auteur)
    {
        if (id != auteur.Id)
        {
            return BadRequest();
        }

        _context.Entry(auteur).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Auteurs.Any(e => e.Id == id))
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

    // DELETE: api/auteurs/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAuteur(int id)
    {
        // var auteur = BiblioInitializer.Auteurs.FirstOrDefault(a => a.Id == id);
        var auteur = await _context.Auteurs.FindAsync(id);
        if (auteur == null)
        {
            return NotFound();
        }

        // BiblioInitializer.Auteurs.Remove(auteur);
        _context.Auteurs.Remove(auteur);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}