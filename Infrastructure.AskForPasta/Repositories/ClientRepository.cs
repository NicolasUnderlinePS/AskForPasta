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
    public class ClientRepository : IClientRepository
    {
        private readonly ApplicationDbContext _context;

        public ClientRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<GenericResponse<int>> CreateClientAsync(Client entity)
        {
            try
            {
                await _context.Client.AddAsync(entity);
                await _context.SaveChangesAsync();

                return GenericResponse<int>.Ok(entity.Id, "Cliente cadastrado com sucesso.");
            }
            catch (DbUpdateConcurrencyException concEx)
            {
                // Conflito de concorrência
                return GenericResponse<int>.Fail("Não foi possível salvar o cliente, tente novamente.", new List<string>() { concEx.Message });
            }
            catch (DbUpdateException dbEx)
            {
                // Captura problemas de banco, como violação de FK, constraints etc.
                return GenericResponse<int>.Fail("Não foi possível salvar o cliente no momento.", new List<string>() { dbEx.Message });
            }
            catch (Exception ex)
            {
                // Exceção genérica
                return GenericResponse<int>.Fail("Ocorreu um erro inesperado, tente novamente mais tarde.", new List<string>() { ex.Message });
            }
        }
    }
}
