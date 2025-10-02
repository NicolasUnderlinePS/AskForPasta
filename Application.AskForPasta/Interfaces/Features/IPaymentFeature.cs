using Application.AskForPasta.DTOs.Requests;
using Application.AskForPasta.DTOs.Responses;

namespace Application.AskForPasta.Interfaces.Features
{
    public interface IPaymentFeature : IBaseFeature<CreatePaymentRequestDto, PaymentResponseDto>
    {
    }
}
