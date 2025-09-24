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
            try
            {
                await _context.User.AddAsync(entity);
                await _context.SaveChangesAsync();

                return GenericResponse<int>.Ok(entity.Id, "Usuário criado com sucesso.");
            }
            catch (DbUpdateConcurrencyException concEx)
            {
                // Conflito de concorrência
                return GenericResponse<int>.Fail("Não foi possível salvar o usuário, tente novamente.", new List<string>() { concEx.Message });
            }
            catch (DbUpdateException dbEx)
            {
                // Captura problemas de banco, como violação de FK, constraints etc.
                return GenericResponse<int>.Fail("Não foi possível salvar o usuário no momento.", new List<string>() { dbEx.Message });
            }
            catch (Exception ex)
            {
                // Exceção genérica
                return GenericResponse<int>.Fail("Ocorreu um erro inesperado, tente novamente mais tarde.", new List<string>() { ex.Message });
            }
        }

        public async Task<GenericResponse<User>> GetUserByIdAsync(int id)
        {
            try
            {
                User? user = await _context.User.Where(u => u.Id == id).FirstOrDefaultAsync();

                if (user == null)
                    return GenericResponse<User>.Fail("Usuário não foi encontrado.");

                return GenericResponse<User>.Ok(user, "Usuário encontrado com sucesso.");
            }
            catch (Exception ex)
            {
                return GenericResponse<User>.Fail("Ocorreu um erro inesperado ao buscar o usuário.", new List<string> { ex.Message });
            }
        }

        public async Task<GenericResponse<bool>> GetUserToLoginAsync(string email, string password)
        {
            try
            {
                User? user = await _context.User.Where(u => u.Email == email && u.EncryptPassword == password && u.IsActive).FirstOrDefaultAsync();

                if (user == null)
                    return GenericResponse<bool>.Fail("Usuário ou senha inválidos, ou usuário inativo.");

                return GenericResponse<bool>.Ok(true, "Login realizado com sucesso.");
            }
            catch (Exception ex)
            {
                return GenericResponse<bool>.Fail("Ocorreu um erro inesperado ao realizar o login.", new List<string> { ex.Message });
            }
        }
    }
}
