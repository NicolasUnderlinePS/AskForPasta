using Domain.AskForPasta.Entities;

namespace Application.AskForPasta.DTOs.Requests
{
    public sealed class CreateProductRequestDto : BaseRequest
    {
        public CreateProductRequestDto(User user) : base(user)
        {
        }

        public required string Name { get; set; }

    }
}