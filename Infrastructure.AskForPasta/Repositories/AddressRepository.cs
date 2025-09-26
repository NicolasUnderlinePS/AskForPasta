using Application.AskForPasta.DTOs.Responses.Application.Common.Responses;
using Application.AskForPasta.Interfaces.Repositories;
using Domain.AskForPasta.Entities;
using Infrastructure.AskForPasta.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.AskForPasta.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly ApplicationDbContext _context;

        public AddressRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<GenericResponse<int>> CreateAsync(Address entity)
        {
            await _context.Address.AddAsync(entity);
            await _context.SaveChangesAsync();

            return GenericResponse<int>.Ok(entity.Id, "Endereço criado com sucesso.");
        }

        public async Task<GenericResponse<Address>> GetByIdAsync(int id)
        {
            Address? entity = await _context.Address.Where(u => u.Id == id).FirstOrDefaultAsync();

            if (entity == null)
                return GenericResponse<Address>.Fail("Endereço não foi encontrado.");

            return GenericResponse<Address>.Ok(entity, "Endereço encontrado com sucesso.");
        }
    }
}
