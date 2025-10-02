using Application.AskForPasta.DTOs.Requests;
using Application.AskForPasta.DTOs.Responses;
using Application.AskForPasta.DTOs.Responses.Application.Common.Responses;
using Application.AskForPasta.Extensions;
using Application.AskForPasta.Interfaces.Features;
using Application.AskForPasta.Interfaces.Repositories;
using Domain.AskForPasta.Entities;
using System.Transactions;

namespace Application.AskForPasta.Features
{
    public class AddressFeature : IAddressFeature
    {
        private readonly IAddressRepository addressRepository;
        public AddressFeature(IAddressRepository addressRepository)
        {
            this.addressRepository = addressRepository;
        }

        private async Task<GenericResponse<AddressResponseDto>> UpdateAddressAsync(int addressId, Action<Address> updateAction, string successMessage = "")
        {
            GenericResponse<Address> response = await addressRepository.GetByIdAsync(addressId);

            if (response.IsInvalidReturn())
                return GenericResponse<AddressResponseDto>.Fail("Endereço não foi encontrado.");

            Address entity = response.Data!;

            updateAction(entity);

            response = await addressRepository.UpdateAsync(entity);

            return GenericResponse<AddressResponseDto>.Ok(AddressExtension.AddressResponseDto(response.Data), string.IsNullOrEmpty(successMessage) ? response.Message : successMessage);
        }

        public async Task<GenericResponse<AddressResponseDto>> InsertAsync(CreateAddressRequestDto request)
        {
            Address entity = new Address(request.ZipCode, request.Street, request.Neighborhood, request.Number, request.Complement, request.City, request.State, request.RequestTime);
            
            GenericResponse<int> response = GenericResponse<int>.Ok(0);
                
            response = await addressRepository.InsertAsync(entity);

            if (response.IsInvalidReturn())
                return GenericResponse<AddressResponseDto>.Fail(response.Message, response.Errors);
                
            return await GetByIdAsync(response.Data);
        }

        public async Task<GenericResponse<AddressResponseDto>> GetByIdAsync(int id)
        {
            GenericResponse<Address> entity = await addressRepository.GetByIdAsync(id);

            return GenericResponse<AddressResponseDto>.Ok(AddressExtension.AddressResponseDto(entity.Data), entity.Message);
        }

        public async Task<GenericResponse<AddressResponseDto>> UpdateAsync(UpdateAddressRequestDto request)
        {
            return await UpdateAddressAsync(request.AddressId, p => p.UpdateAddress(request.ZipCode, request.Street, request.Neighborhood, request.Number, request.Complement, request.City, request.State), "Endereço atualizada com sucesso.");
        }
    }
}
