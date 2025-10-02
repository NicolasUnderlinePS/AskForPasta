using Application.AskForPasta.DTOs.Requests;
using Application.AskForPasta.DTOs.Responses;
using Application.AskForPasta.DTOs.Responses.Application.Common.Responses;

namespace Application.AskForPasta.Interfaces.Features
{
    public interface IUserFeature : IBaseFeature<CreateUserRequestDto, UserResponseDto>
    {
        Task<GenericResponse<UserResponseDto>> UpdateAsync(UpdateUserRequestDto request);
        Task<GenericResponse<UserResponseDto>> GetUserByEmailAsync(string email);
    }
}
