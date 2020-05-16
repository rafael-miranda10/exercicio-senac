using Flunt.Notifications;

namespace Senac.API.Models.ValueObjects
{
    public class EmailRequest : Notifiable
    {
        protected EmailRequest() { }

        public EmailRequest(string address)
        {
            Address = address;
        }

        public string Address { get; set; }
    }
}
