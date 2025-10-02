using Application.AskForPasta.DTOs.Responses.Application.Common.Responses;

namespace Application.AskForPasta.Interfaces.Repositories
{
    public interface IBaseRepository<TEntity>
    {
        Task<GenericResponse<int>> InsertAsync(TEntity entity);
        Task<GenericResponse<TEntity>> UpdateAsync(TEntity entity);
        Task<GenericResponse<TEntity>> GetByIdAsync(int id);
    }
}
