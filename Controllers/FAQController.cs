using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using STTB.Backend.Features.FAQ;

namespace STTB.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FAQController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FAQController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Authorize] 
        public async Task<IActionResult> Create(CreateFAQCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(Create), new { id }, new { id, message = "FAQ berhasil ditambahkan!" });
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetFAQQuery());
            return Ok(result);
        }

        [HttpPut("{id}")]
        [Authorize] 
        public async Task<IActionResult> Update(int id, UpdateFAQCommand command)
        {
            if (id != command.Id)
                return BadRequest("ID pada URL dan body data tidak cocok.");

            var isSuccess = await _mediator.Send(command);

            if (!isSuccess)
                return NotFound(new { message = "Data FAQ tidak ditemukan." });

            return Ok(new { message = "FAQ berhasil diperbarui!" });
        }

        [HttpDelete("{id}")]
        [Authorize] 
        public async Task<IActionResult> Delete(int id)
        {
            var isSuccess = await _mediator.Send(new DeleteFAQCommand    { Id = id });

            if (!isSuccess)
                return NotFound(new { message = "Data FAQ tidak ditemukan." });

            return Ok(new { message = "FAQ berhasil dihapus!" });
        }
    }
}