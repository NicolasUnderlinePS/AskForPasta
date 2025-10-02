using Application.AskForPasta.DTOs.Requests;
using Application.AskForPasta.DTOs.Responses;
using Application.AskForPasta.DTOs.Responses.Application.Common.Responses;
using Application.AskForPasta.Extensions;
using Application.AskForPasta.Interfaces.Features;
using Application.AskForPasta.Interfaces.Repositories;
using Domain.AskForPasta.Entities;

namespace Application.AskForPasta.Features
{
    public class PaymentFeature : IPaymentFeature
    {
        private readonly IPaymentRepository paymentRepository;

        public PaymentFeature(IPaymentRepository paymentRepository)
        {
            this.paymentRepository = paymentRepository;
        }

        public async Task<GenericResponse<PaymentResponseDto>> GetByIdAsync(int id)
        {
            GenericResponse<Payment> entity = await paymentRepository.GetByIdAsync(id);

            return GenericResponse<PaymentResponseDto>.Ok(PaymentExtension.PaymentResponseDto(entity.Data), entity.Message);
        }

        public async Task<GenericResponse<PaymentResponseDto>> InsertAsync(CreatePaymentRequestDto request)
        {
            Payment entity = new Payment(request.PurchaseId, request.RequestTime, request.PaymentMethodTypeId, request.Amount, request.RequestTime);

            GenericResponse<int> response = await paymentRepository.InsertAsync(entity);

            if (response.IsInvalidReturn())
                return GenericResponse<PaymentResponseDto>.Fail(response.Message, response.Errors);

            return await GetByIdAsync(response.Data);
        }
    }
}
