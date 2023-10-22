using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CretaceousApi.Models;

namespace CretaceousApi.Controllers;

[Route("api/[controller]")] // we specify the base request URL for this controller
[ApiController]
public class AnimalsController : ControllerBase
{
  private readonly CretaceousApiContext _db;

  public AnimalsController(CretaceousApiContext db)
  {
    _db = db;
  }

  // the base request URL for this Controller
  // GET api/animals
  [HttpGet]
  public async Task<ActionResult<IEnumerable<Animal>>> Get([FromQuery] string species, [FromQuery] string name, [FromQuery] int minimumAge, int age)
  {
    IQueryable<Animal> query = _db.Animals.AsQueryable();

    if (species != null)
      query = query.Where(entry => entry.Species == species);

    if (name != null)
      query = query.Where(entry => entry.Name == name);

    if (minimumAge > 0)
      query = query.Where(entry => entry.Age >= minimumAge);

    // the DEFAULT value for an integer parameter is 0,
    // when no value for the parameter is received
    if (age != 0)
      query = query.Where(entry => entry.Age == age);
    
    return await query.ToListAsync();
  }

  // GET api/animals/{id}
  [HttpGet("{id}")]
  public async Task<ActionResult<Animal>> GetAnimal(int id)
  {
    Animal animal = await _db.Animals.FindAsync(id);

    if (animal == null) 
      return NotFound(); // ControllerBase class method NotFound() returns a 404 status code response

    return animal;
  }

  // POST api/animals
  [HttpPost]
  public async Task<ActionResult<Animal>> Post([FromBody] Animal animal)
  {
    _db.Animals.Add(animal);
    await _db.SaveChangesAsync();
    return CreatedAtAction(nameof(GetAnimal), new { id = animal.AnimalId }, animal);
  }

  // PUT api/animals/{id}
  [HttpPut("{id}")]
  public async Task<IActionResult> Put(int id, Animal animal)
  {
    if (id != animal.AnimalId)
      return BadRequest();

    _db.Animals.Update(animal);

    try
    {
      await _db.SaveChangesAsync();
    }
    catch (DbUpdateConcurrencyException)
    {
      if (!AnimalExists(id))
        return NotFound();
      else
        throw;
    }

    // 204 No Content success status indicates the request succeeded, 
    // but the client doesn't need to navigate away from the current page
    return NoContent(); 
  }

  // Return true of false after checking if any
  // Animal in the database has the given ID
  private bool AnimalExists(int id)
  {
    return _db.Animals.Any(e => e.AnimalId == id);
  }

  // DELETE api/animals/{id}
  [HttpDelete("{id}")]
  public async Task<IActionResult> DeleteAnimal(int id)
  {
    Animal animal = await _db.Animals.FindAsync(id);
    if (animal == null)
      return NotFound();

    _db.Animals.Remove(animal);
    await _db.SaveChangesAsync();

    return NoContent();
  }
}