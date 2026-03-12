using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using STTB.Backend.Data;
using STTB.Backend.Models;

namespace STTB.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgramStudiController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProgramStudiController(AppDbContext context)
        {
            _context = context;
        }

        // --- ENDPOINT GET: MENGAMBIL DATA PRODI BESERTA DETAILNYA ---
        // GET: api/ProgramStudi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Program_Studi>>> GetProgramStudi()
        {
            // Ambil semua Program Studi beserta detail Ketua Prodi dan daftar Mata Kuliah
            var prodiList = await _context.Program_Studis
                                          .Include(p => p.Ketua_Prodi)
                                          .Include(p => p.Mata_Kuliahs)
                                          .ToListAsync();
            return Ok(prodiList);
        }

        // --- ENDPOINT PUT: MENGUPDATE KETUA PRODI ---
        // PUT: api/ProgramStudi/update-ketua/1
        [HttpPut("update-ketua/{id}")]
        public async Task<IActionResult> UpdateKetuaProdi(int id, [FromBody] int dosenId)
        {
            var prodi = await _context.Program_Studis.FindAsync(id);
            if (prodi == null)
            {
                return NotFound("Program Studi tidak ditemukan.");
            }

            // Update ID Ketua Prodi
            prodi.Ketua_Prodi_Id = dosenId;
            await _context.SaveChangesAsync();

            return Ok(new { message = "Ketua Prodi berhasil diperbarui!", data = prodi });
        }
    }
}