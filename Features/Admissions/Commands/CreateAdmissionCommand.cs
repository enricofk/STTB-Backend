using FluentValidation;
using MediatR;
using STTB.Backend.Data;
using PendaftaranModel = STTB.Backend.Models.Form_Pendaftaran;

namespace STTB.Backend.Features.Admissions.Commands
{
    public class CreateAdmissionCommand : IRequest<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string StatementOfFaith { get; set; }
        public string ChurchAffiliation { get; set; }
    }

    public class CreateAdmissionValidator : AbstractValidator<CreateAdmissionCommand>
    {
        public CreateAdmissionValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("Nama depan wajib diisi.")
                .MaximumLength(50);

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Nama belakang wajib diisi.");

            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress().WithMessage("Format email tidak valid! Harus menggunakan @.");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty()
                .Matches(@"^\+?[0-9]{10,15}$").WithMessage("Nomor telepon hanya boleh berisi angka (10-15 digit).");

            RuleFor(x => x.StatementOfFaith).NotEmpty();
            RuleFor(x => x.ChurchAffiliation).NotEmpty();
        }
    }

    public class CreateAdmissionHandler : IRequestHandler<CreateAdmissionCommand, int>
    {
        private readonly AppDbContext _context;

        public CreateAdmissionHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateAdmissionCommand request, CancellationToken cancellationToken)
        {
            var model = new PendaftaranModel
            {
                First_Name = request.FirstName,
                Last_Name = request.LastName,
                Email = request.Email,
                Phone_Number = request.PhoneNumber,
                Statement_Of_Faith = request.StatementOfFaith,
                Church_Affiliation = request.ChurchAffiliation
            };

            _context.Form_Pendaftarans.Add(model);
            await _context.SaveChangesAsync(cancellationToken);

            return model.Id;
        }
    }
}