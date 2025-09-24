using Application.AskForPasta.DTOs.Requests;
using Application.AskForPasta.DTOs.Responses;
using Application.AskForPasta.DTOs.Responses.Application.Common.Responses;

namespace Application.AskForPasta.Interfaces.Features
{
    public interface IUserFeature
    {
        Task<GenericResponse<int>> CreateUserAsync(CreateUserRequestDto request);
        Task<GenericResponse<UserResponseDto>> GetUserByIdAsync(int id);
    }
}
