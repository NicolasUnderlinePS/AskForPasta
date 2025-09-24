using Application.AskForPasta.DTOs.Responses;
using Domain.AskForPasta.Entities;

namespace Application.AskForPasta.Extensions
{
    public static class UserExtension
    {
        public static CreateUserResponseDto? CreateUserResponseDto(User user)
        {
            if (user == null) return null;

            return new CreateUserResponseDto (user.Id, user.NickName, user.Document, user.Email, user.CellPhone, user.IsActive, user.UserTypeId);
        }

        public static UserResponseDto? UserResponseDto(User? user)
        {
            if (user == null) return null;

            return new UserResponseDto (user.Id, user.NickName, user.Document, user.Email, user.CellPhone, user.IsActive, user.UserTypeId);
        }


    }
}
