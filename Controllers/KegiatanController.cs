using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using STTB.Backend.Data;
using STTB.Backend.Models;

namespace STTB.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KegiatanController : ControllerBase
    {
        private readonly AppDbContext _context;

        public KegiatanController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Kegiatan
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Kegiatan>>> GetKegiatan()
        {
            var kegiatanList = await _context.Kegiatans
                                             .Include(k => k.Kategori_Kegiatan)
                                             .ToListAsync();
            return Ok(kegiatanList);
        }

        // POST: api/Kegiatan
        [HttpPost]
        public async Task<ActionResult<Kegiatan>> PostKegiatan(Kegiatan kegiatan)
        {
            _context.Kegiatans.Add(kegiatan);
            await _context.SaveChangesAsync();
            return Ok(kegiatan);
        }
    }
}