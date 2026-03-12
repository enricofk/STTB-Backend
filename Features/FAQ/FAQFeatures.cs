using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using STTB.Backend.Data;
using FAQModel = STTB.Backend.Models.FAQ;

namespace STTB.Backend.Features.FAQ
{
    // COMMAND
    public class CreateFAQCommand : IRequest<int>
    {
        public string Pertanyaan { get; set; }
        public string Jawaban { get; set; }
    }
    public class CreateFAQValidator : AbstractValidator<CreateFAQCommand>
    {
        public CreateFAQValidator()
        {
            RuleFor(x => x.Pertanyaan).NotEmpty();
            RuleFor(x => x.Jawaban).NotEmpty();
        }
    }
    public class CreateFAQHandler : IRequestHandler<CreateFAQCommand, int>
    {
        private readonly AppDbContext _context;
        public CreateFAQHandler(AppDbContext context) => _context = context;
        public async Task<int> Handle(CreateFAQCommand request, CancellationToken cancellationToken)
        {
            var model = new FAQModel { Pertanyaan = request.Pertanyaan, Jawaban = request.Jawaban };
            _context.FAQs.Add(model);
            await _context.SaveChangesAsync(cancellationToken);
            return model.Id;
        }
    }

    // QUERY
    public class GetFAQQuery : IRequest<List<FAQModel>> { }
    public class GetFAQHandler : IRequestHandler<GetFAQQuery, List<FAQModel>>
    {
        private readonly AppDbContext _context;
        public GetFAQHandler(AppDbContext context) => _context = context;
        public async Task<List<FAQModel>> Handle(GetFAQQuery request, CancellationToken cancellationToken) =>
            await _context.FAQs.ToListAsync(cancellationToken);
    }
}