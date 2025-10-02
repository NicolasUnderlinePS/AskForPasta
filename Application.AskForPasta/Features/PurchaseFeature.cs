using Application.AskForPasta.DTOs.Requests;
using Application.AskForPasta.DTOs.Responses;
using Application.AskForPasta.DTOs.Responses.Application.Common.Responses;
using Application.AskForPasta.Extensions;
using Application.AskForPasta.Interfaces.Features;
using Application.AskForPasta.Interfaces.Repositories;
using Domain.AskForPasta.Entities;
using System.Transactions;

namespace Application.AskForPasta.Features
{
    public class PurchaseFeature : IPurchaseFeature
    {
        private readonly IPurchaseRepository purchaseRepository;
        private readonly IPurchaseProductRepository purchaseProductRepository;
        private readonly IProductFeature productFeature;

        public PurchaseFeature(IPurchaseRepository purchaseRepository, IPurchaseProductRepository purchaseProductRepository, IProductFeature productFeature)
        {
            this.purchaseRepository = purchaseRepository;
            this.purchaseProductRepository = purchaseProductRepository;
            this.productFeature = productFeature;
        }

        public async Task<GenericResponse<PurchaseResponseDto>> InsertAsync(CreatePurchaseRequestDto request)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                Purchase entity = new Purchase(request.RequestTime, request.ClientId, request.AddressId, request.PurchaseStatusId, request.RequestTime);

                GenericResponse<int> response = await purchaseRepository.InsertAsync(entity);

                if (response.IsInvalidReturn())
                    return GenericResponse<PurchaseResponseDto>.Fail(response.Message, response.Errors);

                request.PurchaseId = response.Data;

                for (int i = 0; i < request.Products.Count; i++)
                {
                    ProductsToBuyRequestDto current = request.Products[i];

                    GenericResponse<ProductResponseDto> product = await productFeature.GetByIdAsync(current.ProductId);

                    if (product.IsInvalidReturn())
                        return GenericResponse<PurchaseResponseDto>.Fail($"Produto não foi encontrado.");

                    PurchaseProduct purchaseProduct = new PurchaseProduct(request.PurchaseId, product.Data!.ProductId, current.Quantity, product.Data.Price, request.RequestTime);

                    await purchaseProductRepository.InsertAsync(purchaseProduct);
                }

                scope.Complete();

                return GenericResponse<PurchaseResponseDto>.Ok(PurchaseExtension.PurchaseResponseDto(entity), "Pedido criado com sucesso.");
            }
        }

        public async Task<GenericResponse<PurchaseResponseDto>> GetByIdAsync(int id)
        {
            GenericResponse<Purchase> entity = await purchaseRepository.GetByIdAsync(id);

            return GenericResponse<PurchaseResponseDto>.Ok(PurchaseExtension.PurchaseResponseDto(entity.Data), entity.Message);
        }
    }
}
