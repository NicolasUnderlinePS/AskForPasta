using Application.AskForPasta.DTOs.Responses.Application.Common.Responses;

namespace Application.AskForPasta.Interfaces.Features
{
    public interface IBaseFeature<TRequest, TResponse>
    {
        Task<GenericResponse<TResponse>> CreateAsync(TRequest request);
        Task<GenericResponse<TResponse>> GetByIdAsync(int id);
    }
}
