using Application.AskForPasta.DTOs.Responses;
using Domain.AskForPasta.Entities;

namespace Application.AskForPasta.Extensions
{
    public static class ProductExtension
    {
        public static ProductResponseDto? ProductResponseDto(Product? entity)
        {
            if (entity == null) return null;

            return new ProductResponseDto(entity.Id, entity.Name, entity.Code, entity.Price, entity.StockQuantity);
        }
    }
}
