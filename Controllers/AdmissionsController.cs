using MediatR;
using Microsoft.AspNetCore.Mvc;
using STTB.Backend.Features.Admissions.Commands;

namespace STTB.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdmissionsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AdmissionsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("apply")]
        public async Task<IActionResult> Apply(CreateAdmissionCommand command)
        {
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(Apply), new { id }, new { id, message = "Pendaftaran berhasil disubmit! Silakan tunggu email balasan dari kami." });
        }
    }
}