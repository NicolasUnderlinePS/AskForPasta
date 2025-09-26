using Application.AskForPasta.DTOs.Responses.Application.Common.Responses;
using Domain.AskForPasta.Entities;

namespace Application.AskForPasta.Interfaces.Repositories
{
    public interface IProductRepository
    {
        Task<GenericResponse<int>> CreateProductAsync(Product entity);
        Task<GenericResponse<Product>> GetProductByIdAsync(int id);
    }
}
