using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using STTB.Backend.Data;
using STTB.Backend.Models;

namespace STTB.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DosenController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DosenController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/dosen
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dosen>>> GetDosen()
        {
            var dosenList = await _context.Dosens.ToListAsync();
            return Ok(dosenList);
        }

        // POST: api/dosen
        [HttpPost]
        public async Task<ActionResult<Dosen>> PostDosen(Dosen dosen)
        {
            _context.Dosens.Add(dosen);
            await _context.SaveChangesAsync();
            return Ok(dosen);
        }
    }
}