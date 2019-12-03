using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DRYBOX.Models;

namespace DRYBOX.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstoqueController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public EstoqueController(ApiDbContext context)
        {
            _context = context;
        }

        // GET: api/Estoques
        [HttpGet]
        public ActionResult<IEnumerable<Estoque>> Get()
        {
            return _context.Estoques;
        }

        // GET: api/Estoques/5
        [HttpGet("{id}")]
        public ActionResult<Estoque> GetById(int id)
        {
            var item = _context.Estoques.Find(id);

            if (item == null)
            {
                return NotFound();
            }

            return item;
        }

        // POST: api/Estoques
        [HttpPost]
        public ActionResult<Estoque> Post(Estoque item)
        {
            _context.Estoques.Add(item);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = item.Id }, item);
        }

        // PUT: api/Estoques/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, Estoque item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }

            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: api/Estoques/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var item = _context.Estoques.Find(id);

            if (item == null)
            {
                return NotFound();
            }

            _context.Estoques.Remove(item);
            _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
