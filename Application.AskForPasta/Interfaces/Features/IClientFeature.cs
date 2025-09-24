using Application.AskForPasta.DTOs.Requests;
using Application.AskForPasta.DTOs.Responses.Application.Common.Responses;

namespace Application.AskForPasta.Interfaces.Features
{
    public interface IClientFeature
    {
        Task<GenericResponse<int>> CreateClientAsync(CreateClientRequestDto request);
    }
}
