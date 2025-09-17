using Domain.AskForPasta.Entities;

namespace Application.AskForPasta.DTOs.Requests
{
    public class CreateUserAccessRequestDto : BaseRequest
    {
        public CreateUserAccessRequestDto(User user) : base(user)
        {
        }

        public int AddressId { get; set; }
        public required string ZipCode { get; set; }
        public required string Street { get; set; }
        public required string Neighborhood { get; set; }
        public required string Number { get; set; }
        public required string Complement { get; set; }
        public required string City { get; set; }
        public required string State { get; set; }

        public int UserId { get; set; }
        public required string NickName { get; set; }
        public required string Document { get; set; }
        public required string Email { get; set; }
        public required string CellPhone { get; set; }
        public required string Password { get; set; }
        public int UserTypeId { get; set; }

        public required string FullName { get; set; }
        public int Gender { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
