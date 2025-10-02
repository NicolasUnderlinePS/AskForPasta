using Domain.AskForPasta.Entities;

namespace Application.AskForPasta.DTOs.Requests
{
    public class CreatePurchaseRequestDto : BaseRequest
    {
        public CreatePurchaseRequestDto(User user) : base(user)
        {
        }

        public required int PurchaseId { get; set; }
        public required DateTime PurchaseDate { get; set; }
        public required int ClientId { get; set; }
        public required int AddressId { get; set; }
        public required int PurchaseStatusId { get; set; }
        public required List<ProductsToBuyRequestDto> Products { get; set; }
    }
}
