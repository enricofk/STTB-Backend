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

        // Dependency Injection untuk MediatR
        public FasilitasController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Authorize] // Tetap aman dengan gembok JWT
        public async Task<IActionResult> Create(CreateFasilitasCommand command)
        {
            // Point Killer #5: Menggunakan async await
            // Point Killer #1: Validasi otomatis berjalan di background lewat Pipeline
            var result = await _mediator.Send(command);

            // Point Killer #3: HTTP Response Code 201 untuk Created
            return CreatedAtAction(nameof(Create), new { id = result }, new { id = result, message = "Fasilitas berhasil ditambahkan" });
        }

        /* Nanti untuk GET, UPDATE, dan DELETE, kamu tinggal buat folder:
           - Features/Fasilitas/Queries/GetFasilitasQuery.cs
           - Features/Fasilitas/Commands/UpdateFasilitasCommand.cs
           Lalu panggil dengan cara yang sama: await _mediator.Send(new YourCommand());
        */
    }
}