using Domain.AskForPasta.Entities;

namespace Application.AskForPasta.DTOs.Requests
{
    public class UpdateClientRequestDto : BaseRequest
    {
        public UpdateClientRequestDto(User user) : base(user)
        {
        }

        public required int ClientId { get; set; }
        public required string FullName { get; set; }
        public required int Gender { get; set; }
        public required DateTime BirthDate { get; set; }
        public required int AddressId { get; set; }
        public required int UserId { get; set; }
    }
}
