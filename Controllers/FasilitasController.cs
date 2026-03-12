using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using STTB.Backend.Features.Fasilitas.Commands;

namespace STTB.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FasilitasController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FasilitasController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Authorize] 
        public async Task<IActionResult> Create(CreateFasilitasCommand command)
        {
            var result = await _mediator.Send(command);

            return CreatedAtAction(nameof(Create), new { id = result }, new { id = result, message = "Fasilitas berhasil ditambahkan" });
        }


    }
}