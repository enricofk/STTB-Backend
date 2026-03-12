using FluentValidation;
using MediatR;
using STTB.Backend.Data;

namespace STTB.Backend.Features.FAQ
{
    // COMMAND
    public class UpdateFAQCommand : IRequest<bool> 
    {
        public int Id { get; set; }
        public string Pertanyaan { get; set; }
        public string Jawaban { get; set; }
    }

    // VALIDATOR
    public class UpdateFAQValidator : AbstractValidator<UpdateFAQCommand>
    {
        public UpdateFAQValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("ID tidak valid.");
            RuleFor(x => x.Pertanyaan).NotEmpty().WithMessage("Pertanyaan tidak boleh kosong.");
            RuleFor(x => x.Jawaban).NotEmpty().WithMessage("Jawaban tidak boleh kosong.");
        }
    }

    // HANDLER
    public class UpdateFAQHandler : IRequestHandler<UpdateFAQCommand, bool>
    {
        private readonly AppDbContext _context;
        public UpdateFAQHandler(AppDbContext context) => _context = context;

        public async Task<bool> Handle(UpdateFAQCommand request, CancellationToken cancellationToken)
        {
            var faq = await _context.FAQs.FindAsync(new object[] { request.Id }, cancellationToken);

            if (faq == null) return false;

            faq.Pertanyaan = request.Pertanyaan;
            faq.Jawaban = request.Jawaban;

            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}