using Microsoft.AspNetCore.Mvc;
using BiblioManagement.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyService.Data;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController : ControllerBase
{
    // Context as dependency injected via the constructor
    private readonly TempDbContext _context;

    public CategoriesController(TempDbContext context)
    {
        _context = context;
    }

    // GET: api/categories
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Categorie>>> GetCategories()
    {
        // return Ok(BiblioInitializer.Categories);
        return await _context.Categories.ToListAsync();
    }

    // GET: api/categories/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Categorie>> GetCategorie(int id)
    {
        // var categorie = BiblioInitializer.Categories.FirstOrDefault(c => c.Id == id);
        var categorie = await _context.Categories.FindAsync(id);

        if (categorie == null)
        {
            return NotFound();
        }
        return categorie;
    }

    // POST: api/categories
    [HttpPost]
    public async Task<ActionResult<Categorie>> PostCategorie(Categorie categorie)
    {
        // BiblioInitializer.Categories.Add(categorie);
        _context.Categories.Add(categorie);
        await _context.SaveChangesAsync(); // Save to DB

        return CreatedAtAction(nameof(GetCategorie), new { id = categorie.Id }, categorie);
    }

    // PUT: api/categories/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutCategorie(int id, Categorie categorie)
    {
        if (id != categorie.Id)
        {
            return BadRequest();
        }

        _context.Entry(categorie).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync(); // Save to DB
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Categories.Any(e => e.Id == id))
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

    // DELETE: api/categories/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCategorie(int id)
    {
        // var categorie = BiblioInitializer.Categories.FirstOrDefault(c => c.Id == id);
        var categorie = await _context.Categories.FindAsync(id);
        if (categorie == null)
        {
            return NotFound();
        }

        _context.Categories.Remove(categorie);
        await _context.SaveChangesAsync(); // Save to DB

        return NoContent();
    }
}