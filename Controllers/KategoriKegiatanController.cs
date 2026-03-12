using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using STTB.Backend.Data;
using STTB.Backend.Models;

namespace STTB.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KategoriKegiatanController : ControllerBase
    {
        private readonly AppDbContext _context;

        public KategoriKegiatanController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/KategoriKegiatan
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Kategori_Kegiatan>>> GetKategoriKegiatan()
        {
            var kategoriList = await _context.Kategori_Kegiatans.ToListAsync();
            return Ok(kategoriList);
        }

        // POST: api/KategoriKegiatan
        [HttpPost]
        public async Task<ActionResult<Kategori_Kegiatan>> PostKategoriKegiatan(Kategori_Kegiatan kategori)
        {
            _context.Kategori_Kegiatans.Add(kategori);
            await _context.SaveChangesAsync();
            return Ok(kategori);
        }
    }
}