using Application.AskForPasta.DTOs.Requests;
using Application.AskForPasta.DTOs.Responses.Application.Common.Responses;

namespace Application.AskForPasta.Interfaces.Repositories
{
    public interface ILoginWorkFlowRepository
    {
        Task<GenericResponse<bool>> CreateUserAccessAsync(CreateUserAccessRequestDto request);
    }
}
