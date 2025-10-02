using Application.AskForPasta.DTOs.Requests;
using Application.AskForPasta.DTOs.Responses;
using Application.AskForPasta.DTOs.Responses.Application.Common.Responses;

namespace Application.AskForPasta.Interfaces.Features
{
    public interface IProductFeature : IBaseFeature<CreateProductRequestDto, ProductResponseDto>
    {
        Task<GenericResponse<ProductResponseDto>> UpdatePriceAsync(UpdateProductRequestDto request);
        Task<GenericResponse<ProductResponseDto>> UpdateNameAsync(UpdateProductRequestDto request);
        Task<GenericResponse<ProductResponseDto>> UpdateImagePathAsync(UpdateProductRequestDto request);
        Task<GenericResponse<ProductResponseDto>> IncreaseFromStockAsync(UpdateProductRequestDto request);
        Task<GenericResponse<ProductResponseDto>> DecreaseFromStockAsync(UpdateProductRequestDto request);
    }
}
