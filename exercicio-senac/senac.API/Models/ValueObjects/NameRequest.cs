using Flunt.Notifications;

namespace Senac.API.Models.ValueObjects
{
    public class NameRequest :Notifiable
    {
        protected NameRequest() { }

        public NameRequest(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}
