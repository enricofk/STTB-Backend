using FluentValidation;
using MediatR;
using STTB.Backend.Data;
using KegiatanModel = STTB.Backend.Models.Kegiatan;

namespace STTB.Backend.Features.Kegiatan.Commands
{
    public class CreateKegiatanCommand : IRequest<int>
    {
        public string NamaKegiatan { get; set; }
        public string Deskripsi { get; set; }
        public DateTime TanggalMulai { get; set; }
        public DateTime TanggalSelesai { get; set; }
        public string Lokasi { get; set; }
        public int KategoriId { get; set; }
    }

    public class CreateKegiatanValidator : AbstractValidator<CreateKegiatanCommand>
    {
        public CreateKegiatanValidator()
        {
            RuleFor(x => x.NamaKegiatan).NotEmpty().WithMessage("Nama Kegiatan wajib diisi.");
            RuleFor(x => x.Deskripsi).NotEmpty();
            RuleFor(x => x.Lokasi).NotEmpty();
            RuleFor(x => x.KategoriId).GreaterThan(0).WithMessage("Kategori Kegiatan harus dipilih.");

            RuleFor(x => x.TanggalSelesai)
                .GreaterThanOrEqualTo(x => x.TanggalMulai)
                .WithMessage("Tanggal Selesai tidak boleh lebih awal dari Tanggal Mulai!");
        }
    }

    public class CreateKegiatanHandler : IRequestHandler<CreateKegiatanCommand, int>
    {
        private readonly AppDbContext _context;

        public CreateKegiatanHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateKegiatanCommand request, CancellationToken cancellationToken)
        {
            var model = new KegiatanModel
            {
                Nama_Kegiatan = request.NamaKegiatan,
                Deskripsi = request.Deskripsi,
                Tanggal_Mulai = request.TanggalMulai,
                Tanggal_Selesai = request.TanggalSelesai,
                Lokasi = request.Lokasi,
                Kategori_Id = request.KategoriId
            };

            _context.Kegiatans.Add(model);
            await _context.SaveChangesAsync(cancellationToken);

            return model.Id;
        }
    }
}