using Application.AskForPasta.DTOs.Requests;
using Application.AskForPasta.DTOs.Requests.Validators;
using Application.AskForPasta.DTOs.Responses;
using Application.AskForPasta.DTOs.Responses.Application.Common.Responses;
using Application.AskForPasta.Extensions;
using Application.AskForPasta.Interfaces.Features;
using FluentValidation.Results;
using System.Transactions;

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
            try
            {
                using var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);

                CreateUserAccessRequestValidator validator = new ();
                ValidationResult validationResult = await validator.ValidateAsync(request);

                if (validationResult.IsValid == false)
                    return GenericResponse<UserResponseDto>.Fail("Os dados informados são inválidos.",validationResult.Errors.Select(e => e.ErrorMessage).ToList());

                CreateAddressRequestDto addressDto = new CreateAddressRequestDto(request.User)
                {
                    ZipCode = request.ZipCode,
                    Street = request.Street,
                    Neighborhood = request.Neighborhood,
                    Number = request.Number,
                    Complement = request.Complement,
                    City = request.City,
                    State = request.State
                };

                GenericResponse<AddressResponseDto> addressResult = await addressFeature.InsertAsync(addressDto);
                if (addressResult.IsInvalidReturn())
                    return GenericResponse<UserResponseDto>.Fail(addressResult.Message, addressResult.Errors);

                request.AddressId = addressResult.Data!.AddressId;

                CreateUserRequestDto userDto = new CreateUserRequestDto(request.User)
                {
                    NickName = request.NickName,
                    CellPhone = request.CellPhone,
                    Document = request.Document,
                    Email = request.Email,
                    Password = request.Password,
                    UserTypeId = request.UserTypeId
                };

                GenericResponse<UserResponseDto> userResult = await userFeature.InsertAsync(userDto);
                if (userResult.IsInvalidReturn())
                    return GenericResponse<UserResponseDto>.Fail(userResult.Message, userResult.Errors);

                request.UserId = userResult.Data!.UserId;

                CreateClientRequestDto clientDto = new CreateClientRequestDto(request.User)
                {
                    FullName = request.FullName,
                    AddressId = request.AddressId,
                    BirthDate = request.BirthDate,
                    Gender = request.Gender,
                    UserId = request.UserId
                };

                GenericResponse<ClientResponseDto> clientResult = await clientFeature.InsertAsync(clientDto);
                if (clientResult.IsInvalidReturn())
                    return GenericResponse<UserResponseDto>.Fail(clientResult.Message, clientResult.Errors);

                scope.Complete();

                return await userFeature.GetByIdAsync(request.UserId);
            }
            catch (Exception ex)
            {
                return GenericResponse<UserResponseDto>.Fail("Erro inesperado ao criar acesso de usuário.", new List<string> { ex.Message });
            }
        }


        public Task<GenericResponse<bool>> EndSessionAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public async Task<GenericResponse<bool>> RequestPasswordRecoveryAsync(RecoveryRequestDto request)
        {
            GenericResponse<UserResponseDto> response = await userFeature.GetUserByEmailAsync(request.Email);

            if (response.IsInvalidReturn())
            {
                //Log de tentativas de recuperação de senha para emails inválidos
            }

            //Enviar email para o usuário com o link para recuperação de senha

            return GenericResponse<bool>.Ok(true, "Caso o email informado seja válido em breve verifique seus emails para executar a troca de senha.");
        }

        public Task<GenericResponse<bool>> ResetPasswordAsync(ResetPasswordRequestDto request)
        {
            throw new NotImplementedException();
        }

        public async Task<GenericResponse<bool>> StartSessionAsync(StartSessionRequestDto request)
        {
            GenericResponse<UserResponseDto> response =  await userFeature.GetUserByEmailAsync(request.Email);
            
            if (response.IsInvalidReturn())
                return GenericResponse<bool>.Fail("Usuário ou senha inválidos.");

            if (PasswordHasherExtension.Verify(response.Data!.EncryptPassword, PasswordHasherExtension.Hash(request.Password)))
                return GenericResponse<bool>.Fail("Usuário ou senha inválidos.");

            if(response.Data.IsActive == false)
                return GenericResponse<bool>.Fail("Usuário ou senha inválidos.");

            return GenericResponse<bool>.Ok(true, "Login realizado com sucesso.");
        }
    }
}
