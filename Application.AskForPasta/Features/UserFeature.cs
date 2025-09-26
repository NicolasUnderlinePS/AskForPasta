using Application.AskForPasta.DTOs.Requests;
using Application.AskForPasta.DTOs.Responses;
using Application.AskForPasta.DTOs.Responses.Application.Common.Responses;
using Application.AskForPasta.Extensions;
using Application.AskForPasta.Interfaces.Features;
using Application.AskForPasta.Interfaces.Repositories;
using Domain.AskForPasta.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.AskForPasta.Features
{
    public class UserFeature : IUserFeature
    {

        private readonly IUserRepository userRepository;

        public UserFeature(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<GenericResponse<int>> CreateUserAsync(CreateUserRequestDto request)
        {
            GenericResponse<int> response = GenericResponse<int>.Ok(0);
            User user = new User(request.NickName, request.Document, request.Email, request.CellPhone, false, request.Password, request.UserTypeId, request.RequestTime);

            response = await userRepository.CreateUserAsync(user);

            if (response.Success)
                return GenericResponse<int>.Ok(user.Id, response.Message);
            else
                return GenericResponse<int>.Fail(response.Message, response.Errors);
        }

        public async Task<GenericResponse<UserResponseDto>> GetUserByIdAsync(int id)
        {
            GenericResponse<User> user = await userRepository.GetUserByIdAsync(id);

            return GenericResponse<UserResponseDto>.Ok(UserExtension.UserResponseDto(user.Data), user.Message);
        }
    }
}
