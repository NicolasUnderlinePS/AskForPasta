using Application.AskForPasta.DTOs.Responses.Application.Common.Responses;
using Application.AskForPasta.Interfaces.Repositories;
using Domain.AskForPasta.Entities;
using Infrastructure.AskForPasta.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.AskForPasta.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly ApplicationDbContext _context;

        public PaymentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<GenericResponse<Payment>> GetByIdAsync(int id)
        {
            Payment? entity = await _context.Payment.Where(u => u.Id == id).FirstOrDefaultAsync();

            if (entity == null)
                return GenericResponse<Payment>.Fail("Endereço não foi encontrado.");

            return GenericResponse<Payment>.Ok(entity, "Pagamento encontrado com sucesso.");

        }

        public async Task<GenericResponse<int>> InsertAsync(Payment entity)
        {
            await _context.Payment.AddAsync(entity);
            await _context.SaveChangesAsync();

            return GenericResponse<int>.Ok(entity.Id, "Pagamento criado com sucesso.");
        }

        public async Task<GenericResponse<Payment>> UpdateAsync(Payment entity)
        {
            await _context.SaveChangesAsync();

            return GenericResponse<Payment>.Ok(entity, "Pagamento atualizado com sucesso.");

        }
    }
}
