using Application.AskForPasta.DTOs.Requests;
using Application.AskForPasta.DTOs.Responses;
using Application.AskForPasta.DTOs.Responses.Application.Common.Responses;
using Application.AskForPasta.Interfaces.Features;

namespace Application.AskForPasta.Features
{
    public class ProductFeature : IProductFeature
    {
        public Task<GenericResponse<ProductResponseDto>> CreateProductAsync(CreateProductRequestDto request)
        {
            throw new NotImplementedException();
        }
    }
}
