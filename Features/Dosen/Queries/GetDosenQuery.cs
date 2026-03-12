using MediatR;
using Microsoft.EntityFrameworkCore;
using STTB.Backend.Data;
using DosenModel = STTB.Backend.Models.Dosen;

namespace STTB.Backend.Features.Dosen.Queries
{
    public class GetDosenQuery : IRequest<List<DosenModel>> { }

    public class GetDosenHandler : IRequestHandler<GetDosenQuery, List<DosenModel>>
    {
        private readonly AppDbContext _context;

        public GetDosenHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<DosenModel>> Handle(GetDosenQuery request, CancellationToken cancellationToken)
        {
            return await _context.Dosens
                .OrderBy(d => d.Nama_Lengkap) 
                .ToListAsync(cancellationToken);
        }
    }
}