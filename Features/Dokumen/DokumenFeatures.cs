using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using STTB.Backend.Data;
using DokumenModel = STTB.Backend.Models.Dokumen_Unduhan;

namespace STTB.Backend.Features.Dokumen
{
    // COMMAND
    public class CreateDokumenCommand : IRequest<int>
    {
        public string NamaDokumen { get; set; }
        public string LinkFile { get; set; }
    }
    public class CreateDokumenValidator : AbstractValidator<CreateDokumenCommand>
    {
        public CreateDokumenValidator()
        {
            RuleFor(x => x.NamaDokumen).NotEmpty();
            RuleFor(x => x.LinkFile).NotEmpty();
        }
    }
    public class CreateDokumenHandler : IRequestHandler<CreateDokumenCommand, int>
    {
        private readonly AppDbContext _context;
        public CreateDokumenHandler(AppDbContext context) => _context = context;
        public async Task<int> Handle(CreateDokumenCommand request, CancellationToken cancellationToken)
        {
            var model = new DokumenModel { Nama_Dokumen = request.NamaDokumen, Link_File = request.LinkFile };
            _context.Dokumen_Unduhans.Add(model);
            await _context.SaveChangesAsync(cancellationToken);
            return model.Id;
        }
    }

    // QUERY
    public class GetDokumenQuery : IRequest<List<DokumenModel>> { }
    public class GetDokumenHandler : IRequestHandler<GetDokumenQuery, List<DokumenModel>>
    {
        private readonly AppDbContext _context;
        public GetDokumenHandler(AppDbContext context) => _context = context;
        public async Task<List<DokumenModel>> Handle(GetDokumenQuery request, CancellationToken cancellationToken) =>
            await _context.Dokumen_Unduhans.ToListAsync(cancellationToken);
    }
}