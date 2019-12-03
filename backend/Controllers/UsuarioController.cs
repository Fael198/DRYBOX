using Microsoft.AspNetCore.Mvc;
using DRYBOX.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DRYBOX.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class UsuarioController : ControllerBase
  {
    private readonly ApiDbContext _context;

    public UsuarioController(ApiDbContext context)
    {
        _context = context;
    }

    // GET: api/Usuario
    [HttpGet]
    public ActionResult<IEnumerable<Usuario>> Get()
    {
      return _context.Usuarios;
    }

    // GET: api/Usuario/
    [HttpGet("{id}")]
    public ActionResult<Usuario> GetById(int id)
    {
      var item = _context.Usuarios.Find(id);

      if (item == null)
      {
        return NotFound();
      }

      return item;
    }

    // POST: api/Usuario
    [HttpPost]
    public ActionResult<Usuario> Post(Usuario item)
    {
      _context.Usuarios.Add(item);
      _context.SaveChanges();

      return CreatedAtAction(nameof(GetById), new { id = item.Id }, item);
    }

    // PUT: api/Usuario/
    [HttpPut("{id}")]
    public IActionResult Put(int id, Usuario item)
    {
      if (id != item.Id)
      {
        return BadRequest();
      }

      _context.Entry(item).State = EntityState.Modified;
      _context.SaveChanges();

      return NoContent();
    }

    // DELETE: api/Usuario/
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
      var item = _context.Usuarios.Find(id);

      if (item == null)
      {
        return NotFound();
      }

      _context.Usuarios.Remove(item);
      _context.SaveChangesAsync();

      return NoContent();
    }
  }
}
