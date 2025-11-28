using LibraryManagement.Application.DTOs.Auth;

namespace LibraryManagement.Application.Interfaces
{
    public interface IAuthService
    {
        Task<AuthResponse> RegisterAsync(RegisterRequest request);
        Task<AuthResponse> LoginRequest(LoginRequest request);
    }
}