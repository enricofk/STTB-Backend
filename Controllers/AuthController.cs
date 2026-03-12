using MediatR;
using Microsoft.AspNetCore.Mvc;
using STTB.Backend.Features.Auth.Commands;
using STTB.Backend.Features.Auth.Queries;

namespace STTB.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(Register), new { id }, new { id, message = "User berhasil didaftarkan!" });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginQuery query)
        {
            // Mediator akan mengembalikan string token
            var token = await _mediator.Send(query);

            return Ok(new
            {
                message = "Login berhasil",
                token = token
            });
        }
    }
}