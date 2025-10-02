using Application.AskForPasta.DTOs.Responses.Application.Common.Responses;
using Application.AskForPasta.Interfaces.Repositories;
using Domain.AskForPasta.Entities;
using Infrastructure.AskForPasta.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.AskForPasta.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<GenericResponse<int>> InsertAsync(User entity)
        {
            await _context.User.AddAsync(entity);
            await _context.SaveChangesAsync();

            return GenericResponse<int>.Ok(entity.Id, "Usuário criado com sucesso.");
        }

        public async Task<GenericResponse<User>> GetByIdAsync(int id)
        {
            User? entity = await _context.User.Where(u => u.Id == id).FirstOrDefaultAsync();

            if (entity == null)
                return GenericResponse<User>.Fail("Usuário não foi encontrado.");

            return GenericResponse<User>.Ok(entity, "Usuário encontrado com sucesso.");
        }

        public async Task<GenericResponse<User>> GetUserByEmailAsync(string email)
        {
            User? entity = await _context.User.Where(u => u.Email == email).FirstOrDefaultAsync();

            if (entity == null)
                return GenericResponse<User>.Fail("Usuário não foi encontrado.");

            return GenericResponse<User>.Ok(entity, "Usuário encontrado com sucesso.");
        }

        public async Task<GenericResponse<User>> UpdateAsync(User entity)
        {
            await _context.SaveChangesAsync();
            
            return GenericResponse<User>.Ok(entity, "Usuário atualizado com sucesso.");
        }
    }
}
