using Application.AskForPasta.DTOs.Requests;
using Application.AskForPasta.DTOs.Responses.Application.Common.Responses;
using Domain.AskForPasta.Entities;

namespace Application.AskForPasta.Interfaces.Features
{
    public interface IAddressFeature
    {
        Task<GenericResponse<int>> CreateAddressAsync(CreateAddressRequestDto request);
    }
}
