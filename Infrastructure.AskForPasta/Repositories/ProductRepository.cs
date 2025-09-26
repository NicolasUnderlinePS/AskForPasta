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

        public async Task<GenericResponse<int>> CreateProductAsync(Product entity)
        {
            await _context.Product.AddAsync(entity);
            await _context.SaveChangesAsync();

            return GenericResponse<int>.Ok(entity.Id, "Produto criado com sucesso.");
        }

        public async Task<GenericResponse<Product>> GetProductByIdAsync(int id)
        {
            Product? entity = await _context.Product.Where(u => u.Id == id).FirstOrDefaultAsync();

            if (entity == null)
                return GenericResponse<Product>.Fail("Produto não foi encontrado.");

            return GenericResponse<Product>.Ok(entity, "Produto encontrado com sucesso.");
        }
    }
}
