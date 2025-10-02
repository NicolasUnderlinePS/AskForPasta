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

        public void UpdateZipCode(string zipCode)
        {
            if (string.IsNullOrWhiteSpace(zipCode))
                throw new ArgumentException("O CEP não pode ser vazio.");

            ZipCode = zipCode;
        }

        public void UpdateStreet(string street)
        {
            if (string.IsNullOrWhiteSpace(street))
                throw new ArgumentException("A rua não pode ser vazia.");
            Street = street;
        }

        public void UpdateNeighborhood(string neighborhood)
        {
            if (string.IsNullOrWhiteSpace(neighborhood))
                throw new ArgumentException("O bairro não pode ser vazio.");
            Neighborhood = neighborhood;
        }

        public void UpdateNumber(string number)
        {
            if (string.IsNullOrWhiteSpace(number))
                throw new ArgumentException("O número não pode ser vazio.");
            Number = number;
        }

        public void UpdateComplement(string complement)
        {
            Complement = complement;
        }

        public void UpdateCity(string city)
        {
            if (string.IsNullOrWhiteSpace(city))
                throw new ArgumentException("A cidade não pode ser vazia.");
            City = city;
        }

        public void UpdateState(string state)
        {
            if (string.IsNullOrWhiteSpace(state))
                throw new ArgumentException("O estado não pode ser vazio.");
            State = state;
        }

        public void UpdateAddress(string zipCode, string street, string neighborhood, string number, string complement, string city, string state)
        {
            SetUpdateAt(UpdateAt);

            if (ZipCode != zipCode)
                UpdateZipCode(zipCode);

            if (Street != street)
                UpdateStreet(street);

            if (Neighborhood != neighborhood)
                UpdateNeighborhood(neighborhood);

            if (Number != number)
                UpdateNumber(number);

            if (Complement != complement)
                UpdateComplement(complement);
            
            if (City != city)
                UpdateCity(city);
            
            if( State != state)
                UpdateState(state);
        }
    }
}
