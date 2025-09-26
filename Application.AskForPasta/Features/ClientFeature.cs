using Application.AskForPasta.DTOs.Requests;
using Application.AskForPasta.DTOs.Responses;
using Application.AskForPasta.DTOs.Responses.Application.Common.Responses;
using Application.AskForPasta.Extensions;
using Application.AskForPasta.Interfaces.Features;
using Application.AskForPasta.Interfaces.Repositories;
using Domain.AskForPasta.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.AskForPasta.Features
{
    public class ClientFeature : IClientFeature
    {
        private readonly IClientRepository clientRepository;

        public ClientFeature(IClientRepository clientRepository)
        {
            this.clientRepository = clientRepository;
        }

        public async Task<GenericResponse<ClientResponseDto>> CreateAsync(CreateClientRequestDto request)
        {
            Client client = new Client(request.FullName, request.Gender, request.BirthDate, request.AddressId, request.UserId, request.RequestTime);
            
            GenericResponse<int> response = GenericResponse<int>.Ok(0);

            response = await clientRepository.CreateAsync(client);

            if (response.Success)
                return await GetByIdAsync(response.Data);
            else
                return GenericResponse<ClientResponseDto>.Fail(response.Message, response.Errors);
        }

        public async Task<GenericResponse<ClientResponseDto>> GetByIdAsync(int id)
        {
            GenericResponse<Client> entity = await clientRepository.GetByIdAsync(id);

            return GenericResponse<ClientResponseDto>.Ok(ClientExtension.AddressResponseDto(entity.Data), entity.Message);
        }
    }
}
