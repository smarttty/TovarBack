using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using test_backend_11_2023.Contexts;
using test_backend_11_2023.Models;

namespace test_backend_11_2023.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TovarVZakazeController : ControllerBase
    {
        private readonly testContext _context;

        public TovarVZakazeController(testContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Tovarvzakaze> Get()
        {
            return _context.Tovarvzakaze.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Tovarvzakaze> Get(int id)
        {
            var tovarvzakaze = _context.Tovarvzakaze.Find(id);

            if (tovarvzakaze == null)
            {
                return NotFound();
            }

            return tovarvzakaze;
        }

        [HttpPost]
        public ActionResult<Tovarvzakaze> Post([FromBody] Tovarvzakaze tovarvzakaze)
        {
            _context.Tovarvzakaze.Add(tovarvzakaze);
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException e)
            {
                if (TovarVZakazeExists(tovarvzakaze.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return tovarvzakaze;
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Tovarvzakaze tovarvzakaze)
        {
            if (id != tovarvzakaze.Id)
            {
                return BadRequest();
            }

            _context.Entry(tovarvzakaze).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TovarVZakazeExists(tovarvzakaze.Id))
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

        [HttpDelete("{id}")]
        public ActionResult<Tovarvzakaze> Delete(int id)
        {
            var tovarvzakaze = _context.Tovarvzakaze.Find(id);
            if (tovarvzakaze == null)
            {
                return NotFound();
            }

            _context.Tovarvzakaze.Remove(tovarvzakaze);
            _context.SaveChanges();

            return tovarvzakaze;
        }

        private bool TovarVZakazeExists(int id)
        {
            return _context.Tovarvzakaze.Any(t => t.Id == id);
        }
    }
}
