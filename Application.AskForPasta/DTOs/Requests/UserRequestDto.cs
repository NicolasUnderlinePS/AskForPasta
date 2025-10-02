using Domain.AskForPasta.Entities;

namespace Application.AskForPasta.DTOs.Requests
{
    public class UserRequestDto : BaseRequest
    {
        public UserRequestDto(User user) : base(user)
        {
        }

        public required string Email { get; set; }
    }
}
