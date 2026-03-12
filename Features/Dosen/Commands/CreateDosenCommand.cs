using FluentValidation;
using MediatR;
using STTB.Backend.Data;
// Menggunakan Alias agar tidak bentrok dengan nama Folder
using DosenModel = STTB.Backend.Models.Dosen;

namespace STTB.Backend.Features.Dosen.Commands
{
    public class CreateDosenCommand : IRequest<int>
    {
        public string NamaLengkap { get; set; }
        public string BidangKeahlian { get; set; }
        public string PendidikanTerakhir { get; set; }
    }

    // Satpam Validasi untuk Dosen
    public class CreateDosenValidator : AbstractValidator<CreateDosenCommand>
    {
        public CreateDosenValidator()
        {
            RuleFor(x => x.NamaLengkap)
                .NotEmpty().WithMessage("Nama Lengkap wajib diisi.");

            RuleFor(x => x.BidangKeahlian)
                .NotEmpty().WithMessage("Bidang Keahlian wajib diisi.");

            RuleFor(x => x.PendidikanTerakhir)
                .NotEmpty().WithMessage("Pendidikan Terakhir wajib diisi.");
        }
    }

    public class CreateDosenHandler : IRequestHandler<CreateDosenCommand, int>
    {
        private readonly AppDbContext _context;

        public CreateDosenHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateDosenCommand request, CancellationToken cancellationToken)
        {
            var model = new DosenModel
            {
                Nama_Lengkap = request.NamaLengkap,
                Bidang_Keahlian = request.BidangKeahlian,
                Pendidikan_Terakhir = request.PendidikanTerakhir
            };

            // Menyimpan ke DbSet 'Dosens' sesuai dengan AppDbContext milikmu
            _context.Dosens.Add(model);
            await _context.SaveChangesAsync(cancellationToken);

            return model.Id;
        }
    }
}