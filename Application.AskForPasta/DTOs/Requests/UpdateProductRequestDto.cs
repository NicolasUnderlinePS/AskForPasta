using Domain.AskForPasta.Entities;

namespace Application.AskForPasta.DTOs.Requests
{
    public class UpdateProductRequestDto : BaseRequest
    {
        public UpdateProductRequestDto(User user) : base(user)
        {
        }

        public required int ProductId { get; set; }
        public required string Name { get; set; }
        public required string ImagePath { get; set; }
        public required decimal Price { get; set; }
        public required int StockQuantity { get; set; }
    }
}
