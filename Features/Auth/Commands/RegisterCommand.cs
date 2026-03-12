using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using STTB.Backend.Data;
using UserModel = STTB.Backend.Models.User;

namespace STTB.Backend.Features.Auth.Commands
{
    public class RegisterCommand : IRequest<int>
    {
        public string Username { get; set; }
        public string Email { get; set; } 
        public string Password { get; set; }
        public string Role { get; set; } = "Admin"; 
    }

    public class RegisterValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterValidator()
        {
            RuleFor(x => x.Username).NotEmpty().WithMessage("Username tidak boleh kosong.");
            RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage("Format email tidak valid.");
            RuleFor(x => x.Password).NotEmpty().MinimumLength(6).WithMessage("Password minimal 6 karakter.");
        }
    }

    public class RegisterHandler : IRequestHandler<RegisterCommand, int>
    {
        private readonly AppDbContext _context;

        public RegisterHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var isUserExist = await _context.Users.AnyAsync(u => u.Username == request.Username, cancellationToken);
            if (isUserExist)
            {
                throw new ValidationException(new[] { new FluentValidation.Results.ValidationFailure("Username", "Username sudah terdaftar.") });
            }

            var user = new UserModel
            {
                Username = request.Username,
                Email = request.Email,
                Password_Hash = BCrypt.Net.BCrypt.HashPassword(request.Password),
                Role = request.Role
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync(cancellationToken);

            return user.Id;
        }
    }
}