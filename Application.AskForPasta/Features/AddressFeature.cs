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

        public async Task<GenericResponse<int>> CreateAddressAsync(CreateAddressRequestDto request)
        {
            GenericResponse<int> response = GenericResponse<int>.Ok(0);
            Address address = new Address(request.ZipCode, request.Street, request.Neighborhood, request.Number, request.Complement, request.City, request.State, request.RequestTime);
                
            response = await addressRepository.CreateAddressAsync(address);

            if (response.Success)
                return GenericResponse<int>.Ok(address.Id, response.Message);
            else
                return GenericResponse<int>.Fail(response.Message, response.Errors);
        }
    }
}
