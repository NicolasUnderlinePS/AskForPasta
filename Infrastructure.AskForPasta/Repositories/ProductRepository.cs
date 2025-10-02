using Application.AskForPasta.DTOs.Responses.Application.Common.Responses;
using Application.AskForPasta.Interfaces.Repositories;
using Domain.AskForPasta.Entities;
using Infrastructure.AskForPasta.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.AskForPasta.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<GenericResponse<int>> InsertAsync(Product entity)
        {
            await _context.Product.AddAsync(entity);
            await _context.SaveChangesAsync();

            return GenericResponse<int>.Ok(entity.Id, "Produto criado com sucesso.");
        }

        public async Task<GenericResponse<Product>> GetByIdAsync(int id)
        {
            Product? entity = await _context.Product.Where(u => u.Id == id).FirstOrDefaultAsync();

            if (entity == null)
                return GenericResponse<Product>.Fail("Produto não foi encontrado.");

            return GenericResponse<Product>.Ok(entity, "Produto encontrado com sucesso.");
        }

        public async Task<GenericResponse<int>> IncreaseFromStock(int productId, int quantity)
        {
            Product? product = await _context.Product.FindAsync(productId);

            if (product == null)
                return GenericResponse<int>.Fail("Produto não encontrado.");

            product.IncreaseStock(quantity);

            await _context.SaveChangesAsync();

            return GenericResponse<int>.Ok(product.StockQuantity, "Estoque aumentado com sucesso.");
        }

        public async Task<GenericResponse<int>> SubtractFromStock(int productId, int quantity)
        {
            Product? product = await _context.Product.FindAsync(productId);

            if (product == null)
                return GenericResponse<int>.Fail("Produto não encontrado.");

            product.DecreaseStock(quantity);

            await _context.SaveChangesAsync();

            return GenericResponse<int>.Ok(product.StockQuantity, "Estoque reduzido com sucesso.");
        }

        public async Task<GenericResponse<Product>> UpdateAsync(Product entity)
        {
            await _context.SaveChangesAsync();

            return GenericResponse<Product>.Ok(entity, "Produto atualizado com sucesso.");
        }
    }
}
