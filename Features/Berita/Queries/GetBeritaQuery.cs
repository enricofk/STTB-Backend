using MediatR;
using Microsoft.EntityFrameworkCore;
using STTB.Backend.Data;
using STTB.Backend.Models;

namespace STTB.Backend.Features.Berita.Queries
{
    public class GetBeritaQuery : IRequest<List<Berita>> { }

    public class GetBeritaHandler : IRequestHandler<GetBeritaQuery, List<Berita>>
    {
        private readonly AppDbContext _context;

        public GetBeritaHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Berita>> Handle(GetBeritaQuery request, CancellationToken cancellationToken)
        {
            return await _context.Berita
            return await _context.Berita
                .Include(b => b.Kategori_Berita)
                .OrderByDescending(b => b.Tanggal_Publish)
                .ToListAsync(cancellationToken);
        }
    }
}