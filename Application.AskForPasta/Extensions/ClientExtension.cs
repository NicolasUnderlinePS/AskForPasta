using Application.AskForPasta.DTOs.Responses;
using Domain.AskForPasta.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.AskForPasta.Extensions
{
    public static class ClientExtension
    {
        public static ClientResponseDto? ClientResponseDto(Client? entity)
        {
            if (entity == null) return null;

            return new ClientResponseDto();
        }
    }
}
