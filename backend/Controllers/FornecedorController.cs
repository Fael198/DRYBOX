using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DRYBOX.Models;

namespace DRYBOX.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FornecedorController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public FornecedorController(ApiDbContext context)
        {
            _context = context;
        }

        // GET: api/Fornecedor
        [HttpGet]
        public ActionResult<IEnumerable<Fornecedor>> Get()
        {
            return _context.Fornecedores;
        }

        // GET: api/Fornecedor/
        [HttpGet("{id}")]
        public ActionResult<Fornecedor> GetById(int id)
        {
            var item = _context.Fornecedores.Find(id);

            if (item == null)
            {
                return NotFound();
            }

            return item;
        }

        // POST: api/Fornecedor
        [HttpPost]
        public ActionResult<Fornecedor> Post(Fornecedor item)
        {
            _context.Fornecedores.Add(item);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = item.Id }, item);
        }

        // PUT: api/Fornecedor/
        [HttpPut("{id}")]
        public IActionResult Put(int id, Fornecedor item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }

            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: api/Fornecedor/
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var item = _context.Fornecedores.Find(id);

            if (item == null)
            {
                return NotFound();
            }

            _context.Fornecedores.Remove(item);
            _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
