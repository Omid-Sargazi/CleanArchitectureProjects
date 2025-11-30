using System.Security.Cryptography;
using System.Text;
using LibraryManagement.Application.DTOs.Auth;
using LibraryManagement.Domain.Entities;
using LibraryManagement.Infrastructure.Data;
using LibraryManagement.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Application.Interfaces
{
    public interface IAuthService
    {
        Task<AuthResponse> RegisterAsync(RegisterRequest request);
        Task<AuthResponse> LoginAsync(LoginRequest request);
    }

    public class AuthService : IAuthService
    {
        private readonly LibraryDbContext _context;
        private readonly JwtTokenGenerator _tokenGenerator;
        public AuthService(LibraryDbContext context, JwtTokenGenerator tokenGenerator)
        {
            _context = context;
            _tokenGenerator = tokenGenerator;

        }
       
       public async Task<AuthResponse> LoginAsync(LoginRequest request)
    {
        var user = await _context.Users
            .Include(u => u.UserRoles)
            .ThenInclude(ur => ur.Role)
            .FirstOrDefaultAsync(u => u.Email == request.Email);

        if (user == null || !VerifyPassword(request.Password, user.PasswordHash))
            throw new Exception("Invalid credentials.");

        var roles = user.UserRoles.Select(ur => ur.Role.Name).ToList();
        var token = _tokenGenerator.GenerateToken(user, roles);

        return new AuthResponse
        {
            Token = token,
            Expiration = DateTime.UtcNow.AddMinutes(60),
            UserName = user.UserName,
            Email = user.Email
        };
    }

       

        public async Task<AuthResponse> RegisterAsync(RegisterRequest request)
    {
        if (await _context.Users.AnyAsync(u => u.Email == request.Email))
            throw new Exception("Email already registered.");

        var user = new User
        {
            UserName = request.UserName,
            Email = request.Email,
            PasswordHash = HashPassword(request.Password),
            IsActive = true
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        // پیش‌فرض نقش Member
        var memberRole = await _context.Roles.FirstOrDefaultAsync(r => r.Name == "Member");
        if (memberRole == null)
        {
            memberRole = new Role { Name = "Member", Description = "Default member role" };
            _context.Roles.Add(memberRole);
            await _context.SaveChangesAsync();
        }

        _context.UserRoles.Add(new UserRole { UserId = user.Id, RoleId = memberRole.Id });
        await _context.SaveChangesAsync();

        var token = _tokenGenerator.GenerateToken(user, new[] { memberRole.Name });

        return new AuthResponse
        {
            Token = token,
            Expiration = DateTime.UtcNow.AddMinutes(60),
            UserName = user.UserName,
            Email = user.Email
        };
    }

        private string HashPassword(string password)
        {
            using var sha256 =  SHA256.Create();
            var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(bytes);
        }

         private bool VerifyPassword(string password, string storedHash)
    {
        var hash = HashPassword(password);
        return hash == storedHash;
    }


    
    }

}