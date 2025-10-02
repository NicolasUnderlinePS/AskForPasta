using Domain.AskForPasta.Entities;

namespace Application.AskForPasta.DTOs.Requests
{
    public sealed class StartSessionRequestDto : BaseRequest
    {
        public StartSessionRequestDto(User user) : base(user)
        {
        }

        public required string Email { get; set; }
        public required string Password { get; set; }


    }
}
