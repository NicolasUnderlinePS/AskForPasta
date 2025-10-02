using Domain.AskForPasta.Entities;

namespace Application.AskForPasta.DTOs.Requests
{
    public sealed class ResetPasswordRequestDto : BaseRequest
    {
        public ResetPasswordRequestDto(User user) : base(user)
        {
        }
    }
}
