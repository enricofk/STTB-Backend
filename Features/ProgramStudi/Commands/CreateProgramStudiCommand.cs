using FluentValidation;
using MediatR;
using STTB.Backend.Data;
using ProgramStudiModel = STTB.Backend.Models.Program_Studi;

namespace STTB.Backend.Features.ProgramStudi.Commands
{
    public class CreateProgramStudiCommand : IRequest<int>
    {
        public string Tingkat { get; set; }
        public string NamaProdi { get; set; }
        public int? KetuaProdiId { get; set; } 
    }

    public class CreateProgramStudiValidator : AbstractValidator<CreateProgramStudiCommand>
    {
        public CreateProgramStudiValidator()
        {
            RuleFor(x => x.Tingkat).NotEmpty().WithMessage("Tingkat (misal: S1/S2) wajib diisi.");
            RuleFor(x => x.NamaProdi).NotEmpty().WithMessage("Nama Program Studi wajib diisi.");
        }
    }

    public class CreateProgramStudiHandler : IRequestHandler<CreateProgramStudiCommand, int>
    {
        private readonly AppDbContext _context;
        public CreateProgramStudiHandler(AppDbContext context) => _context = context;

        public async Task<int> Handle(CreateProgramStudiCommand request, CancellationToken cancellationToken)
        {
            var model = new ProgramStudiModel
            {
                Tingkat = request.Tingkat,
                Nama_Prodi = request.NamaProdi,
                Ketua_Prodi_Id = request.KetuaProdiId
            };
            _context.Program_Studis.Add(model);
            await _context.SaveChangesAsync(cancellationToken);
            return model.Id;
        }
    }
}