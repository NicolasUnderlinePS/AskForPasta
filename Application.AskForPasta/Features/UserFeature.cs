using Application.AskForPasta.DTOs.Requests;
using Application.AskForPasta.DTOs.Responses;
using Application.AskForPasta.DTOs.Responses.Application.Common.Responses;
using Application.AskForPasta.Extensions;
using Application.AskForPasta.Interfaces.Features;
using Application.AskForPasta.Interfaces.Repositories;
using Domain.AskForPasta.Entities;

namespace Application.AskForPasta.Features
{
    public class UserFeature : IUserFeature
    {
        private readonly IUserRepository userRepository;

        public UserFeature(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<GenericResponse<UserResponseDto>> CreateAsync(CreateUserRequestDto request)
        {
            GenericResponse<int> response = GenericResponse<int>.Ok(0);
            User user = new User(request.NickName, request.Document, request.Email, request.CellPhone, false, request.Password, request.UserTypeId, request.RequestTime);

            response = await userRepository.CreateAsync(user);

            if (response.Success)
                return await GetByIdAsync(response.Data);
            else
                return GenericResponse<UserResponseDto>.Fail(response.Message, response.Errors);
        }

        public async Task<GenericResponse<UserResponseDto>> GetByIdAsync(int id)
        {
            GenericResponse<User> user = await userRepository.GetByIdAsync(id);

            return GenericResponse<UserResponseDto>.Ok(UserExtension.UserResponseDto(user.Data), user.Message);
        }
    }
}
