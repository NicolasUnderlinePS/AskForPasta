using Domain.AskForPasta.Entities;

namespace Application.AskForPasta.DTOs.Requests
{
    public sealed class CreateClientRequestDto : BaseRequest
    {
        public CreateClientRequestDto(User user) : base(user)
        {
        }

        public required string FullName { get; set; }
        public required int Gender { get; set; }
        public required DateTime BirthDate { get; set; }
        public required int AddressId { get; set; }
        public required int UserId { get; set; }
    }
}
