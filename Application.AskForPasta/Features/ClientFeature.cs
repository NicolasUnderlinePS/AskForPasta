using Application.AskForPasta.DTOs.Requests;
using Application.AskForPasta.DTOs.Responses;
using Application.AskForPasta.DTOs.Responses.Application.Common.Responses;
using Application.AskForPasta.Extensions;
using Application.AskForPasta.Interfaces.Features;
using Application.AskForPasta.Interfaces.Repositories;
using Domain.AskForPasta.Entities;

namespace Application.AskForPasta.Features
{
    public class ClientFeature : IClientFeature
    {
        private readonly IClientRepository clientRepository;

        public ClientFeature(IClientRepository clientRepository)
        {
            this.clientRepository = clientRepository;
        }

        private async Task<GenericResponse<ClientResponseDto>> UpdateClientAsync(int clientId, Action<Client> updateAction, string successMessage = "")
        {
            GenericResponse<Client> response = await clientRepository.GetByIdAsync(clientId);

            if (response.IsInvalidReturn())
                return GenericResponse<ClientResponseDto>.Fail("Cliente não foi encontrado.");

            Client entity = response.Data!;

            updateAction(entity);

            response = await clientRepository.UpdateAsync(entity);

            return GenericResponse<ClientResponseDto>.Ok(ClientExtension.ClientResponseDto(response.Data), string.IsNullOrEmpty(successMessage) ? response.Message : successMessage);
        }
        public async Task<GenericResponse<ClientResponseDto>> InsertAsync(CreateClientRequestDto request)
        {
            Client entity = new Client(request.FullName, request.Gender, request.BirthDate, request.AddressId, request.UserId, request.RequestTime);

            GenericResponse<int> response = GenericResponse<int>.Ok(0);

            response = await clientRepository.InsertAsync(entity);

            if (response.IsInvalidReturn())
                return GenericResponse<ClientResponseDto>.Fail(response.Message, response.Errors);

            return await GetByIdAsync(response.Data);
        }
        public async Task<GenericResponse<ClientResponseDto>> GetByIdAsync(int id)
        {
            GenericResponse<Client> entity = await clientRepository.GetByIdAsync(id);

            return GenericResponse<ClientResponseDto>.Ok(ClientExtension.ClientResponseDto(entity.Data), entity.Message);
        }
        public async Task<GenericResponse<ClientResponseDto>> UpdateAsync(UpdateClientRequestDto request)
        {
            return await UpdateClientAsync(request.ClientId, p => p.UpdateClient(request.ClientId, request.FullName, request.Gender, request.BirthDate, request.AddressId, request.UserId), "Cliente atualizada com sucesso.");
        }
    }
}
