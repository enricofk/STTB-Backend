using MediatR;
using Microsoft.EntityFrameworkCore;
using STTB.Backend.Data;
using MataKuliahModel = STTB.Backend.Models.Mata_Kuliah;

namespace STTB.Backend.Features.MataKuliah.Queries
{
    public class GetMataKuliahQuery : IRequest<List<MataKuliahModel>> { }

    public class GetMataKuliahHandler : IRequestHandler<GetMataKuliahQuery, List<MataKuliahModel>>
    {
        private readonly AppDbContext _context;
        public GetMataKuliahHandler(AppDbContext context) => _context = context;

        public async Task<List<MataKuliahModel>> Handle(GetMataKuliahQuery request, CancellationToken cancellationToken)
        {
            return await _context.Mata_Kuliahs
                .Include(m => m.Program_Studi)
                .OrderBy(m => m.Nama_Mk)
                .ToListAsync(cancellationToken);
        }
    }
}