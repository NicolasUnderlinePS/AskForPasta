using Application.AskForPasta.DTOs.Responses.Application.Common.Responses;
using Application.AskForPasta.Interfaces.Repositories;
using Domain.AskForPasta.Entities;
using Infrastructure.AskForPasta.Contexts;

namespace Infrastructure.AskForPasta.Repositories
{
    public class PurchaseProductRepository : IPurchaseProductRepository
    {
        private readonly ApplicationDbContext _context;
        public PurchaseProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<GenericResponse<int>> InsertAsync(PurchaseProduct entity)
        {
            await _context.PurchaseProduct.AddAsync(entity);
            await _context.SaveChangesAsync();

            return GenericResponse<int>.Ok(entity.Id, "Produto inserido com sucesso.");
        }

        public async Task<GenericResponse<PurchaseProduct>> GetByIdAsync(int id)
        {
            PurchaseProduct entity = await _context.PurchaseProduct.FindAsync(id);

            if (entity == null)
                return GenericResponse<PurchaseProduct>.Fail("Produto não foi encontrado.");

            return GenericResponse<PurchaseProduct>.Ok(entity, "Produto encontrado com sucesso.");
        }

        public async Task<GenericResponse<PurchaseProduct>> UpdateAsync(PurchaseProduct entity)
        {
            await _context.SaveChangesAsync();

            return GenericResponse<PurchaseProduct>.Ok(entity, "Produto atualizado com sucesso.");
        }
    }
}
