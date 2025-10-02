using Application.AskForPasta.DTOs.Responses.Application.Common.Responses;
using Application.AskForPasta.Interfaces.Repositories;
using Domain.AskForPasta.Entities;
using Infrastructure.AskForPasta.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.AskForPasta.Repositories
{
    public class PurchaseRepository : IPurchaseRepository
    {
        private readonly ApplicationDbContext _context;

        public PurchaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<GenericResponse<int>> InsertAsync(Purchase entity)
        {
            await _context.Purchase.AddAsync(entity);
            await _context.SaveChangesAsync();

            return GenericResponse<int>.Ok(entity.Id, "Pedido criado com sucesso.");
        }

        public async Task<GenericResponse<Purchase>> GetByIdAsync(int id)
        {
            Purchase? entity = await _context.Purchase.Where(u => u.Id == id).FirstOrDefaultAsync();

            if (entity == null)
                return GenericResponse<Purchase>.Fail("Pedido não foi encontrado.");

            return GenericResponse<Purchase>.Ok(entity, "Pedido encontrado com sucesso.");
        }

        public async Task<GenericResponse<Purchase>> UpdateAsync(Purchase entity)
        {
            await _context.SaveChangesAsync();

            return GenericResponse<Purchase>.Ok(entity, "Pedido atualizado com sucesso.");
        }
    }
}
