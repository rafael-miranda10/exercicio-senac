using Flunt.Notifications;

namespace Senac.API.Models.ValueObjects
{
    public class NameUI : Notifiable
    {
        protected NameUI() { }

        public NameUI(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public string FirstName { get;  set; }
        public string LastName { get;  set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
