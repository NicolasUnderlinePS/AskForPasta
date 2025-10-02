using Domain.AskForPasta.Entities;

namespace Application.AskForPasta.DTOs.Requests
{
    public class CreateUserRequestDto : BaseRequest
    {
        public CreateUserRequestDto(User user) : base(user)
        {
        }

        public int UserId { get; set; }
        public required string NickName { get; set; }
        public required string Document { get; set; }
        public required string Email { get; set; }
        public required string CellPhone { get; set; }
        public required string Password { get; set; }
        public required int UserTypeId { get; set; }
    }
}
