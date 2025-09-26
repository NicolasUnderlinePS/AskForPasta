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

        public async Task<GenericResponse<AddressResponseDto>> CreateAsync(CreateAddressRequestDto request)
        {
            Address address = new Address(request.ZipCode, request.Street, request.Neighborhood, request.Number, request.Complement, request.City, request.State, request.RequestTime);
            
            GenericResponse<int> response = GenericResponse<int>.Ok(0);
                
            response = await addressRepository.CreateAsync(address);

            if (response.Success)
                return await GetByIdAsync(response.Data);
            else
                return GenericResponse<AddressResponseDto>.Fail(response.Message, response.Errors);
        }

        public async Task<GenericResponse<AddressResponseDto>> GetByIdAsync(int id)
        {
            GenericResponse<Address> entity = await addressRepository.GetByIdAsync(id);

            return GenericResponse<AddressResponseDto>.Ok(AddressExtension.AddressResponseDto(entity.Data), entity.Message);
        }
    }
}
