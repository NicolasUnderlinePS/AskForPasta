using Application.AskForPasta.DTOs.Requests;
using Application.AskForPasta.DTOs.Responses;
using Application.AskForPasta.DTOs.Responses.Application.Common.Responses;
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

        public async Task<GenericResponse<int>> CreateClientAsync(CreateClientRequestDto request)
        {
            GenericResponse<int> response = GenericResponse<int>.Ok(0);
            Client client = new Client(request.FullName, request.Gender, request.BirthDate, request.AddressId, request.UserId, request.RequestTime);

            response = await clientRepository.CreateClientAsync(client);

            if (response.Success)
                return GenericResponse<int>.Ok(client.Id, response.Message);
            else
                return GenericResponse<int>.Fail(response.Message, response.Errors);
        }
    }
}
