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

        public async Task<GenericResponse<int>> CreateAddressAsync(Address entity)
        {
            try
            {
                await _context.Address.AddAsync(entity);
                await _context.SaveChangesAsync();

                return GenericResponse<int>.Ok(entity.Id, "Endereço criado com sucesso.");
            }
            catch (DbUpdateConcurrencyException concEx)
            {
                // Conflito de concorrência
                return GenericResponse<int>.Fail("Não foi possível salvar o endereço, tente novamente.", new List<string>(){ concEx.Message });
            }
            catch (DbUpdateException dbEx)
            {
                // Captura problemas de banco, como violação de FK, constraints etc.
                return GenericResponse<int>.Fail("Não foi possível salvar o endereço no momento.", new List<string>() { dbEx.Message });
            }
            catch (Exception ex)
            {
                // Exceção genérica
                return GenericResponse<int>.Fail("Ocorreu um erro inesperado, tente novamente mais tarde.", new List<string>() { ex.Message });
            }
        }
    }
}
