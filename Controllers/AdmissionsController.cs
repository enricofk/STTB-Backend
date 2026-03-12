using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using STTB.Backend.Data;
using STTB.Backend.Models;

namespace STTB.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdmissionsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AdmissionsController(AppDbContext context)
        {
            _context = context;
        }

        // --- ENDPOINT 1: TERIMA DATA DARI FORM FRONTEND (POST) ---
        // POST: api/admissions/apply
        [HttpPost("apply")]
        public async Task<ActionResult<Form_Pendaftaran>> SubmitApplication(Form_Pendaftaran form)
        {
            // Pastikan data tersimpan ke database
            _context.Form_Pendaftarans.Add(form);
            await _context.SaveChangesAsync();

            // Kembalikan respons sukses ke Frontend temanmu
            return Ok(new { message = "Pendaftaran berhasil disubmit!", data = form });
        }

        // --- ENDPOINT 2: LIHAT DATA PENDAFTAR UNTUK CMS ADMIN (GET) ---
        // GET: api/admissions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Form_Pendaftaran>>> GetAllApplications()
        {
            // Ambil data pendaftar sekalian di-JOIN dengan nama Program Studinya
            var pendaftarList = await _context.Form_Pendaftarans
                                              .Include(p => p.Program_Studi)
                                              .ToListAsync();
            return Ok(pendaftarList);
        }
    }
}