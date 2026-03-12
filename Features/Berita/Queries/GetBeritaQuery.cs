using MediatR;
using Microsoft.EntityFrameworkCore;
using STTB.Backend.Data;
using BeritaModel = STTB.Backend.Models.Berita; 

namespace STTB.Backend.Features.Berita.Queries
{
    public class GetBeritaQuery : IRequest<List<BeritaModel>> { }

    public class GetBeritaHandler : IRequestHandler<GetBeritaQuery, List<BeritaModel>>
    {
        private readonly AppDbContext _context;

        public GetBeritaHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<BeritaModel>> Handle(GetBeritaQuery request, CancellationToken cancellationToken)
        {
            return await _context.Beritas
                .Include(b => b.Kategori_Berita)
                .OrderByDescending(b => b.Tanggal_Publikasi) 
                .ToListAsync(cancellationToken);
        }
    }
}