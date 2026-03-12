using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using STTB.Backend.Data;
using STTB.Backend.Models;

namespace STTB.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MataKuliahController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MataKuliahController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/matakuliah
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mata_Kuliah>>> GetMataKuliah()
        {
            // Mengambil daftar MK beserta nama Prodinya (JOIN)
            var mkList = await _context.Mata_Kuliahs
                                       .Include(m => m.Program_Studi)
                                       .ToListAsync();
            return Ok(mkList);
        }

        // POST: api/matakuliah
        [HttpPost]
        public async Task<ActionResult<Mata_Kuliah>> PostMataKuliah(Mata_Kuliah mk)
        {
            _context.Mata_Kuliahs.Add(mk);
            await _context.SaveChangesAsync();
            return Ok(mk);
        }
    }
}