using MediatR;
using Microsoft.EntityFrameworkCore;
using STTB.Backend.Data;
using KegiatanModel = STTB.Backend.Models.Kegiatan;

namespace STTB.Backend.Features.Kegiatan.Queries
{
    public class GetKegiatanQuery : IRequest<List<KegiatanModel>> { }

    public class GetKegiatanHandler : IRequestHandler<GetKegiatanQuery, List<KegiatanModel>>
    {
        private readonly AppDbContext _context;

        public GetKegiatanHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<KegiatanModel>> Handle(GetKegiatanQuery request, CancellationToken cancellationToken)
        {
            return await _context.Kegiatans
                .Include(k => k.Kategori_Kegiatan) 
                .OrderBy(k => k.Tanggal_Mulai)     
                .ToListAsync(cancellationToken);
        }
    }
}