using FluentValidation;
using MediatR;
using STTB.Backend.Data;
using FasilitasModel = STTB.Backend.Models.Fasilitas;

namespace STTB.Backend.Features.Fasilitas.Commands
{
    public class CreateFasilitasCommand : IRequest<int>
    {
        public string NamaFasilitas { get; set; }
        public string Deskripsi { get; set; }
        public string FotoUrl { get; set; }
    }

    public class CreateFasilitasValidator : AbstractValidator<CreateFasilitasCommand>
    {
        public CreateFasilitasValidator()
        {
            RuleFor(x => x.NamaFasilitas).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Deskripsi).NotEmpty();
        }
    }

    public class CreateFasilitasHandler : IRequestHandler<CreateFasilitasCommand, int>
    {
        private readonly AppDbContext _context;

        public CreateFasilitasHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateFasilitasCommand request, CancellationToken cancellationToken)
        {
            var model = new FasilitasModel
            {
                Nama_Fasilitas = request.NamaFasilitas,
                Deskripsi = request.Deskripsi,
                Foto_Url = request.FotoUrl
            };

            _context.Fasilitas.Add(model);
            await _context.SaveChangesAsync(cancellationToken);

            return model.Id;
        }
    }
}