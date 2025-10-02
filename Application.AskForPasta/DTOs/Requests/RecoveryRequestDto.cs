using Domain.AskForPasta.Entities;

namespace Application.AskForPasta.DTOs.Requests
{
    public sealed class RecoveryRequestDto : BaseRequest
    {
        public RecoveryRequestDto(User user) : base(user)
        {
        }
        public required string Email { get; set; }
   
    }
}
