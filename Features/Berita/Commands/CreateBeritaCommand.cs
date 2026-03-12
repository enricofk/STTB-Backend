using FluentValidation;
using MediatR;
using STTB.Backend.Data;
using BeritaModel = STTB.Backend.Models.Berita; // Pakai Alias

namespace STTB.Backend.Features.Berita.Commands
{
    public class CreateBeritaCommand : IRequest<int>
    {
        public string Judul { get; set; }
        public string Konten { get; set; }
        public string ThumbnailUrl { get; set; }
        public int KategoriId { get; set; } // Sesuaikan penamaan inputnya
    }

    public class CreateBeritaValidator : AbstractValidator<CreateBeritaCommand>
    {
        public CreateBeritaValidator()
        {
            RuleFor(x => x.Judul).NotEmpty().MaximumLength(200);
            RuleFor(x => x.Konten).NotEmpty();
            RuleFor(x => x.KategoriId).GreaterThan(0).WithMessage("Kategori Berita harus dipilih.");
        }
    }

    public class CreateBeritaHandler : IRequestHandler<CreateBeritaCommand, int>
    {
        private readonly AppDbContext _context;

        public CreateBeritaHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateBeritaCommand request, CancellationToken cancellationToken)
        {
            var model = new BeritaModel
            {
                Judul = request.Judul,
                Slug = request.Judul.ToLower().Replace(" ", "-"),
                Konten = request.Konten,
                Thumbnail_Url = request.ThumbnailUrl,
                Kategori_Id = request.KategoriId,     
                Tanggal_Publikasi = DateTime.UtcNow 
            };

            _context.Beritas.Add(model);
            await _context.SaveChangesAsync(cancellationToken);

            return model.Id;
        }
    }
}