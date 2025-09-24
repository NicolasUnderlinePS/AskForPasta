using Domain.AskForPasta.Entities;

namespace Application.AskForPasta.DTOs.Requests
{
    public sealed class CreateAddressRequestDto : BaseRequest
    {
        public CreateAddressRequestDto(User user) : base(user)
        {

        }

        public required string ZipCode { get; set; }
        public required string Street { get; set; }
        public required string Neighborhood { get; set; }
        public required string Number { get; set; }
        public required string Complement { get; set; }
        public required string City { get; set; }
        public required string State { get; set; }
    }
}
