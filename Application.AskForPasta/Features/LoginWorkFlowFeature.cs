using Application.AskForPasta.DTOs.Requests;
using Application.AskForPasta.DTOs.Requests.Validators;
using Application.AskForPasta.DTOs.Responses;
using Application.AskForPasta.DTOs.Responses.Application.Common.Responses;
using Application.AskForPasta.Interfaces.Features;
using FluentValidation.Results;

namespace Application.AskForPasta.Features
{
    public class LoginWorkFlowFeature : ILoginWorkFlowFeature
    {

        private readonly IAddressFeature addressFeature;
        private readonly IClientFeature clientFeature;
        private readonly IUserFeature userFeature;

        public LoginWorkFlowFeature(IAddressFeature addressFeature, IClientFeature clientFeature, IUserFeature userFeature)
        {
            this.addressFeature = addressFeature;
            this.clientFeature = clientFeature;
            this.userFeature = userFeature;
        }

        public async Task<GenericResponse<UserResponseDto>> CreateUserAccessAsync(CreateUserAccessRequestDto request)
        {
            List<string> errors = new();

            CreateUserAccessRequestValidator validator = new();

            ValidationResult validationResult = await validator.ValidateAsync(request);

            if (validationResult.IsValid == false)
                return GenericResponse<UserResponseDto>.Fail("Os dados informados são inválidos.", validationResult.Errors.Select(e => e.ErrorMessage).ToList());

            GenericResponse<AddressResponseDto> addressResult = await addressFeature.CreateAsync(new CreateAddressRequestDto(request.User) { ZipCode = request.ZipCode, Street = request.Street, Neighborhood = request.Neighborhood, Number = request.Number, Complement = request.Complement, City = request.City, State = request.State });
            if (addressResult.IsInvalidReturn())
                return GenericResponse<UserResponseDto>.Fail(addressResult.Message, addressResult.Errors);

            request.AddressId = addressResult.Data!.AddressId;

            GenericResponse<UserResponseDto> userResult = await userFeature.CreateAsync(new CreateUserRequestDto(request.User) { NickName = request.NickName, CellPhone = request.CellPhone, Document = request.Document, Email = request.Email, Password = request.Password, UserTypeId = request.UserTypeId });
            if (userResult.IsInvalidReturn())
                return GenericResponse<UserResponseDto>.Fail(userResult.Message, userResult.Errors);

            request.UserId = userResult.Data!.UserId;

            GenericResponse<ClientResponseDto> clientResult = await clientFeature.CreateAsync(new CreateClientRequestDto(request.User) { FullName = request.FullName, AddressId = request.AddressId, BirthDate = request.BirthDate, Gender = request.Gender, UserId = request.UserId });
            if (clientResult.Success == false || clientResult.Data == null)
                return GenericResponse<UserResponseDto>.Fail(clientResult.Message, clientResult.Errors);

            return await userFeature.GetByIdAsync(request.UserId);
        }

        public Task<GenericResponse<bool>> EndSessionAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<GenericResponse<bool>> RequestPasswordRecoveryAsync(RecoveryRequestDto request)
        {
            throw new NotImplementedException();
        }

        public Task<GenericResponse<bool>> ResetPasswordAsync(ResetPasswordRequestDto request)
        {
            throw new NotImplementedException();
        }

        public async Task<GenericResponse<bool>> StartSessionAsync(StartSessionRequestDto request)
        {
            try
            {
                return null;
                //return await userRepository.GetUserToLoginAsync(request.Email, request.Password);
            }
            catch (Exception ex)
            {
                return GenericResponse<bool>.Fail("Ocorreu um erro inesperado ao iniciar a sessão.", new List<string> { ex.Message });
            }
        }
    }
}
