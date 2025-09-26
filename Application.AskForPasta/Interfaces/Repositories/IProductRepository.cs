using Application.AskForPasta.DTOs.Responses.Application.Common.Responses;
using Domain.AskForPasta.Entities;

namespace Application.AskForPasta.Interfaces.Repositories
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Task<GenericResponse<int>> SubtractFromStock (int productId, int quantity);
        Task<GenericResponse<int>> IncreaseFromStock (int productId, int quantity);
    }
}
