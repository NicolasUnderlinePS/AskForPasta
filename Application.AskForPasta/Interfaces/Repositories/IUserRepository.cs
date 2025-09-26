using Application.AskForPasta.DTOs.Responses.Application.Common.Responses;
using Domain.AskForPasta.Entities;

namespace Application.AskForPasta.Interfaces.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<GenericResponse<bool>> GetUserToLoginAsync(string email, string password);
    }
}
