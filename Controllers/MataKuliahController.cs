using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using STTB.Backend.Features.MataKuliah.Commands;
using STTB.Backend.Features.MataKuliah.Queries;

namespace STTB.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MataKuliahController : ControllerBase
    {
        private readonly IMediator _mediator;
        public MataKuliahController(IMediator mediator) => _mediator = mediator;

        [HttpPost, Authorize]
        public async Task<IActionResult> Create(CreateMataKuliahCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(Create), new { id }, new { id, message = "Mata Kuliah berhasil ditambahkan!" });
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _mediator.Send(new GetMataKuliahQuery()));
    }
}