using Application.AskForPasta.DTOs.Requests;
using Application.AskForPasta.DTOs.Responses;
using Application.AskForPasta.DTOs.Responses.Application.Common.Responses;

namespace Application.AskForPasta.Interfaces.Features
{
    public interface ILoginWorkFlowFeature
    {
        Task<GenericResponse<UserResponseDto>> CreateUserAccessAsync(CreateUserAccessRequestDto request);
        Task<GenericResponse<bool>> StartSessionAsync(StartSessionRequestDto request);
        Task<GenericResponse<bool>> EndSessionAsync(int userId);
        Task<GenericResponse<bool>> RequestPasswordRecoveryAsync(RecoveryRequestDto request);
        Task<GenericResponse<bool>> ResetPasswordAsync(ResetPasswordRequestDto request);
    }
}
