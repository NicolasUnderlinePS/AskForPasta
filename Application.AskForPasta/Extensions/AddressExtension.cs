using Application.AskForPasta.DTOs.Responses;
using Domain.AskForPasta.Entities;

namespace Application.AskForPasta.Extensions
{
    public static class AddressExtension
    {
        public static AddressResponseDto? AddressResponseDto(Address? entity)
        {
            if (entity == null) return null;

            return new AddressResponseDto(entity.Id, entity.ZipCode, entity.Street, entity.Neighborhood, entity.Number, entity.Complement, entity.City, entity.State);
        }
    }
}
