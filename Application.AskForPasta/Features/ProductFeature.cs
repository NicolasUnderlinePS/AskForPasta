using Application.AskForPasta.DTOs.Requests;
using Application.AskForPasta.DTOs.Responses;
using Application.AskForPasta.DTOs.Responses.Application.Common.Responses;
using Application.AskForPasta.Extensions;
using Application.AskForPasta.Interfaces.Features;
using Application.AskForPasta.Interfaces.Repositories;
using Domain.AskForPasta.Entities;

namespace Application.AskForPasta.Features
{
    public class ProductFeature : IProductFeature
    {
        private readonly IProductRepository productRepository;

        public ProductFeature(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        private async Task<GenericResponse<ProductResponseDto>> UpdateProductAsync(int productId, Action<Product> updateAction, string successMessage = "")
        {
            GenericResponse<Product> response = await productRepository.GetByIdAsync(productId);

            if (response.Success == false || response.Data == null)
                return GenericResponse<ProductResponseDto>.Fail("Produto não foi encontrado.");

            Product entity = response.Data;

            updateAction(entity);

            response = await productRepository.UpdateAsync(entity);

            return GenericResponse<ProductResponseDto>.Ok(ProductExtension.ProductResponseDto(response.Data), string.IsNullOrEmpty(successMessage) ? response.Message : successMessage);
        }

        public async Task<GenericResponse<ProductResponseDto>> InsertAsync(CreateProductRequestDto request)
        {
            Product entity = new Product(request.Name, Guid.NewGuid().ToString(), string.Empty, request.Price, request.StockQuantity, request.RequestTime);

            GenericResponse<int> response = await productRepository.InsertAsync(entity);

            if (response.IsInvalidReturn())
                return GenericResponse<ProductResponseDto>.Fail(response.Message, response.Errors);

            return await GetByIdAsync(response.Data);
        }

        public async Task<GenericResponse<ProductResponseDto>> GetByIdAsync(int id)
        {
            GenericResponse<Product> entity = await productRepository.GetByIdAsync(id);

            return GenericResponse<ProductResponseDto>.Ok(ProductExtension.ProductResponseDto(entity.Data), entity.Message);
        }

        public async Task<GenericResponse<ProductResponseDto>> UpdateImagePathAsync(UpdateProductRequestDto request)
        {
            return await UpdateProductAsync(request.ProductId, p => p.UpdateImagePath(request.ImagePath), "Imagem atualizada com sucesso.");
        }

        public async Task<GenericResponse<ProductResponseDto>> UpdateNameAsync(UpdateProductRequestDto request)
        {
            return await UpdateProductAsync(request.ProductId, p => p.UpdateImagePath(request.ImagePath), "Nome atualizado com sucesso.");
        }

        public async Task<GenericResponse<ProductResponseDto>> UpdatePriceAsync(UpdateProductRequestDto request)
        {
            return await UpdateProductAsync(request.ProductId, p => p.UpdatePrice(request.Price), "Preço atualizado com sucesso.");
        }

        public async Task<GenericResponse<ProductResponseDto>> IncreaseFromStockAsync(UpdateProductRequestDto request)
        {
            return await UpdateProductAsync(request.ProductId, p => p.IncreaseStock(request.StockQuantity), "Quantidade atualizada com sucesso.");
        }

        public async Task<GenericResponse<ProductResponseDto>> DecreaseFromStockAsync(UpdateProductRequestDto request)
        {
            return await UpdateProductAsync(request.ProductId, p => p.DecreaseStock(request.StockQuantity), "Quantidade atualizada com sucesso.");
        }
    }
}
