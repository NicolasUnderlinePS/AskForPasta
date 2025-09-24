using Application.AskForPasta.DTOs.Responses.Application.Common.Responses;
using Domain.AskForPasta.Entities;

namespace Application.AskForPasta.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<GenericResponse<int>> CreateUserAsync(User entity);
        Task<GenericResponse<bool>> GetUserToLoginAsync(string email, string password);
        Task<GenericResponse<User>> GetUserByIdAsync(int id);
    }
}
