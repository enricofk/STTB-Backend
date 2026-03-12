using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using STTB.Backend.Features.ProgramStudi.Commands;
using STTB.Backend.Features.ProgramStudi.Queries;

namespace STTB.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgramStudiController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProgramStudiController(IMediator mediator) => _mediator = mediator;

        [HttpPost, Authorize]
        public async Task<IActionResult> Create(CreateProgramStudiCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(Create), new { id }, new { id, message = "Prodi berhasil ditambahkan!" });
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _mediator.Send(new GetProgramStudiQuery()));
    }
}