using FluentValidation;
using MediatR;
using STTB.Backend.Data;
using MataKuliahModel = STTB.Backend.Models.Mata_Kuliah;

namespace STTB.Backend.Features.MataKuliah.Commands
{
    public class CreateMataKuliahCommand : IRequest<int>
    {
        public string NamaMk { get; set; }
        public string KategoriMk { get; set; }
        public string DetailPerincian { get; set; }
        public int ProdiId { get; set; }
    }

    public class CreateMataKuliahValidator : AbstractValidator<CreateMataKuliahCommand>
    {
        public CreateMataKuliahValidator()
        {
            RuleFor(x => x.NamaMk).NotEmpty();
            RuleFor(x => x.KategoriMk).NotEmpty();
            RuleFor(x => x.ProdiId).GreaterThan(0).WithMessage("Program Studi wajib dipilih.");
        }
    }

    public class CreateMataKuliahHandler : IRequestHandler<CreateMataKuliahCommand, int>
    {
        private readonly AppDbContext _context;
        public CreateMataKuliahHandler(AppDbContext context) => _context = context;

        public async Task<int> Handle(CreateMataKuliahCommand request, CancellationToken cancellationToken)
        {
            var model = new MataKuliahModel
            {
                Nama_Mk = request.NamaMk,
                Kategori_Mk = request.KategoriMk,
                Detail_Perincian = request.DetailPerincian,
                Prodi_Id = request.ProdiId
            };
            _context.Mata_Kuliahs.Add(model);
            await _context.SaveChangesAsync(cancellationToken);
            return model.Id;
        }
    }
}