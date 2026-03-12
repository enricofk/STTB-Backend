using MediatR;
using STTB.Backend.Data;

namespace STTB.Backend.Features.FAQ
{
    public class DeleteFAQCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }

    // HANDLER
    public class DeleteFAQHandler : IRequestHandler<DeleteFAQCommand, bool>
    {
        private readonly AppDbContext _context;
        public DeleteFAQHandler(AppDbContext context) => _context = context;

        public async Task<bool> Handle(DeleteFAQCommand request, CancellationToken cancellationToken)
        {
            var faq = await _context.FAQs.FindAsync(new object[] { request.Id }, cancellationToken);
            if (faq == null) return false;

            _context.FAQs.Remove(faq);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}