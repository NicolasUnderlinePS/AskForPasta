using Application.AskForPasta.DTOs.Responses;
using Domain.AskForPasta.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.AskForPasta.Extensions
{
    public static class PurchaseExtension
    {
        public static PurchaseResponseDto? PurchaseResponseDto(Purchase? entity)
        {
            if (entity == null) return null;

            return new PurchaseResponseDto();
        }
    }
}
