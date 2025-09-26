using Application.AskForPasta.DTOs.Responses.Application.Common.Responses;
using Application.AskForPasta.Interfaces.Repositories;
using Domain.AskForPasta.Entities;
using Infrastructure.AskForPasta.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.AskForPasta.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly ApplicationDbContext _context;

        public ClientRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<GenericResponse<int>> CreateAsync(Client entity)
        {
            await _context.Client.AddAsync(entity);
            await _context.SaveChangesAsync();

            return GenericResponse<int>.Ok(entity.Id, "Cliente cadastrado com sucesso.");
        }

        public async Task<GenericResponse<Client>> GetByIdAsync(int id)
        {
            Client? entity = await _context.Client.Where(u => u.Id == id).FirstOrDefaultAsync();

            if (entity == null)
                return GenericResponse<Client>.Fail("Cliente não foi encontrado.");

            return GenericResponse<Client>.Ok(entity, "Cliente encontrado com sucesso.");
        }
    }
}
