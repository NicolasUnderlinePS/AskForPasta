using Application.AskForPasta.DTOs.Requests;
using Application.AskForPasta.DTOs.Responses.Application.Common.Responses;

namespace Application.AskForPasta.Interfaces.Features
{
    public interface ILoginWorkFlowFeature
    {
        Task<GenericResponse<bool>> CreateUserAccessAsync(CreateUserAccessRequestDto request);
        Task<GenericResponse<bool>> StartSessionAsync(StartSessionRequestDto request);
    }
}
