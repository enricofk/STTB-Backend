using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using STTB.Backend.Data;
using STTB.Backend.Models;

namespace STTB.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DokumenUnduhanController : ControllerBase
    {
        private readonly AppDbContext _context;
        public DokumenUnduhanController(AppDbContext context) => _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dokumen_Unduhan>>> GetDokumen() => await _context.Dokumen_Unduhans.ToListAsync();

        [HttpPost]
        public async Task<ActionResult<Dokumen_Unduhan>> PostDokumen(Dokumen_Unduhan dokumen)
        {
            _context.Dokumen_Unduhans.Add(dokumen);
            await _context.SaveChangesAsync();
            return Ok(dokumen);
        }
    }
}