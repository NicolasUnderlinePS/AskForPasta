using Application.AskForPasta.DTOs.Responses;
using Domain.AskForPasta.Entities;

namespace Application.AskForPasta.Extensions
{
    public static class PaymentExtension
    {
        public static PaymentResponseDto? PaymentResponseDto(Payment? entity)
        {
            if (entity == null) return null;

            return new PaymentResponseDto();
        }
    }
}
