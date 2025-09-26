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

        public async Task<GenericResponse<int>> CreateUserAsync(User entity)
        {
            await _context.User.AddAsync(entity);
            await _context.SaveChangesAsync();

            return GenericResponse<int>.Ok(entity.Id, "Usuário criado com sucesso.");
        }

        public async Task<GenericResponse<User>> GetUserByIdAsync(int id)
        {
            User? entity = await _context.User.Where(u => u.Id == id).FirstOrDefaultAsync();

            if (entity == null)
                return GenericResponse<User>.Fail("Usuário não foi encontrado.");

            return GenericResponse<User>.Ok(entity, "Usuário encontrado com sucesso.");
        }

        public async Task<GenericResponse<bool>> GetUserToLoginAsync(string email, string password)
        {
            User? entity = await _context.User.Where(u => u.Email == email && u.EncryptPassword == password && u.IsActive).FirstOrDefaultAsync();

            if (entity == null)
                return GenericResponse<bool>.Fail("Usuário ou senha inválidos, ou usuário inativo.");

            return GenericResponse<bool>.Ok(true, "Login realizado com sucesso.");
        }
    }
}
