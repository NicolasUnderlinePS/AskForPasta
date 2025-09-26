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

        public async Task<GenericResponse<ProductResponseDto>> CreateProductAsync(CreateProductRequestDto request)
        {
            Product entity = new Product(request.Name, request.Code, string.Empty, request.Price, request.StockQuantity, request.RequestTime);

            GenericResponse<int> response = await productRepository.CreateProductAsync(entity);

            if (response.Success)
                return await GetProductByIdAsync(response.Data);
            else
                return GenericResponse<ProductResponseDto>.Fail(response.Message, response.Errors);
        }

        public async Task<GenericResponse<ProductResponseDto>> GetProductByIdAsync(int id)
        {
            GenericResponse<Product> entity = await productRepository.GetProductByIdAsync(id);

            return GenericResponse<ProductResponseDto>.Ok(ProductExtension.ProductResponseDto(entity.Data), entity.Message);
        }
    }
}
