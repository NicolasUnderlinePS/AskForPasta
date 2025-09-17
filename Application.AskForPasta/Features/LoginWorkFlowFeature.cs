using Application.AskForPasta.DTOs.Requests;
using Application.AskForPasta.DTOs.Requests.Validators;
using Application.AskForPasta.DTOs.Responses.Application.Common.Responses;
using Application.AskForPasta.Interfaces.Features;
using Application.AskForPasta.Interfaces.Repositories;
using FluentValidation.Results;

namespace Application.AskForPasta.Features
{
    public class LoginWorkFlowFeature : ILoginWorkFlowFeature
    {
        private readonly ILoginWorkFlowRepository loginWorkFlowRepository;

        public LoginWorkFlowFeature(ILoginWorkFlowRepository loginWorkFlowRepository)
        {
            this.loginWorkFlowRepository = loginWorkFlowRepository;
        }

        public async Task<GenericResponse<bool>> CreateUserAccessAsync(CreateUserAccessRequestDto request)
        {
            List<string> errors = new();
            try
            {
                CreateUserAccessRequestValidator validator = new();

                ValidationResult validationResult = await validator.ValidateAsync(request);

                if (validationResult.IsValid == false)
                {
                    errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                    return GenericResponse<bool>.Fail("Os dados informados são inválidos.", errors);
                }

                return await loginWorkFlowRepository.CreateUserAccessAsync(request);
            }
            catch (Exception ex)
            {
                return GenericResponse<bool>.Fail("Ocorreu um erro inesperado ao criar o usuário.", new List<string> { ex.Message });
            }
        }
    }
}
