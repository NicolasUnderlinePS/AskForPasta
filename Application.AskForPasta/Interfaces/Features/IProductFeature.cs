using Application.AskForPasta.DTOs.Requests;
using Application.AskForPasta.DTOs.Responses;
using Application.AskForPasta.DTOs.Responses.Application.Common.Responses;
using Domain.AskForPasta.Entities;

namespace Application.AskForPasta.Interfaces.Features
{
    public interface IProductFeature : IBaseFeature<CreateProductRequestDto, ProductResponseDto>
    {

    }
}
