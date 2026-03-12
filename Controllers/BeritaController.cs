using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using STTB.Backend.Data;
using STTB.Backend.Models;

namespace STTB.Backend.Controllers
{
    // Route URL nanti akan menjadi: /api/berita
    [Route("api/[controller]")]
    [ApiController]
    public class BeritaController : ControllerBase
    {
        private readonly AppDbContext _context;

        // Constructor untuk menyambungkan Controller dengan Database (Dependency Injection)
        public BeritaController(AppDbContext context)
        {
            _context = context;
        }

        // --- ENDPOINT 1: MENGAMBIL SEMUA DATA BERITA ---
        // GET: api/berita
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Berita>>> GetBerita()
        {
            var beritaList = await _context.Beritas
                                           .Include(b => b.Kategori_Berita)
                                           .ToListAsync();
            return Ok(beritaList);
        }

        // --- ENDPOINT 2: MENAMBAH DATA BERITA BARU ---
        // POST: api/berita
        [HttpPost]
        public async Task<ActionResult<Berita>> PostBerita(Berita berita)
        {
            // Menambahkan data baru ke tabel
            _context.Beritas.Add(berita);
            await _context.SaveChangesAsync(); // Simpan perubahan ke Database

            return Ok(berita);
        }
    }
}