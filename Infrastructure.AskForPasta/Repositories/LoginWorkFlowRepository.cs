using Application.AskForPasta.DTOs.Requests;
using Application.AskForPasta.DTOs.Responses.Application.Common.Responses;
using Application.AskForPasta.Interfaces.Repositories;
using Domain.AskForPasta.Entities;
using Infrastructure.AskForPasta.Contexts;

namespace Infrastructure.AskForPasta.Repositories
{
    public class LoginWorkFlowRepository : ILoginWorkFlowRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IUserRepository userRepository;
        private readonly IClientRepository clientRepository;
        private readonly IAddressRepository addressRepository;

        public LoginWorkFlowRepository(ApplicationDbContext context, IUserRepository userRepository, IClientRepository clientRepository, IAddressRepository addressRepository)
        {
            _context = context;
            this.userRepository = userRepository;
            this.clientRepository = clientRepository;
            this.addressRepository = addressRepository;
        }

        public async Task<GenericResponse<bool>> CreateUserAccessAsync(CreateUserAccessRequestDto request)
        {
            await using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                GenericResponse<int> response = GenericResponse<int>.Ok(0);

                response = await addressRepository.CreateAddressAsync(new Address(request.ZipCode, request.Street, request.Neighborhood, request.Number, request.CellPhone, request.City, request.State, request.RequestTime));

                if (response.Success == false)
                    return GenericResponse<bool>.Fail(response.Message, response.Errors);

                request.AddressId = response.Data;
                response = await userRepository.CreateUserAsync(new User(request.NickName, request.Document, request.Email, request.CellPhone, false, request.Password, request.UserTypeId, request.RequestTime));

                if (response.Success == false)
                    return GenericResponse<bool>.Fail(response.Message, response.Errors);

                request.UserId = response.Data;
                response = await clientRepository.CreateClientAsync(new Client(request.FullName, request.Gender, request.BirthDate, request.AddressId, request.UserId, request.RequestTime));

                if (response.Success)
                {
                    await transaction.CommitAsync();
                    return GenericResponse<bool>.Ok(response.Success, response.Message);

                }
                else
                    return GenericResponse<bool>.Fail(response.Message, response.Errors);
            }
            catch (Exception ex)
            {
                return GenericResponse<bool>.Fail("Ocorreu um erro inesperado ao criar o usuário.", new List<string> { ex.Message });
            }
        }
    }
}
