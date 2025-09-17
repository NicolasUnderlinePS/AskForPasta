using Domain.AskForPasta.Entities;

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
        public DateTime RequestTime { get; set; }
    }
}
