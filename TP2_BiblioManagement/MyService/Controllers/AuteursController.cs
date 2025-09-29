using Microsoft.AspNetCore.Mvc;
using BiblioManagement.Models;
using MyService.Data;
using System.Collections.Generic;
using System.Linq;

[ApiController]
[Route("api/[controller]")]
public class AuteursController : ControllerBase
{
    // GET: api/auteurs
    [HttpGet]
    public ActionResult<IEnumerable<Auteur>> GetAuteurs()
    {
        return Ok(BiblioInitializer.Auteurs);
    }

    // GET: api/auteurs/5
    [HttpGet("{id}")]
    public ActionResult<Auteur> GetAuteur(int id)
    {
        var auteur = BiblioInitializer.Auteurs.FirstOrDefault(a => a.Id == id);
        if (auteur == null)
        {
            return NotFound();
        }
        return Ok(auteur);
    }

    // POST: api/auteurs
    [HttpPost]
    public ActionResult<Auteur> PostAuteur(Auteur auteur)
    {
        auteur.Id = BiblioInitializer.Auteurs.Max(a => a.Id) + 1;
        BiblioInitializer.Auteurs.Add(auteur);
        return CreatedAtAction(nameof(GetAuteur), new { id = auteur.Id }, auteur);
    }

    // PUT: api/auteurs/5
    [HttpPut("{id}")]
    public IActionResult PutAuteur(int id, Auteur auteur)
    {
        if (id != auteur.Id)
        {
            return BadRequest();
        }

        var auteurExistant = BiblioInitializer.Auteurs.FirstOrDefault(a => a.Id == id);
        if (auteurExistant == null)
        {
            return NotFound();
        }

        auteurExistant.Nom = auteur.Nom;
        auteurExistant.Prenom = auteur.Prenom;

        return NoContent();
    }

    // DELETE: api/auteurs/5
    [HttpDelete("{id}")]
    public IActionResult DeleteAuteur(int id)
    {
        var auteur = BiblioInitializer.Auteurs.FirstOrDefault(a => a.Id == id);
        if (auteur == null)
        {
            return NotFound();
        }
        BiblioInitializer.Auteurs.Remove(auteur);
        return NoContent();
    }
}