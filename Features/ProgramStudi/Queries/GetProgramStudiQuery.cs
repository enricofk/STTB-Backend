using MediatR;
using Microsoft.EntityFrameworkCore;
using STTB.Backend.Data;
using ProgramStudiModel = STTB.Backend.Models.Program_Studi;

namespace STTB.Backend.Features.ProgramStudi.Queries
{
    public class GetProgramStudiQuery : IRequest<List<ProgramStudiModel>> { }

    public class GetProgramStudiHandler : IRequestHandler<GetProgramStudiQuery, List<ProgramStudiModel>>
    {
        private readonly AppDbContext _context;
        public GetProgramStudiHandler(AppDbContext context) => _context = context;

        public async Task<List<ProgramStudiModel>> Handle(GetProgramStudiQuery request, CancellationToken cancellationToken)
        {
            return await _context.Program_Studis
                .Include(p => p.Ketua_Prodi) // Menampilkan data Kaprodi sekalian
                .OrderBy(p => p.Tingkat).ThenBy(p => p.Nama_Prodi)
                .ToListAsync(cancellationToken);
        }
    }
}