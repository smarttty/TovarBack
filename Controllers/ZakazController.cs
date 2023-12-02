using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using test_backend_11_2023.Contexts;
using test_backend_11_2023.Models;

namespace test_backend_11_2023.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZakazController : ControllerBase
    {
        private readonly testContext _context;

        public ZakazController(testContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Zakaz> Get()
        {
            return _context.Zakaz.ToList();
        }
    }
}
