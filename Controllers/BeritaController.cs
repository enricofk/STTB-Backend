using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using STTB.Backend.Features.Berita.Commands;
using STTB.Backend.Features.Berita.Queries;

namespace STTB.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeritaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BeritaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreateBeritaCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(Create), new { id }, new { id, message = "Berita berhasil diterbitkan!" });
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetBeritaQuery());
            return Ok(result);
        }

        [HttpPut("{id}")]
        [Authorize] 
        public async Task<IActionResult> Update(int id, UpdateBeritaCommand command)
        {
            if (id != command.Id)
                return BadRequest("ID pada URL dan body data tidak cocok.");

            var isSuccess = await _mediator.Send(command);

            if (!isSuccess)
                return NotFound(new { message = "Data Berita tidak ditemukan." });

            return Ok(new { message = "Berita berhasil diperbarui!" });
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            var isSuccess = await _mediator.Send(new DeleteBeritaCommand { Id = id });

            if (!isSuccess)
                return NotFound(new { message = "Data Berita tidak ditemukan." });

            return Ok(new { message = "Berita berhasil dihapus!" });
        }
    }
}