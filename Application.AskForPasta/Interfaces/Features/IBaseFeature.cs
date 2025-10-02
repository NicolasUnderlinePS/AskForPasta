using Application.AskForPasta.DTOs.Requests;
using Application.AskForPasta.DTOs.Responses.Application.Common.Responses;

namespace Application.AskForPasta.Interfaces.Features
{
    public interface IBaseFeature<TRequest, TResponse> where TRequest : BaseRequest
    {
        Task<GenericResponse<TResponse>> InsertAsync(TRequest request);
        Task<GenericResponse<TResponse>> GetByIdAsync(int id);
    }
}
