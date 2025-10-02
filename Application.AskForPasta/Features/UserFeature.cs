using Application.AskForPasta.DTOs.Requests;
using Application.AskForPasta.DTOs.Responses;
using Application.AskForPasta.DTOs.Responses.Application.Common.Responses;
using Application.AskForPasta.Extensions;
using Application.AskForPasta.Interfaces.Features;
using Application.AskForPasta.Interfaces.Repositories;
using Domain.AskForPasta.Entities;
using System.Reflection.Metadata;

namespace Application.AskForPasta.Features
{
    public class UserFeature : IUserFeature
    {
        private readonly IUserRepository userRepository;

        public UserFeature(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        private async Task<GenericResponse<UserResponseDto>> UpdateUserAsync(int userId, Action<User> updateAction, string successMessage = "")
        {
            GenericResponse<User> response = await userRepository.GetByIdAsync(userId);

            if (response.Success == false || response.Data == null)
                return GenericResponse<UserResponseDto>.Fail("Endereço não foi encontrado.");

            User entity = response.Data;

            updateAction(entity);

            response = await userRepository.UpdateAsync(entity);

            return GenericResponse<UserResponseDto>.Ok(UserExtension.UserResponseDto(response.Data), string.IsNullOrEmpty(successMessage) ? response.Message : successMessage);
        }


        public async Task<GenericResponse<UserResponseDto>> InsertAsync(CreateUserRequestDto request)
        {
            User user = new User(request.NickName, request.Document, request.Email, request.CellPhone, false, request.Password, request.UserTypeId, request.RequestTime);

            GenericResponse<int> response = await userRepository.InsertAsync(user);

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

        public async Task<GenericResponse<UserResponseDto>> GetUserByEmailAsync(string email)
        {
            GenericResponse<User> user = await userRepository.GetUserByEmailAsync(email);

            return GenericResponse<UserResponseDto>.Ok(UserExtension.UserResponseDto(user.Data), user.Message);
        }

        public async Task<GenericResponse<UserResponseDto>> UpdateAsync(UpdateUserRequestDto request)
        {
            GenericResponse<User> response = await userRepository.GetByIdAsync(request.UserId);

            if (response.Success == false || response.Data == null)
                return GenericResponse<UserResponseDto>.Fail("Usuário não foi encontrado.");

            User user = response.Data;

            user.UpdateFromDto(request.NickName, request.Document, request.Email, request.CellPhone, request.IsActive, request.UserTypeId);

            response = await userRepository.UpdateAsync(user);

            return GenericResponse<UserResponseDto>.Ok(UserExtension.UserResponseDto(response.Data), response.Message);
        }


    }
}
