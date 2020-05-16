using Flunt.Notifications;

namespace Senac.API.Models.ValueObjects
{
    public class EmailUI 
    {
        protected EmailUI() { }

        public EmailUI(string address)
        {
            Address = address;
        }

        public string Address { get;  set; }
    }
}
