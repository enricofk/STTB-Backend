using FluentValidation;
using MediatR;
using STTB.Backend.Data;

namespace STTB.Backend.Features.Berita.Commands
{
    // COMMAND
    public class UpdateBeritaCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string Judul { get; set; }
        public string Konten { get; set; }
        public string ThumbnailUrl { get; set; }
        public int KategoriId { get; set; }
    }

    // VALIDATOR
    public class UpdateBeritaValidator : AbstractValidator<UpdateBeritaCommand>
    {
        public UpdateBeritaValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("ID Berita tidak valid.");
            RuleFor(x => x.Judul).NotEmpty().MaximumLength(200);
            RuleFor(x => x.Konten).NotEmpty();
            RuleFor(x => x.KategoriId).GreaterThan(0).WithMessage("Kategori Berita harus dipilih.");
        }
    }

    // HANDLER
    public class UpdateBeritaHandler : IRequestHandler<UpdateBeritaCommand, bool>
    {
        private readonly AppDbContext _context;
        public UpdateBeritaHandler(AppDbContext context) => _context = context;

        public async Task<bool> Handle(UpdateBeritaCommand request, CancellationToken cancellationToken)
        {
            var berita = await _context.Beritas.FindAsync(new object[] { request.Id }, cancellationToken);
            if (berita == null) return false;

            berita.Judul = request.Judul;
            berita.Slug = request.Judul.ToLower().Replace(" ", "-"); 
            berita.Konten = request.Konten;
            berita.Thumbnail_Url = request.ThumbnailUrl; 
            berita.Kategori_Id = request.KategoriId;    

            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}