using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using STTB.Backend.Features.Kegiatan.Commands;
using STTB.Backend.Features.Kegiatan.Queries;

namespace STTB.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KegiatanController : ControllerBase
    {
        private readonly IMediator _mediator;

        public KegiatanController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Authorize] 
        public async Task<IActionResult> Create(CreateKegiatanCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(Create), new { id }, new { id, message = "Kegiatan berhasil ditambahkan ke kalender!" });
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetKegiatanQuery());
            return Ok(result);
        }
    }
}