using FluentValidation;
using MediatR;
using STTB.Backend.Data;
using BeritaModel = STTB.Backend.Models.Berita;

namespace STTB.Backend.Features.Berita.Commands
{
    public class CreateBeritaCommand : IRequest<int>
    {
        public string Judul { get; set; }
        public string Konten { get; set; }
        public string ThumbnailUrl { get; set; }
        public int KategoriBeritaId { get; set; }
    }

    // Point Killer #1: FluentValidation
    public class CreateBeritaValidator : AbstractValidator<CreateBeritaCommand>
    {
        public CreateBeritaValidator()
        {
            RuleFor(x => x.Judul).NotEmpty().MaximumLength(200);
            RuleFor(x => x.Konten).NotEmpty();
            RuleFor(x => x.KategoriBeritaId).GreaterThan(0).WithMessage("Kategori Berita harus dipilih.");
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
            // Point Killer #5: Async Await & Acceloka Coding Conv (LINQ Lambda)
            var model = new BeritaModel
            {
                Judul = request.Judul,
                Slug = request.Judul.ToLower().Replace(" ", "-"), // Contoh logic sederhana
                Konten = request.Konten,
                Thumbnail_Url = request.ThumbnailUrl,
                Kategori_Berita_Id = request.KategoriBeritaId,
                Tanggal_Publish = DateTime.UtcNow
            };

            _context.Berita.Add(model);
            await _context.SaveChangesAsync(cancellationToken);

            return model.Id;
        }
    }
}