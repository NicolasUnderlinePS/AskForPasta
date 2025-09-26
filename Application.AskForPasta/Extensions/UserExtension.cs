using Application.AskForPasta.DTOs.Responses;
using Domain.AskForPasta.Entities;

namespace Application.AskForPasta.Extensions
{
    public static class UserExtension
    {
        public static CreateUserResponseDto? CreateUserResponseDto(User entity)
        {
            if (entity == null) return null;

            return new CreateUserResponseDto (entity.Id, entity.NickName, entity.Document, entity.Email, entity.CellPhone, entity.IsActive, entity.UserTypeId);
        }

        public static UserResponseDto? UserResponseDto(User? entity)
        {
            if (entity == null) return null;

            return new UserResponseDto (entity.Id, entity.NickName, entity.Document, entity.Email, entity.CellPhone, entity.IsActive, entity.UserTypeId);
        }


    }
}
