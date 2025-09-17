using FluentValidation;

namespace Application.AskForPasta.DTOs.Requests.Validators
{
    public class CreateUserAccessRequestValidator : AbstractValidator<CreateUserAccessRequestDto>
    {
        public CreateUserAccessRequestValidator()
        {
            RuleFor(x => x.ZipCode)
                .NotEmpty().WithMessage("O CEP é obrigatório.")
                .MaximumLength(8).WithMessage("O CEP deve ter no máximo 8 caracteres.");

            RuleFor(x => x.Street)
                .NotEmpty().WithMessage("A rua é obrigatória.")
                .MaximumLength(100).WithMessage("A rua deve ter no máximo 100 caracteres.");

            RuleFor(x => x.Neighborhood)
                .NotEmpty().WithMessage("O bairro é obrigatório.")
                .MaximumLength(100).WithMessage("O bairro deve ter no máximo 100 caracteres.");

            RuleFor(x => x.Number)
                .NotEmpty().WithMessage("O número é obrigatório.")
                .MaximumLength(10).WithMessage("O número deve ter no máximo 10 caracteres.");

            RuleFor(x => x.Complement)
                .MaximumLength(50).WithMessage("O complemento deve ter no máximo 50 caracteres.");

            RuleFor(x => x.City)
                .NotEmpty().WithMessage("A cidade é obrigatória.")
                .MaximumLength(100).WithMessage("A cidade deve ter no máximo 100 caracteres.");

            RuleFor(x => x.State)
                .NotEmpty().WithMessage("O estado é obrigatório.")
                .Length(2).WithMessage("O estado deve ter exatamente 2 caracteres.");

            RuleFor(x => x.NickName)
                .NotEmpty().WithMessage("O apelido é obrigatório.")
                .MaximumLength(50).WithMessage("O apelido deve ter no máximo 50 caracteres.");

            RuleFor(x => x.Document)
                .NotEmpty().WithMessage("O documento é obrigatório.")
                .MaximumLength(14).WithMessage("O documento deve ter no máximo 14 caracteres.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("O e-mail é obrigatório.")
                .EmailAddress().WithMessage("O e-mail informado não é válido.")
                .MaximumLength(150).WithMessage("O e-mail deve ter no máximo 150 caracteres.");

            RuleFor(x => x.CellPhone)
                .NotEmpty().WithMessage("O celular é obrigatório.")
                .MaximumLength(13).WithMessage("O celular deve ter no máximo 13 caracteres.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("A senha é obrigatória.")
                .MaximumLength(50).WithMessage("A senha criptografada deve ter no máximo 50 caracteres.");

            RuleFor(x => x.UserTypeId)
                .GreaterThan(0).WithMessage("O tipo de usuário é obrigatório.");

            // Cliente
            RuleFor(x => x.FullName)
                .NotEmpty().WithMessage("O nome completo é obrigatório.")
                .MaximumLength(150).WithMessage("O nome completo deve ter no máximo 150 caracteres.");

            RuleFor(x => x.Gender)
                .InclusiveBetween(0, 2).WithMessage("O gênero deve ser um valor válido (0, 1 ou 2).");

            RuleFor(x => x.BirthDate)
                .NotEmpty().WithMessage("A data de nascimento é obrigatória.")
                .LessThan(DateTime.Now).WithMessage("A data de nascimento deve ser anterior à data atual.");
        }
    }
}
