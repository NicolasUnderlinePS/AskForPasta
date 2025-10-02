namespace Domain.AskForPasta.Entities
{
    public class Client : BaseEntity
    {
        public Client(string fullName, int gender, DateTime birthDate, int addressId, int userId, DateTime createAt) : base(createAt)
        {
            FullName = fullName;
            Gender = gender;
            BirthDate = birthDate;
            AddressId = addressId;
            UserId = userId;
        }

        public string FullName { get; private set; }
        public int Gender { get; private set; }
        public DateTime BirthDate { get; private set; }
        public int AddressId { get; private set; }
        public int UserId { get; private set; }

        public void UpdateClient(int clientId, string fullName, int gender, DateTime birthDate, int addressId, int userId)
        {
            SetUpdateAt(UpdateAt);
        }
    }
}
