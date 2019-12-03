using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DRYBOX.Models;

namespace DRYBOX.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class MaterialController : ControllerBase
  {
    private readonly ApiDbContext _context;

    public MaterialController(ApiDbContext context)
    {
      _context = context;
    }

    // GET: api/Material
    [HttpGet]
    public ActionResult<IEnumerable<Material>> Get()
    {
      return _context.Materiais;
    }

    // GET: api/Materiais/
    [HttpGet("{id}")]
    public ActionResult<Material> GetById(int id)
    {
      var item = _context.Materiais.Find(id);

      if (item == null)
      {
        return NotFound();
      }

      return item;
    }

    // POST: api/Material
    [HttpPost]
    public ActionResult<Material> Post(Material item)
    {
      _context.Materiais.Add(item);
      _context.SaveChanges();

      return CreatedAtAction(nameof(GetById), new { id = item.Id }, item);
    }

    // PUT: api/Material/
    [HttpPut("{id}")]
    public IActionResult Put(int id, Material item)
    {
      if (id != item.Id)
      {
        return BadRequest();
      }

      _context.Entry(item).State = EntityState.Modified;
      _context.SaveChanges();

      return NoContent();
    }

    // DELETE: api/Material/
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
      var item = _context.Materiais.Find(id);

      if (item == null)
      {
        return NotFound();
      }

      _context.Materiais.Remove(item);
      _context.SaveChangesAsync();

      return NoContent();
    }
  }
}
