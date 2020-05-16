using Flunt.Notifications;

namespace Senac.API.Models.ValueObjects
{
    public class EmailResponse 
    {
        protected EmailResponse() { }

        public EmailResponse(string address)
        {
            Address = address;
        }

        public string Address { get;  set; }
    }
}
