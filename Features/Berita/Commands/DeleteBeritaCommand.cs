using MediatR;
using STTB.Backend.Data;

namespace STTB.Backend.Features.Berita.Commands
{
    // COMMAND
    public class DeleteBeritaCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }

    // HANDLER
    public class DeleteBeritaHandler : IRequestHandler<DeleteBeritaCommand, bool>
    {
        private readonly AppDbContext _context;
        public DeleteBeritaHandler(AppDbContext context) => _context = context;

        public async Task<bool> Handle(DeleteBeritaCommand request, CancellationToken cancellationToken)
        {
            var berita = await _context.Beritas.FindAsync(new object[] { request.Id }, cancellationToken);
            if (berita == null) return false;

            _context.Beritas.Remove(berita);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}