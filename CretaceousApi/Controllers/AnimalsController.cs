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
  public async Task<ActionResult<IEnumerable<Animal>>> Get()
  {
    return await _db.Animals.ToListAsync();
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
  public async Task<ActionResult<Animal>> Post(Animal animal)
  {
    _db.Animals.Add(animal);
    await _db.SaveChangesAsync();
    return CreatedAtAction(nameof(GetAnimal), new { id = animal.AnimalId }, animal);
  }
}