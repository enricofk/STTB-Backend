using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using STTB.Backend.Data;
using STTB.Backend.Models;

namespace STTB.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FAQController : ControllerBase
    {
        private readonly AppDbContext _context;
        public FAQController(AppDbContext context) => _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FAQ>>> GetFAQs() => await _context.FAQs.ToListAsync();

        [HttpPost]
        public async Task<ActionResult<FAQ>> PostFAQ(FAQ faq)
        {
            _context.FAQs.Add(faq);
            await _context.SaveChangesAsync();
            return Ok(faq);
        }
    }
}