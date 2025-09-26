using Application.AskForPasta.DTOs.Responses.Application.Common.Responses;
using Domain.AskForPasta.Entities;

namespace Application.AskForPasta.Interfaces.Repositories
{
    public interface IAddressRepository
    {
        Task<GenericResponse<int>> CreateAddressAsync(Address entity);
        Task<GenericResponse<Address>> GetAddressByIdAsync(int id);
    }
}
