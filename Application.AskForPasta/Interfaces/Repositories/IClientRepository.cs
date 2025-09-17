using Application.AskForPasta.DTOs.Responses.Application.Common.Responses;
using Domain.AskForPasta.Entities;

namespace Application.AskForPasta.Interfaces.Repositories
{
    public interface IClientRepository
    {
        Task<GenericResponse<int>> CreateClientAsync(Client entity);
    }
}
