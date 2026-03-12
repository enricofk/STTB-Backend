using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using STTB.Backend.Data;
using STTB.Backend.Models;

namespace STTB.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FasilitasController : ControllerBase
    {
        private readonly AppDbContext _context;
        public FasilitasController(AppDbContext context) => _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Fasilitas>>> GetFasilitas() => await _context.Fasilitas.ToListAsync();

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Fasilitas>> PostFasilitas(Fasilitas fasilitas)
        {
            _context.Fasilitas.Add(fasilitas);
            await _context.SaveChangesAsync();
            return Ok(fasilitas);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteFasilitas(int id)
        {
            var fasilitas = await _context.Fasilitas.FindAsync(id);
            if (fasilitas == null)
            {
                return NotFound(new { message = "Data tidak ditemukan!" });
            }

            _context.Fasilitas.Remove(fasilitas);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Data fasilitas berhasil dihapus!" });
        }
    }
}