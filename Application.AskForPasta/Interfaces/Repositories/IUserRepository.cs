using Application.AskForPasta.DTOs.Responses.Application.Common.Responses;
using Domain.AskForPasta.Entities;

namespace Application.AskForPasta.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<GenericResponse<int>> CreateUserAsync(User entity);
        Task<GenericResponse<bool>> SelectUserToLoginAsync(string email, string password);
    }
}
