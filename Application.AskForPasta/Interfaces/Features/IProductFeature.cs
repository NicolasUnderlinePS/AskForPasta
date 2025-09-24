using Application.AskForPasta.DTOs.Requests;
using Application.AskForPasta.DTOs.Responses;
using Application.AskForPasta.DTOs.Responses.Application.Common.Responses;

namespace Application.AskForPasta.Interfaces.Features
{
    public interface IProductFeature
    {
        Task<GenericResponse<ProductResponseDto>> CreateProductAsync(CreateProductRequestDto request);
    }
}
