using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using test_backend_11_2023.Contexts;
using test_backend_11_2023.Models;

namespace test_backend_11_2023.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TovarController : ControllerBase
    {
        private readonly testContext _context;

        public TovarController(testContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Tovar> Get()
        {
            return _context.Tovar.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Tovar> Get(int id)
        {
            var tovar = _context.Tovar
                .Include(t => t.Tovarvzakaze)
                .ThenInclude(t => t.Zakaz)
                .FirstOrDefault(t => t.Id == id);
            if (tovar == null) {
                return NotFound();
            }

            return tovar;
        }

        [HttpPost]
        public ActionResult<Tovar> Post([FromBody] Tovar tovar)
        {
            _context.Tovar.Add(tovar);
            try
            {
                _context.SaveChanges();
            } catch (DbUpdateException e)
            {
                if (TovarExists(tovar.Id))
                {
                    return Conflict();
                } else
                {
                    throw;
                }
            }

            return tovar;
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Tovar tovar)
        {
            if (id != tovar.Id)
            {
                return BadRequest();
            }

            _context.Entry(tovar).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            } catch (DbUpdateConcurrencyException)
            {
                if(!TovarExists(tovar.Id))
                {
                    return NotFound();
                } else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult<Tovar> Delete(int id)
        {
            var tovar = _context.Tovar.Find(id);
            if (tovar == null)
            {
                return NotFound();
            }

            _context.Tovarvzakaze.RemoveRange(_context.Tovarvzakaze.Where(tz => tz.TovarId == id));
            _context.Tovar.Remove(tovar);
            _context.SaveChanges();

            return tovar;
        }

        private bool TovarExists(int id) { 
            return _context.Tovar.Any(t => t.Id == id);
        }
    }
}
