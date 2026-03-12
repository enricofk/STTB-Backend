using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using STTB.Backend.Features.Dosen.Commands;
using STTB.Backend.Features.Dosen.Queries;

namespace STTB.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DosenController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DosenController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Authorize] 
        public async Task<IActionResult> Create(CreateDosenCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(Create), new { id }, new { id, message = "Data Dosen berhasil ditambahkan!" });
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetDosenQuery());
            return Ok(result);
        }
    }
}