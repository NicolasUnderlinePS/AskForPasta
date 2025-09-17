namespace Domain.AskForPasta.Entities
{
    public class Address : BaseEntity
    {
        public Address(string zipCode, string street, string neighborhood, string number, string complement, string city, string state, DateTime createAt) : base(createAt)
        {
            ZipCode = zipCode;
            Street = street;
            Neighborhood = neighborhood;
            Number = number;
            Complement = complement;
            City = city;
            State = state;
        }

        public string ZipCode { get; private set; }
        public string Street { get; private set; }
        public string Neighborhood { get; private set; }
        public string Number { get; private set; }
        public string Complement { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
    }
}
