using Domain.AskForPasta.Entities;

namespace Application.AskForPasta.DTOs.Requests
{
    public class CreatePaymentRequestDto : BaseRequest
    {
        public CreatePaymentRequestDto(User user) : base(user)
        {
        }

        public required int PaymentId { get; set; }
        public required int PurchaseId { get; set; }
        public required DateTime PaymentDate { get; set; }
        public required int PaymentMethodTypeId { get; set; }
        public required decimal Amount { get; set; }
    }
}
