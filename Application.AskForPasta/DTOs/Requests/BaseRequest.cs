using Domain.AskForPasta.Entities;
using System.Text.Json.Serialization;

namespace Application.AskForPasta.DTOs.Requests
{
    public abstract class BaseRequest
    {
        protected BaseRequest(User user)
        {
            User = user;
            RequestTime = DateTime.Now;
        }


        public User User { get; set; }
        [JsonIgnore]
        public DateTime RequestTime { get; set; }
    }
}
